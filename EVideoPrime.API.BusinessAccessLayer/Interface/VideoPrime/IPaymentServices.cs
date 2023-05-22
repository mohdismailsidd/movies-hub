using EVideoPrime.API.Abstractions.Models.VideoPrime;

namespace EVideoPrime.API.BusinessAccessLayer.Interface.VideoPrime
{
    public interface IPaymentServices
    {
        Task<PaymentModel> CreatePaymentAsync(PaymentModel paymentModel);
        Task<IEnumerable<PaymentModel>> GetAllPaymentAsync();
        Task<IEnumerable<PaymentModel>> GetAllPaymentsByPlanAsync(string plan);
        Task<IEnumerable<PaymentModel>> GetAllPaymentsByUserAsync(string username);
        Task<PaymentModel> GetPaymentAsync(int id);
    }
}