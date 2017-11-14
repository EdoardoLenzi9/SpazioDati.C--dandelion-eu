using SpazioDati.Dandelion.Domain.Models;
using System.Threading.Tasks;
using SpazioDati.Dandelion.Business.Clients;

namespace SpazioDati.Dandelion.Business.Services
{
    public class LanguageDetectionService
    {
        private ApiClient _apiClient;

        public LanguageDetectionService(ApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public Task<LanguageDetectionDto> CallLanguageDetectionAsync(LanguageDetectionParameters parameters)
        {
            var source = SourceValidation.verifySingleSource(parameters);
            return _apiClient.CallApiAsync<LanguageDetectionDto>(ApiClient.LanguageDetectionUrlBuilder(source, parameters));
        }

    }
}