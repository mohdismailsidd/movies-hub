using EVideoPrime.API.Abstractions.Models.VideoPrime;
using EVideoPrime.API.Entities.VideoPrime;
using EVideoPrime.API.Repository.Interfaces;

namespace EVideoPrime.API.Repository.SqlRepository.Interface.VideoPrime
{
    public interface IPaymentRepository : IRepository<PaymentDetail>
    {
        Task<IEnumerable<PaymentModel>> GetAllPaymentsByPlanAsync(string plan);
        Task<IEnumerable<PaymentModel>> GetAllPaymentsByUserAsync(string username);
    }
}