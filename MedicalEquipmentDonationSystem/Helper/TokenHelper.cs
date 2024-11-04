using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MedicalEquipmentDonationSystem.Helper
{
    public static class TokenHelper
    {
        public async static Task<string> GenerateToken(string personId, string role)
        {
            //مسؤول عن تحضير او تجهيز توكن
            var tokenHandler = new JwtSecurityTokenHandler();
            //عباره عن تجهيز ل secret key
            var tokenKey = Encoding.UTF8.GetBytes("LongSecrectStringForModulekodestartppopopopsdfjnshbvhueFGDKJSFBYJDSAGVYKDSGKFUYDGASYGFskc vhHJVCBYHVSKDGHASVBCL");
          //تجهيز claims 
            var tokenDescriptior = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                        new Claim("PersonId",personId),
                        new Claim(ClaimTypes.Role,role)
                }),
                //تحديد مدة session
                Expires = DateTime.Now.AddHours(3),
                //باستخدام خوارزمية HmacSha256
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey)
                , SecurityAlgorithms.HmacSha256Signature)
            };
            //مسؤول عن تفعيل توكن و ربط جميع المكونات مع بعض
            var token = tokenHandler.CreateToken(tokenDescriptior);
            return tokenHandler.WriteToken(token);
        }
        public async static Task<bool> ValidateToken(string tokenString, string role)
        {
            //بدل على نوع توكن
            String toke = "Bearer " + tokenString;
            var jwtEncodedString = toke.Substring(7);
            var token = new JwtSecurityToken(jwtEncodedString: jwtEncodedString);
            var roleString = (token.Claims.First(c => c.Type == "role").Value.ToString());
            if (token.ValidTo > DateTime.UtcNow && roleString.Equals(role, StringComparison.OrdinalIgnoreCase))
            {

                return true;
            }
            return false;
        }
    }

}

