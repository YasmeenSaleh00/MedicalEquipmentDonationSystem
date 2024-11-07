using MedicalEquipmentDonationSystem.DTOs.Order.Request;
using MedicalEquipmentDonationSystem.DTOs.Order.Response;

namespace MedicalEquipmentDonationSystem.Interfaces
{
    public interface IOrderService
    {
        Task CreateOrder(CreateOrderDTO input, string token);
        Task ManageTheOrder(int OrderId, int StatusOrderId);
        Task<List<OrdersDTO>> ReadAllOrders ();   
    }
}
