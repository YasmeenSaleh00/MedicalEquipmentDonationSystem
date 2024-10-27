using MedicalEquipmentDonationSystem.Implementations;
using MedicalEquipmentDonationSystem.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace MedicalEquipmentDonationSystem.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SharedController : ControllerBase
    {
        private readonly IBrandService _brandService;
        private readonly IProductService _productService;
        public SharedController(IBrandService brandService, IProductService productService)
        {
            _brandService = brandService;
            _productService = productService;
        }
        ///<summary>
        ///This EndPoint To Get All Brands 
        ///</summary>
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllBrands()
        {
            Log.Information("Operation of Get Brands Has Been Started");
            try
            {
                var responses = await _brandService.GetAllBrand();
                Log.Information($"Brand  Return  {responses.Count} from DB");
                return responses.Count > 0 ? Ok(responses) : StatusCode(204, "No Available Brand");
            }
            catch (Exception ex)
            {
                Log.Error("An Error Was Occurred When Get Brand");
                Log.Error(ex.ToString());
                return StatusCode(500, $"Error : {ex.Message}");
            }
        }
        ///<summary>
        ///This EndPoint To Get All Product via category 
        ///</summary>
        [HttpGet]
        [Route("[action] /{categoryId}")]
        public async Task<IActionResult> GetProductViaCategory([FromRoute] int categoryId)
        {
            Log.Information("Operation of Get Product Via Category Has Been Started");
            try
            {
                var responses = await _productService.GetProducByCategory(categoryId);
                Log.Information($"Product  Return  {responses.Count} from DB");
                return responses.Count > 0 ? Ok(responses) : StatusCode(204, "No Available Product");
            }
            catch (Exception ex)
            {
                Log.Error("An Error Was Occurred When Get Product");
                Log.Error(ex.ToString());
                return StatusCode(500, $"Error : {ex.Message}");
            }
        }
        ///<summary>
        ///This EndPoint To Get All Product via Brand 
        ///</summary>
        [HttpGet]
        [Route("[action] /{BrandId}")]
        public async Task<IActionResult> GetProductViaBrand([FromRoute] int BrandId)
        {
            Log.Information("Operation of Get Product via Brand Has Been Started");
            try
            {
                var responses = await _productService.GetProductViaBrand(BrandId);
                Log.Information($"Product  Return  {responses.Count} from DB");
                return responses.Count > 0 ? Ok(responses) : StatusCode(204, "No Available Product");
            }
            catch (Exception ex)
            {
                Log.Error("An Error Was Occurred When Get Product");
                Log.Error(ex.ToString());
                return StatusCode(500, $"Error : {ex.Message}");
            }
        }

    }
}
