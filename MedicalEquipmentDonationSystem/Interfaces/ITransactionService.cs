using MedicalEquipmentDonationSystem.DTOs.Transaction.Request;
using MedicalEquipmentDonationSystem.DTOs.Transaction.Response;

namespace MedicalEquipmentDonationSystem.Interfaces
{
    public interface ITransactionService
    {
        Task  CreateTransaction(CreateTransactionDTO input);
        Task<List<TransactionDTO>> ReadAllTransaction();
    }
}
