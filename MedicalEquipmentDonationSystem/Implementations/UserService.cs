using MedicalEquipmentDonationSystem.Context;
using MedicalEquipmentDonationSystem.DTOs.Users.Request;
using MedicalEquipmentDonationSystem.DTOs.Users.Response;
using MedicalEquipmentDonationSystem.Entities;
using MedicalEquipmentDonationSystem.Helper;
using MedicalEquipmentDonationSystem.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;
using System.Security.AccessControl;
using static System.Net.WebRequestMethods;

namespace MedicalEquipmentDonationSystem.Implementations
{
    public class UserService : IUserService
    {
        private readonly MEDSDbContext _context;
        public UserService(MEDSDbContext context)
        {
            _context = context;

        }

        public async Task<List<ProfileDTO>> GetAllUsersProfile()
        {
            var result = from li in _context.Users
                         select new ProfileDTO
                         {
                             Id = li.Id,
                             FirstName = li.FirstName,
                             LastName = li.LastName,
                             Email = li.Email,
                             Phone = li.Phone,
                             Adress = li.Adress,
                             BirthDate = li.BirthDate,
                             GenderId = li.GenderId,
                             NationalityId = li.NationalityId,
                             UserTypeId = li.UserTypeId,    
                         };
            return await result.ToListAsync();
        }

        public async Task<List<ProfileDTO>> GetProfile(int userId)
        {
            var result = from li in _context.Users
                         where userId == li.Id
                         select new ProfileDTO
                         {
                             Id = li.Id,
                             FirstName = li.FirstName,
                             LastName = li.LastName,
                             Email = li.Email,
                             Phone = li.Phone,
                             Adress = li.Adress,
                             BirthDate = li.BirthDate,
                             GenderId = li.GenderId,
                             NationalityId = li.NationalityId,
                             UserTypeId = li.UserTypeId,
                         };
            return await result.ToListAsync();

        }

        public async Task ManageActivationUserAccount(int Id, bool IsDeleted)
        {
            var user =await (from li in _context.Users where li.Id == Id  select li ).FirstOrDefaultAsync();
            if(user != null)
            {
                user.IsDeleted = IsDeleted; 
                user.ModificationDate = DateTime.Now;
                _context.Update(user);
                await _context.SaveChangesAsync();  

            }
            else
            {
                throw new Exception($"No user with the given Id {Id}");
            }
        }

        public async Task ResetPassword(UpdatePasswordDTO input)
        {
            if (input != null)
            {
                var res = await _context.Users.FirstOrDefaultAsync(x => x.Id == input.Id);
                if (res != null)
                {
                    res.Password =EncryptionHelper.GenerateSHA384String( input.NewPassword);
                   

                    res.ModificationDate = DateTime.Now;
                  
                    _context.Update(res);
                    await _context.SaveChangesAsync();
                  
                }
                else
                {
                    throw new Exception("no user with the given Id");
                }

            }
            else
            {
                throw new Exception("You must pass the Id");
            }

        }

        public async Task SignUp(SignUpDTO sign)
        {
            if (sign != null)
            {
                Users user = new Users()
                {
                    FirstName = sign.FirstName,
                    LastName = sign.LastName,
                    Email = EncryptionHelper.GenerateSHA384String( sign.Email),
                    Password = EncryptionHelper.GenerateSHA384String( sign.Password),
                    Phone = sign.Phone,
                    NationalityId = sign.NationalityId,
                    GenderId = sign.GenderId,
                    Adress = sign.Adress,
                    BirthDate = sign.BirthDate,
                    UserTypeId = 16
                };
                await _context.AddAsync(user);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("You Must Add Your Info");
            }

        }

        public async Task UpdateUserProfile(UpdateInfoDTO input)
        {
            if (input != null)
            {
                var res = await _context.Users.FirstOrDefaultAsync(x => x.Id == input.Id);
                if (res != null)
                {
                    if (!string.IsNullOrEmpty(input.FirstName))
                    {
                        res.FirstName = input.FirstName;
                        res.ModificationDate = DateTime.Now;

                    }
                    if (!string.IsNullOrEmpty(input.LastName))
                    {
                        res.LastName = input.LastName;
                        res.ModificationDate = DateTime.Now;
                    }
                    if (!string.IsNullOrEmpty(input.Email))
                    {
                        res.Email = input.Email;
                        res.ModificationDate = DateTime.Now;
                    }
                    if (!string.IsNullOrEmpty(input.Adress))
                    {
                        res.Adress = input.Adress;
                        res.ModificationDate = DateTime.Now;

                    }
                    _context.Users.Update(res);
                    await _context.SaveChangesAsync();


                }
                else
                {
                    throw new Exception($"NO user with the given Id {input.Id}");
                }
            }
            else
            {
                throw new Exception("You must at least pass your Id ");
            }
        }
        
    }
}
