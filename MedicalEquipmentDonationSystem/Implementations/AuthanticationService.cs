using MedicalEquipmentDonationSystem.Context;
using MedicalEquipmentDonationSystem.DTOs.Authantication.Request;
using MedicalEquipmentDonationSystem.Helper;
using MedicalEquipmentDonationSystem.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace MedicalEquipmentDonationSystem.Implementations
{
    public class AuthanticationService : IAuthanticationService
    {
        private readonly MEDSDbContext _context;
        public AuthanticationService(MEDSDbContext context)
        {
            _context = context;

        }
        public async Task<string> LogIn(LogInDTO logIn)
        {
            if (logIn != null)
            {
                if (!string.IsNullOrEmpty(logIn.Email) && !string.IsNullOrEmpty(logIn.Password))
                {
                    logIn.Email = EncryptionHelper.GenerateSHA384String(logIn.Email);
                    logIn.Password = EncryptionHelper.GenerateSHA384String(logIn.Password);
                    var authUser = await (from p in _context.Users
                                          join li in _context.LookupItems
                                          on p.UserTypeId equals li.Id
                                          where p.Email == logIn.Email && p.Password == logIn.Password
                                          select new
                                          {
                                              PersonId = p.Id.ToString(),
                                              Role = li.Value.ToString(),
                                          }).FirstOrDefaultAsync();
                    return authUser != null ? await TokenHelper.GenerateToken(authUser.PersonId, authUser.Role) : "Authantication Failed";
                }
                else
                {
                    throw new Exception("Email And Password Required ");

                }

            }
            else
            {
                throw new Exception("Email And Password Required ");
            }

        }
    }
}
