using Azure;
using MedicalEquipmentDonationSystem.DTOs.Category.Request;
using MedicalEquipmentDonationSystem.DTOs.Lookups.Request;
using MedicalEquipmentDonationSystem.DTOs.Transaction.Request;
using MedicalEquipmentDonationSystem.Entities;
using MedicalEquipmentDonationSystem.Helper;
using MedicalEquipmentDonationSystem.Implementations;
using MedicalEquipmentDonationSystem.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace MedicalEquipmentDonationSystem.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly ILookupService _lookupService;
        private readonly ICategoryService _categoryService; 
        private readonly IUserService _userService;
        private readonly ITestimonialService _testimonialService;
        private readonly IProductService _productService;
        private readonly IOrderService _orderService;
        private readonly ITransactionService _transactionService;
        public AdminController(ILookupService lookupService, ICategoryService categoryService,IUserService userService,ITestimonialService testimonialService,IProductService productService,IOrderService orderService,ITransactionService transactionService) {
            _lookupService = lookupService;
            _categoryService= categoryService;  
            _userService= userService;
            _testimonialService= testimonialService;
            _productService= productService;
            _orderService= orderService;
            _transactionService= transactionService;



        }
        /// <summary>
        /// This EndPoint To Show All LookupTypes 
        /// </summary>
        
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetLookupType([FromHeader] string token)
        {
            Log.Information("Operation of Get Lookup Types Has Been Started");
            try
            {
                if (!await TokenHelper.ValidateToken(token, "Admin"))
                {
                    return Unauthorized("You Not Authorized For Get Lookup Type ");
                }
                var response = await _lookupService.GetLookupType();
                Log.Information($"Lookup Types  Return  {response.Count} from DB");

                return response.Count > 0 ? Ok(response) : StatusCode(204, "No Available Lookup Types");
            }
            catch (Exception ex)
            {
                Log.Error($"An Error Was Occurred When Get Lookup Types {ex.Message}");
                return StatusCode(500 , ex.Message);    
            }

        }

        /// <summary>
        /// This EndPoint To Show All Lookup item depend on type
        /// </summary>

        [HttpGet]
        [Route("[action]/{Id}")]
        public async Task<IActionResult> GetLookupItemViaType([FromHeader] string token,[FromRoute] int Id)
        {
            Log.Information("Operation of Get Lookup Item Has Been Started");
            try
            {
                if (!await TokenHelper.ValidateToken(token, "Admin"))
                {
                    return Unauthorized("You Not Authorized For Get Lookup Item ");
                }
                var response = await _lookupService.GetLookupItemValueByType(Id);
                Log.Information($"Lookup item  Return  {response.Count} from DB");

                return response.Count > 0 ? Ok(response) : StatusCode(204, "No Available Lookup Types");
            }
            catch (Exception ex)
            {
                Log.Error($"An Error Was Occurred When Get Lookup Types {ex.Message}");
                return StatusCode(500, ex.Message);
            }

        }
        /// <summary>
        /// This EndPoint To Show All Categories
        /// </summary>

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetCategories([FromHeader] string token    )
        {
            Log.Information("Operation of Get Categories Has Been Started");
            try
            {
                if (!await TokenHelper.ValidateToken(token, "Admin"))
                {
                    return Unauthorized("You Not Authorized For Get Category ");
                }
                var response = await _categoryService.GetAllCategory();
                Log.Information($"Categories  Return  {response.Count} from DB");

                return response.Count > 0 ? Ok(response) : StatusCode(204, "No Available Categories");
            }
            catch (Exception ex)
            {
                Log.Error($"An Error Was Occurred When Get Categories {ex.Message}");
                return StatusCode(500, ex.Message);
            }

        }
        /// <summary>
        /// This EndPoint To Show Users Profiles
        /// </summary>

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllUsersProfile([FromHeader] string token)
        {
            Log.Information("Operation of Get All Users Profile Has Been Started");
            try
            {
                if (!await TokenHelper.ValidateToken(token, "Admin"))
                {
                    return Unauthorized("You Not Authorized For Get All users profile ");
                }
                var response = await _userService.GetAllUsersProfile();
                Log.Information($"Get All users Profile from DB");

                return response.Count > 0 ? Ok(response) : StatusCode(204, "No Available Profile");
            }
            catch (Exception ex)
            {
                Log.Error($"An Error Was Occurred When Get all Profile {ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }
        /// <summary>
        /// This EndPoint To Show All Orders
        /// </summary>

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> ReadAllOrder([FromHeader] string token)
        {
            Log.Information("Operation of  Show All Orders Has Been Started");
            try
            {
                if (!await TokenHelper.ValidateToken(token, "Admin"))
                {
                    return Unauthorized("You Not Authorized To Show All Orders ");
                }
                var response = await _orderService.ReadAllOrders();
                Log.Information($"Orders  Return  {response.Count} from DB");

                return response.Count > 0 ? Ok(response) : StatusCode(204, "No Available Orders");
            }
            catch (Exception ex)
            {
                Log.Error($"An Error Was Occurred When Get Orders {ex.Message}");
                return StatusCode(500, ex.Message);
            }

        }
        /// <summary>
        /// This EndPoint To Show All Transaction
        /// </summary>

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> ReadAllTransaction([FromHeader] string token)
        {
            Log.Information("Operation of  Show All Transaction Has Been Started");
            try
            {
                if (!await TokenHelper.ValidateToken(token, "Admin"))
                {
                    return Unauthorized("You Not Authorized To Show All Transaction ");
                }
                var response = await _transactionService.ReadAllTransaction();
                Log.Information($"Transaction  Return  {response.Count} from DB");

                return response.Count > 0 ? Ok(response) : StatusCode(204, "No Available Transaction");
            }
            catch (Exception ex)
            {
                Log.Error($"An Error Was Occurred When Get Transaction {ex.Message}");
                return StatusCode(500, ex.Message);
            }

        }

        /// <summary>
        /// This EndPoint To Show All Testimonial depend on type
        /// </summary>

        [HttpGet]
        [Route("[action]/{TestimonialId}")]
        public async Task<IActionResult> GetTestimonialSViaType([FromHeader] string token, [FromRoute] int TestimonialId)
        {
            Log.Information("Operation of Get Testimonial Has Been Started");
            try
            {
                if (!await TokenHelper.ValidateToken(token, "Admin"))
                {
                    return Unauthorized("You Not Authorized For Get Testimonial ");
                }
                var response = await _testimonialService.GetTestimonailByType(TestimonialId);
                Log.Information($"Testimonial  Return  {response.Count} from DB");

                return response.Count > 0 ? Ok(response) : StatusCode(204, "No Available Testimonial");
            }
            catch (Exception ex)
            {
                Log.Error($"An Error Was Occurred When Get Testimonial {ex.Message}");
                return StatusCode(500, ex.Message);
            }

        }

        /// <summary>
        /// This EndPoint To Create New Category in system 
        /// </summary>
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> CreateCategory([FromHeader] string token, [FromBody] CreateCategoryDTO input)
        {
            Log.Information("Create Category Has been started");
            try
            {
                if (!await TokenHelper.ValidateToken(token, "Admin"))
                {
                    return Unauthorized("You Not Authorized For Create Category");
                }
                await _categoryService.CreateCategory(input);
                Log.Information($"New Category Called {input.Name} was added to DB");
                return StatusCode(201, "Created Successfully ");

            }
            catch (Exception ex)
            {
                Log.Error($"An Error Was Occurred When Create New Category {ex.Message}");
               
                return StatusCode(500, $"Error : {ex.Message}");
            }

        }
        /// <summary>
        /// This EndPoint To Create New Transaction in system 
        /// </summary>
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> CreateTransaction([FromHeader] string token, [FromBody] CreateTransactionDTO input)
        {
            Log.Information("Create Transaction Has been started");
            try
            {
                if (!await TokenHelper.ValidateToken(token, "Admin"))
                {
                    return Unauthorized("You Not Authorized For Create Transaction");
                }
                await _transactionService.CreateTransaction(input);
                Log.Information($"NewTransaction  was added to DB");
                return StatusCode(201, "Created Successfully ");

            }
            catch (Exception ex)
            {
                Log.Error($"An Error Was Occurred When Create New Transaction {ex.Message}");

                return StatusCode(500, $"Error : {ex.Message}");
            }

        }
        /// <summary>
        /// This EndPoint To Update Lookup item Info
        /// </summary>
        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateLookupItemInfo([FromHeader] string token, [FromBody] UpdateLookupItemDTO input)
        {
            Log.Information("Operation of update LookupItem Info Has Been Started");
            try
            {
                if (!await TokenHelper.ValidateToken(token, "Admin"))
                {
                    return Unauthorized("You Not Authorized For update Lookup Item ");
                }
                await _lookupService.UpdateLookupItem(input);
                Log.Information($" LookupItem Info Updated");
                return StatusCode(200, "Updated successfully");
            }
            catch (Exception ex)
            {
                Log.Error($"An Error Was Occurred When update LookupItem Info {ex.Message}");
                return StatusCode(500, ex.Message);

            }


        }

        /// <summary>
        /// This EndPoint To Manage  Activation Status for Types
        /// </summary>
        [HttpPut]
        [Route("[action]/{Id}/{IsDeleted}")]
        public async Task<IActionResult> ManageActivationStatusLookupTypes([FromHeader]string token,[FromRoute]int Id, [FromRoute] bool IsDeleted)
        {
            Log.Information("Operation of update status  Lookup Types Has Been Started");
            try
            {
                if (!await TokenHelper.ValidateToken(token, "Admin"))
                {
                    return Unauthorized("You Not Authorized For Manage Activation  Lookup Item ");
                }
                await _lookupService.UpdateLookupTypeStatus(Id, IsDeleted);
                Log.Information($" LookupType  Updated ");
                return StatusCode(200, "Updated successfully");
            }
            catch (Exception ex)
            {
                Log.Error($"An Error Was Occurred When update Lookup Types {ex.Message}");
                return StatusCode(500, ex.Message);

            }


        }
      

        /// <summary>
        /// This EndPoint To Update Category Info
        /// </summary>
        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateCategoryInfo([FromHeader] string token, [FromBody] UpdateCategoryDTO input)
        {
            Log.Information("Operation of update Category Info Has Been Started");
            try
            {
                if (!await TokenHelper.ValidateToken(token, "Admin"))
                {
                    return Unauthorized("You Not Authorized For update category ");
                }
                await _categoryService.UpdateCategory(input);
                Log.Information($" Category Info Updated");
                return StatusCode(200, "Updated successfully");
            }
            catch (Exception ex)
            {
                Log.Error($"An Error Was Occurred When update Category Info {ex.Message}");
                return StatusCode(500, ex.Message);

            }


        }
        /// <summary>
        /// This EndPoint To Manage Activation Status  User Account
        /// </summary>
        [HttpPut]
        [Route("[action]/{Id}/{IsDeleted}")]
        public async Task<IActionResult> ManageActivationUsersAccount([FromHeader] string token, [FromRoute] int Id , [FromRoute] bool IsDeleted)
        {
            Log.Information("Operation of  Manage Activation User Account Has Been Started");
            try
            {
                if (!await TokenHelper.ValidateToken(token, "Admin"))
                {
                    return Unauthorized("You Not Authorized For Manage Activation User Account  ");
                }
                await _userService.ManageActivationUserAccount(Id,IsDeleted);
                Log.Information($" Activation User Account Updated");
                return StatusCode(200, "Updated successfully");
            }
            catch (Exception ex)
            {
                Log.Error($"An Error Was Occurred When update Activation User Account {ex.Message}");
                return StatusCode(500, ex.Message);

            }


        }
        /// <summary>
        /// This EndPoint To Manage Activation Status for product
        /// </summary>
        [HttpPut]
        [Route("[action]/{Id}/{IsDeleted}")]
        public async Task<IActionResult> ManageActivationProduct([FromHeader] string token, [FromRoute] int Id, [FromRoute] bool IsDeleted)
        {
            Log.Information("Operation of  Manage Activation product Has Been Started");
            try
            {
                if (!await TokenHelper.ValidateToken(token, "Admin"))
                {
                    return Unauthorized("You Not Authorized For Manage Activation product  ");
                }
                await _productService.ManageStatus(Id, IsDeleted);
                Log.Information($" Activation product Updated");
                return StatusCode(200, "Updated successfully");
            }
            catch (Exception ex)
            {
                Log.Error($"An Error Was Occurred When update product {ex.Message}");
                return StatusCode(500, ex.Message);

            }


        }
        /// <summary>
        /// This EndPoint To Manage Activation Status  Testimonial
        /// </summary>
        [HttpPut]
        [Route("[action]/{Id}/{IsDeleted}")]
        public async Task<IActionResult> ManageActivationTestimonial([FromHeader] string token, [FromRoute] int Id, [FromRoute] bool IsDeleted)
        {
            Log.Information("Operation of  Manage Activation Testimonial Has Been Started");
            try
            {
                if (!await TokenHelper.ValidateToken(token, "Admin"))
                {
                    return Unauthorized("You Not Authorized For Manage Activation Testimonial  ");
                }
                await _testimonialService.ManageActivationStatus(Id, IsDeleted);
                Log.Information($" Activation Testimonial Updated");
                return StatusCode(200, "Updated successfully");
            }
            catch (Exception ex)
            {
                Log.Error($"An Error Was Occurred When update Testimonial {ex.Message}");
                return StatusCode(500, ex.Message);

            }


        }

    }
}
