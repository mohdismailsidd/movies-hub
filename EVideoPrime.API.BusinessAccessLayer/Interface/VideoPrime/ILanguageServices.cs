using EVideoPrime.API.Abstractions.Models.VideoPrime;

namespace EVideoPrime.API.BusinessAccessLayer.Interface.VideoPrime
{
    public interface ILanguageServices
    {
        Task<LanguageModel> AddLanguageAsync(LanguageModel model);
        Task AddLanguagesAsync(IEnumerable<LanguageModel> models);
        Task<IEnumerable<LanguageModel>> GetAllLanguageAsync();
        Task<LanguageModel> GetLanguageAsync(int id);
        Task RemoveLanguageAsync(IEnumerable<LanguageModel> models);
        Task<LanguageModel> RemoveLanguageAsync(LanguageModel model);
    }
}