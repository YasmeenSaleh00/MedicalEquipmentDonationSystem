using MedicalEquipmentDonationSystem.DTOs.Order.Request;
using MedicalEquipmentDonationSystem.DTOs.Order.Response;

namespace MedicalEquipmentDonationSystem.Interfaces
{
    public interface IOrderService
    {
        Task CreateOrder(CreateOrderDTO input);
        Task ManageTheOrder(int OrderId, int StatusOrderId);
        Task<List<OrdersDTO>> ReadAllOrders ();   
    }
}
