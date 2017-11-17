using System;
using System.Net.Http;
using System.Threading.Tasks;
using SpazioDati.Dandelion.Business.Clients;
using SpazioDati.Dandelion.Domain.Models;

namespace SpazioDati.Dandelion.Business.Services
{
    public class CustomModelService
    {
        private ApiClient _apiClient;

        public CustomModelService(ApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public Task<CustomModelDto> CallCreateCustomModelAsync(CustomModelParameters parameters)
        {
            if (parameters == null)
            {
                throw new ArgumentException(ErrorMessages.MissingParameters);
            }
            if (parameters.Data == null)
            {
                throw new ArgumentException(ErrorMessages.MissingData, ErrorMessages.Data);
            }
            if (parameters.Data.Categories == null)
            {
                throw new ArgumentException(ErrorMessages.MissingCategories, ErrorMessages.Categories);
            }
            if (parameters.Data.Categories.Count <= 0)
            {
                throw new ArgumentException(ErrorMessages.EmptyList, ErrorMessages.Categories);
            }

            return _apiClient.CallApiAsync<CustomModelDto>(ApiClient.CustomModelUriBuilder(), ApiClient.CreateCustomModelContentBuilder(parameters), HttpMethod.Post);
        }

        public Task<CustomModelDto> CallReadCustomModelAsync(CustomModelParameters parameters)
        {
            if (string.IsNullOrEmpty(parameters.Id))
            {
                throw new ArgumentException(ErrorMessages.WrongId, ErrorMessages.Id);
            }

            return _apiClient.CallApiAsync<CustomModelDto>(ApiClient.CustomModelUriBuilder(), ApiClient.ReadCustomModelContentBuilder(parameters), HttpMethod.Get);
        }

        public Task<CustomModelDto> CallUpdateCustomModelAsync(CustomModelParameters parameters)
        {
            if (parameters == null)
            {
                throw new ArgumentException(ErrorMessages.MissingParameters);
            }
            if (parameters.Data == null)
            {
                throw new ArgumentException(ErrorMessages.MissingData, ErrorMessages.Data);
            }
            if (parameters.Data.Categories == null)
            {
                throw new ArgumentException(ErrorMessages.MissingCategories, ErrorMessages.Categories);
            }
            if (parameters.Data.Categories.Count <= 0)
            {
                throw new ArgumentException(ErrorMessages.EmptyList, ErrorMessages.Categories);
            }
            if (string.IsNullOrEmpty(parameters.Id))
            {
                throw new ArgumentException(ErrorMessages.WrongId, ErrorMessages.Id);
            }

            return _apiClient.CallApiAsync<CustomModelDto>(ApiClient.CustomModelUriBuilder(), ApiClient.UpdateCustomModelContentBuilder(parameters), HttpMethod.Put);
        }

        public Task CallDeleteCustomModelAsync(CustomModelParameters parameters)
        {
            if (string.IsNullOrEmpty(parameters.Id))
            {
                throw new ArgumentException(ErrorMessages.WrongId, ErrorMessages.Id);
            }

            return _apiClient.CallApiAsync<CustomModelDto>(ApiClient.CustomModelUriBuilder(), ApiClient.DeleteCustomModelContentBuilder(parameters), HttpMethod.Delete);
        }

        public Task<CustomModelsListDto> CallListAllCustomModelsAsync()
        {
            return _apiClient.CallApiAsync<CustomModelsListDto>(ApiClient.CustomModelUriBuilder(), null, HttpMethod.Get);
        } 
    }
}