using System;
using System.Net.Http;
using System.Threading.Tasks;
using SpazioDati.Dandelion.Business.Clients;
using SpazioDati.Dandelion.Domain.Models;

namespace SpazioDati.Dandelion.Business.Services
{
    /// <summary> 
    ///     Services class that parse the user parameters and call the <c>client</c> 
    /// </summary>
    /// <seealso cref="ApiClient"/> 
    public class CustomModelService
    {
        private ApiClient _apiClient;

        public CustomModelService(ApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        /// <summary> 
        ///     Asyncronous method that validate the user parameters and call <c>ApiClient</c>       
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns>Returns a <c>CustomModelDto</c> populated with the result of the call </returns>
        /// <seealso cref="CustomModelDto"/> 
        public Task<CustomModelDto> CallCreateCustomModelAsync(CustomModelParameters parameters)
        {
            ServiceUtils.ParameterValidation(parameters);
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

        /// <summary> 
        ///     Asyncronous method that validate the user parameters and call <c>ApiClient</c>       
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns>Returns a <c>CustomModelDto</c> populated with the result of the call </returns>
        /// <seealso cref="CustomModelDto"/> 
        public Task<CustomModelDto> CallReadCustomModelAsync(CustomModelParameters parameters)
        {
            ServiceUtils.ParameterValidation(parameters);
            if (string.IsNullOrEmpty(parameters.Id))
            {
                throw new ArgumentException(ErrorMessages.WrongId, ErrorMessages.Id);
            }

            return _apiClient.CallApiAsync<CustomModelDto>(ApiClient.CustomModelUriBuilder(), ApiClient.ReadCustomModelContentBuilder(parameters), HttpMethod.Get);
        }

        /// <summary> 
        ///     Asyncronous method that validate the user parameters and call <c>ApiClient</c>       
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns>Returns a <c>CustomModelDto</c> populated with the result of the call </returns>
        /// <seealso cref="CustomModelDto"/> 
        public Task<CustomModelDto> CallUpdateCustomModelAsync(CustomModelParameters parameters)
        {
            ServiceUtils.ParameterValidation(parameters);
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

        /// <summary> 
        ///     Asyncronous method that validate the user parameters and call <c>ApiClient</c>       
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns>Returns a <c>CustomModelDto</c> populated with the result of the call </returns>
        /// <seealso cref="CustomModelDto"/> 
        public Task CallDeleteCustomModelAsync(CustomModelParameters parameters)
        {
            ServiceUtils.ParameterValidation(parameters);
            if (string.IsNullOrEmpty(parameters.Id))
            {
                throw new ArgumentException(ErrorMessages.WrongId, ErrorMessages.Id);
            }

            return _apiClient.CallApiAsync<CustomModelDto>(ApiClient.CustomModelUriBuilder(), ApiClient.DeleteCustomModelContentBuilder(parameters), HttpMethod.Delete);
        }

        /// <summary> 
        ///     Asyncronous method that validate the user parameters and call <c>ApiClient</c>       
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns>Returns a <c>CustomModelDto</c> populated with the result of the call </returns>
        /// <seealso cref="CustomModelDto"/> 
        public Task<CustomModelsListDto> CallListAllCustomModelsAsync()
        {
            return _apiClient.CallApiAsync<CustomModelsListDto>(ApiClient.CustomModelUriBuilder(), null, HttpMethod.Get);
        }
    }
}