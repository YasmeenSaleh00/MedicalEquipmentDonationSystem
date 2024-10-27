using MedicalEquipmentDonationSystem.Context;
using MedicalEquipmentDonationSystem.DTOs.Lookups.Response;
using MedicalEquipmentDonationSystem.DTOs.Product.Request;
using MedicalEquipmentDonationSystem.DTOs.Product.Response;
using MedicalEquipmentDonationSystem.Entities;
using MedicalEquipmentDonationSystem.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MedicalEquipmentDonationSystem.Implementations
{
    public class ProductService : IProductService
    {
        private readonly MEDSDbContext _context;
        public ProductService(MEDSDbContext context)
        {
            _context = context;
        }
        public async Task CreateProduct(CreateProductDTO input)
        {
            if (input != null)
            {

                var existingBrand = await _context.Brands.FirstOrDefaultAsync(x => x.Id == input.BrandId);


                if (existingBrand == null)
                {

                    Brand newBrand = new Brand()
                    {
                        Name = input.BrandName
                    };


                    _context.Brands.Add(newBrand);
                    await _context.SaveChangesAsync();

                }


                if (!string.IsNullOrEmpty(input.NameOfProudct) || !string.IsNullOrEmpty(input.NameOfProudctAr))
                {
                    Product product = new Product()
                    {
                        NameOfProudct = input.NameOfProudct,
                        NameOfProudctAr = input.NameOfProudctAr,
                        CountryOfOrigin = input.CountryOfOrigin,
                        CategoryId = input.CategoryId,
                        BrandId = input.BrandId,
                        Description = input.Description,
                        DescriptionAr = input.DescriptionAr,
                        ManufactureDate = input.ManufactureDate,
                        StatusProductId = 8,
                        ImagePath = input.ImagePath,
                        UserId = input.UserId,

                    };


                    _context.Add(product);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("You must add the name of your product.");
                }
            }
            else
            {
                throw new Exception("You must add data to add your product.");
            }
        }


        public async Task<List<ProductDTO>> GetProducByCategory(int categoryId)
        {
            var res = from li in _context.Products
                      join p in _context.Categories
                      on li.CategoryId equals p.Id
                      where li.CategoryId == categoryId
                      select new ProductDTO
                      {
                          NameOfProudct = li.NameOfProudct,
                          NameOfProudctAr = li.NameOfProudctAr,
                          Category = p.Name,
                          CategoryAr = p.NameAr,
                          ImagePath = li.ImagePath,
                          UserId = li.UserId,
                          BrandId = li.BrandId,
                          Description = li.Description,
                          StatusProductId = li.StatusProductId,

                      };
            return await res.ToListAsync();


        }

        public async Task<List<PrpductByBrandDTO>> GetProductViaBrand(int brandId)
        {
            var res = from li in _context.Products
                      join p in _context.Brands
                      on li.BrandId equals p.Id
                      where li.BrandId == brandId
                      select new PrpductByBrandDTO
                      {
                          NameOfProudct = li.NameOfProudct,
                          NameOfProudctAr = li.NameOfProudctAr,
                          BrandName = p.Name,
                          ImagePath = li.ImagePath,
                          BrandId = li.BrandId,
                          Description = li.Description,
                          StatusPrductId = li.StatusProductId,

                      };
            return await res.ToListAsync();
        }

        public async Task ManageStatus(int productId, bool IsDeleted)
        {
            var product = await _context.Products.FirstOrDefaultAsync(t => t.Id == productId);
            if (product != null)
            {

                product.IsDeleted = IsDeleted;
                product.ModificationDate = DateTime.Now;
                _context.Update(product);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception($"There is no Product With the Given Id : {productId}");
            }
        }

        public async Task UpdateProductInformation(UpdateProductDTO input)
        {
            if (input != null)
            {
                var result = await _context.Products.FirstOrDefaultAsync(x => x.Id == input.Id);
                if (result != null)
                {
                    if (!string.IsNullOrEmpty(input.NameOfProudct))
                    {
                        result.NameOfProudct = input.NameOfProudct;
                        result.ModificationDate = DateTime.Now;

                    }
                    if (!string.IsNullOrEmpty(input.NameOfProudctAr))
                    {
                        result.NameOfProudctAr = input.NameOfProudctAr;
                        result.ModificationDate = DateTime.Now;

                    }
                    if (!string.IsNullOrEmpty(input.ImagePath))
                    {
                        result.ImagePath = input.ImagePath;
                        result.ModificationDate = DateTime.Now;

                    }

                    _context.Update(result);
                    await _context.SaveChangesAsync();

                }
                else
                {
                    throw new Exception($"No Product with the Given Id {input.Id}");

                }
            }
            else
            {
                throw new Exception("At Least give Id");

            }
        }
    }
}
