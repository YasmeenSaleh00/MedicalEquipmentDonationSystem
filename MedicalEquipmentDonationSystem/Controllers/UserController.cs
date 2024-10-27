using MedicalEquipmentDonationSystem.DTOs.Order.Request;
using MedicalEquipmentDonationSystem.DTOs.Product.Request;
using MedicalEquipmentDonationSystem.DTOs.Testimonial.Request;
using MedicalEquipmentDonationSystem.DTOs.Users.Request;
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
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IProductService _productService;
        private readonly ITestimonialService _testimonialService;
        private readonly IOrderService _orderService;
        public UserController(IUserService userService,IProductService productService,ITestimonialService testimonialService,IOrderService orderService)
        {
            _userService = userService;
            _productService = productService;
            _testimonialService = testimonialService;
            _orderService = orderService;
        }

        /// <summary>
        /// This endpoint enables the user to Get their profile
        /// </summary>
        [HttpGet]
        [Route("[action]/{Id}")]
        public async Task<IActionResult> GetProfile([FromHeader] string token, [FromRoute] int Id)
        {
            Log.Information("Operation of Get Profile Has Been Started");
            try
            {
                if (!await TokenHelper.ValidateToken(token, "User"))
                {
                    return Unauthorized("You Not Authorized For Get this  profile ");
                }
                var response = await _userService.GetProfile(Id);
                Log.Information($"Get Profile  from DB");

                return response.Count > 0 ? Ok(response) : StatusCode(204, "No Available Profile");
            }
            catch (Exception ex)
            {
                Log.Error($"An Error Was Occurred When Get Profile {ex.Message}");
                return StatusCode(500, ex.Message);
            }

        }

        /// <summary>
        /// This endpoint enables the user to register into the system
        /// </summary>

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> SignUp([FromBody] SignUpDTO sign)
        {
            Log.Information("Sign up operation has been Started ");
            try
            {
                await _userService.SignUp(sign);
                Log.Information($"New User Called {sign.FirstName} add to DB");
                return StatusCode(201, "New User Created");

            }
            catch (Exception ex)
            {
                Log.Error("An Error Was Occurred When  New User Singing up");
                Log.Error(ex.ToString());
                return StatusCode(500, $"Error : {ex.Message}");

            }
        }


        /// <summary>
        /// This endpoint enables the user to Add Their Products
        /// </summary>

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> SubmitProduct([FromHeader] string token,[FromBody] CreateProductDTO input)
        {
            Log.Information("Create Product  operation has been Started ");
            try
            {
                if (!await TokenHelper.ValidateToken(token, "User"))
                {
                    return Unauthorized("You Not Authorized For Create Product ");
                }
                await _productService.CreateProduct(input);
                Log.Information($"New Product Called {input.NameOfProudct} add to DB");
                return StatusCode(201, "New product  Created");

            }
            catch (Exception ex)
            {
                Log.Error("An Error Was Occurred When  New product created");
                Log.Error(ex.ToString());
                return StatusCode(500, $"Error : {ex.Message}");

            }
        }

        /// <summary>
        /// This endpoint enables the user to Request product
        /// </summary>

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> RequestProduct([FromHeader] string token, [FromBody] CreateOrderDTO input)
        {
            Log.Information("Request Product  operation has been Started ");
            try
            {
                if (!await TokenHelper.ValidateToken(token, "User"))
                {
                    return Unauthorized("You Not Authorized For Request Product ");
                }
                await _orderService.CreateOrder(input);
                Log.Information($"New Order add to DB");
                return StatusCode(201, "New Order  Created");

            }
            catch (Exception ex)
            {
                Log.Error("An Error Was Occurred When Order created");
                Log.Error(ex.ToString());
                return StatusCode(500, $"Error : {ex.Message}");

            }
        }
        /// <summary>
        /// This endpoint enables the user to Add Testimonial
        /// </summary>

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> CreateTestimonial([FromHeader] string token, [FromBody] CreateTestimonialDTO input)
        {
            Log.Information("Create Testimonial  operation has been Started ");
            try
            {
                if (!await TokenHelper.ValidateToken(token, "User"))
                {
                    return Unauthorized("You Not Authorized For Create Testimonial ");
                }
                await _testimonialService.CreateTestimonial(input);
                Log.Information($"New Testimonial  add to DB");
                return StatusCode(201, "New Testimonial  Created");

            }
            catch (Exception ex)
            {
                Log.Error("An Error Was Occurred When  New Testimonial created");
                Log.Error(ex.ToString());
                return StatusCode(500, $"Error : {ex.Message}");

            }
        }
        /// <summary>
        /// This endpoint enables the user to update profile Info
        /// </summary>

        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateUserInfo([FromHeader] string token, [FromBody] UpdateInfoDTO input)
        {
            Log.Information("Update User Info operation has been Started ");
            try
            {
                if (!await TokenHelper.ValidateToken(token, "User"))
                {
                    return Unauthorized("You Not Authorized For Update ");
                }
                await _userService.UpdateUserProfile(input);
                Log.Information($"Updated Successfully");
                return StatusCode(200, "Updated Successfully");

            }
            catch (Exception ex)
            {
                Log.Error("An Error Was Occurred When  User trying  update his Info");
                Log.Error(ex.ToString());
                return StatusCode(500, $"Error : {ex.Message}");

            }
        }
        /// <summary>
        /// This endpoint enables the user to reset password
        /// </summary>

        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> ResetPassword([FromHeader] string token, [FromBody] UpdatePasswordDTO input)
        {
            Log.Information("Update User password operation has been Started ");
            try
            {
                if (!await TokenHelper.ValidateToken(token, "User"))
                {
                    return Unauthorized("You Not Authorized For reset password ");
                }
                await _userService.ResetPassword(input);
                Log.Information($"Updated Successfully");
                return StatusCode(200, "Updated Successfully");

            }
            catch (Exception ex)
            {
                Log.Error("An Error Was Occurred When  User trying  update his password");
                Log.Error(ex.ToString());
                return StatusCode(500, $"Error : {ex.Message}");

            }
        }
        /// <summary>
        /// This endpoint enables the user to update Product Info
        /// </summary>

        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateProductInfo([FromHeader] string token, [FromBody] UpdateProductDTO input)
        {
            Log.Information("Update Product Info operation has been Started ");
            try
            {
                if (!await TokenHelper.ValidateToken(token, "User"))
                {
                    return Unauthorized("You Not Authorized For Update Product");
                }
                await _productService.UpdateProductInformation(input);
                Log.Information($"Updated Successfully");
                return StatusCode(200, "Updated Successfully");

            }
            catch (Exception ex)
            {
                Log.Error("An Error Was Occurred When  User trying  update Product");
                Log.Error(ex.ToString());
                return StatusCode(500, $"Error : {ex.Message}");

            }
        }
        /// <summary>
        /// This endpoint enables the user to Accept orders or not
        /// </summary>

        [HttpPut]
        [Route("[action]/{OrderId}/{OrderStatus}")]
        public async Task<IActionResult> AcceptOrders([FromHeader] string token, [FromRoute] int OrderId , [FromRoute] int OrderStatus )
        {
            Log.Information("Update Order Status operation has been Started ");
            try
            {
                if (!await TokenHelper.ValidateToken(token, "User"))
                {
                    return Unauthorized("You Not Authorized For Update Order Status ");
                }
                await _orderService.ManageTheOrder(OrderId,OrderStatus);
                Log.Information($"Updated Successfully");
                return StatusCode(200, "Updated Successfully");

            }
            catch (Exception ex)
            {
                Log.Error("An Error Was Occurred When  User trying  Update Order Status");
                Log.Error(ex.ToString());
                return StatusCode(500, $"Error : {ex.Message}");

            }
        }


    }
}
