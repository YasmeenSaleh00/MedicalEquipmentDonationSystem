using Azure;
using MedicalEquipmentDonationSystem.DTOs.Authantication.Request;
using MedicalEquipmentDonationSystem.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace MedicalEquipmentDonationSystem.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthanticationService _authanticationService;
        public AuthController(IAuthanticationService authanticationService)
        {
            _authanticationService = authanticationService;

        }
        /// <summary>
        /// This EndPoint to LogIn 
        /// </summary>
        
        [HttpPost]
        public async Task<IActionResult> LogIn([FromBody] LogInDTO input)
        {
            Log.Information("Log In operation Has been Started ");
            try
            {
                var res =await _authanticationService.LogIn(input);
                Log.Information("LogIn Successfully");
                return res.Equals("Authantication Failed") ? Unauthorized("Email Or Password Is Not Correct") : Ok(res);

            }
            catch (Exception ex)
            {
                throw new Exception($"An Error Happened {ex.Message}");
                return StatusCode (500, ex.Message);
            }
        }
        
    }
}
