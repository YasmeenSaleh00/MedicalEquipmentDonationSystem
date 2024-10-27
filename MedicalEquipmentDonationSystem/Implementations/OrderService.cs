using MedicalEquipmentDonationSystem.Context;
using MedicalEquipmentDonationSystem.DTOs.Order.Request;
using MedicalEquipmentDonationSystem.DTOs.Order.Response;
using MedicalEquipmentDonationSystem.Entities;
using MedicalEquipmentDonationSystem.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MedicalEquipmentDonationSystem.Implementations
{
    public class OrderService : IOrderService
    {
        private readonly MEDSDbContext _context;
        public OrderService(MEDSDbContext context)
        {
            _context = context; 

        }
        public async Task CreateOrder(CreateOrderDTO input)
        {
            if (input != null)
            {
                var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == input.ProductId);
                if (product.StatusProductId == 8) 
                {
                    Order order = new Order()
                    {
                        UserId = input.UserId,
                        RequsterName = input.RequsterName,
                        Phone = input.phone,
                        Adress = input.Adress,
                        ProductId = input.ProductId,
                        StatusOrderId = 13
                    };

                    _context.Orders.Add(order);
                    await _context.SaveChangesAsync();

                }
                else
                {
                    throw new Exception("The specified product is not available for order .");
                }
               

            }
            else
            {
                throw new Exception("you must add your Info to complete the  order");
            }
        }

        public async Task ManageTheOrder(int OrderId, int StatusOrderId)
        {
               var  res =await _context.Orders.FirstOrDefaultAsync(x => x.Id == OrderId);    
            res.StatusOrderId = StatusOrderId;  
            res.ModificationDate = DateTime.Now;
            _context.Update(res);
          await  _context.SaveChangesAsync();
                

        }

        public async Task<List<OrdersDTO>> ReadAllOrders()
        {
            var res = from li in _context.Orders
                      select new OrdersDTO
                      {
                          Id = li.Id,
                          RequsterName= li.RequsterName,
                          Phone = li.Phone,
                          Adress = li.Adress,
                          ProductId= li.ProductId,
                          StatusOrderId= li.StatusOrderId   

                      };
            return await res.ToListAsync();
        }
    }
}
