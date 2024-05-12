using CommonLibs;
using DataAccess.DTO;
using DataAccess.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration.UserSecrets;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using WebAppCoreAPI.Models;

namespace WebAppCoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private IUnitOfWork _unitOfWork = null!;
        private readonly IConfiguration _configuration = null!;

        public AccountController(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(UserLogin_RequestData requestData)
        {
            var returndata = new ReturnData();
            try
            {
                //Bước 1: Check tài khoản
                if (requestData == null || string.IsNullOrEmpty(requestData.UserName)
                    || string.IsNullOrEmpty(requestData.UserPass))
                {
                    returndata.ReturnCode = (int)CommonLibs.Enum_ReturnCode.DataNotValid;
                    returndata.ReturnMsg = "Du lieu khong hop le";
                    return Ok(returndata);
                }

                requestData.UserPass = CommonLibs.Sercurity.EncryptPassword(requestData.UserPass);

                var user = await _unitOfWork._userRepository.Login(requestData);
                if (user == null || user.UserId <= 0)
                {
                    returndata.ReturnCode = (int)CommonLibs.Enum_ReturnCode.LoginFail;
                    returndata.ReturnMsg = "Tai khoan khong ton tai";
                    return Ok(returndata);
                }
                //Bước 2: trả về Thông tin Token
                //2.2.0 tạo Claim về lưu dữ liệu của user(fullname, userId  )
                var authClaims = new List<Claim>
                { new Claim(ClaimTypes.Name, user.UserName),
                  new Claim(ClaimTypes.PrimarySid, user.UserId.ToString())
                };
                //2.2.1 TẠO TOKEN  (tạo claims , secretkey , expired)
                //Claim đã được lấy ở bước 2.1
                //SecretKey lấy từ appsetting.json
                //Expired lấy từ appsetting.json
                var newAccessToken = CreateToken(authClaims);
                var token = new JwtSecurityTokenHandler().WriteToken(newAccessToken);
                var refreshToken = GenerateRefreshToken();

                //2.2.2 TẠO refeshtoken VÀ UPDATE lại vào database
                var expiredDateSettingDay = _configuration["JWT:RefreshTokenValidityInDays"];
                var request = new UpdateRefreshTokenExpired_RequestData
                {
                    UserId = user.UserId,
                    RefreshToken = refreshToken,
                    RefreshTokenExpired = DateTime.Now.AddDays(Convert.ToInt32(expiredDateSettingDay))
                };
                var update = await _unitOfWork._userRepository.UpdateRefreshTokenExpired(request);

                //2.2.3 TRẢ VỀ TOKEN + refeshtoken + thông tin user
                var userloginRespone = new UserLoginReturnData
                {
                    userName = user.UserName,
                    token = token,
                    refreshToken = refreshToken,
                    IsAdmin = user.IsAdmin
                };

                return Ok(userloginRespone);
            }
            catch (Exception EX)
            {
                throw;
            }
        }

        private JwtSecurityToken CreateToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
            _ = int.TryParse(_configuration["JWT:TokenValidityInMinutes"], out int tokenValidityInMinutes);

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddMinutes(tokenValidityInMinutes),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }
        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[64];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }
    }
}
/*
 * Bước 1: 
 * - Lấy thông tin đăng nhập từ client gọi vào DB kiểm tra thông tin đăng nhập xem có hay ko?
 * - Trả về Token cho client.
 * - Và mã hóa Password trước khi gọi vào DB bằng RSA256 + Salt.
 * Bước 2:
 * - Tạo Claim + thông tin của SecretKey và Expired để tạo Token.
 * - Tạo tiếp RefreshToken để lưu vào DB.
 * Bước 3: Lưu RefreshToken vào DB.
 * - Trả về thông tin đăng nhập cho client.
 * - Kèm với Token và RefreshToken.
 * */

