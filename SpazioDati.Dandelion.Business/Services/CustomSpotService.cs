﻿using System;
using System.Net.Http;
using System.Threading.Tasks;
using SpazioDati.Dandelion.Business.Clients;
using SpazioDati.Dandelion.Domain.Models;

namespace SpazioDati.Dandelion.Business.Services
{
    public class CustomSpotService
    {
        private ApiClient _apiClient;

        public CustomSpotService(ApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public Task<CustomSpotDto> CallCreateCustomSpotAsync(CustomSpotParameters parameters)
        {
            ServiceUtils.ParameterValidation(parameters);
            if (parameters.Data == null)
            {
                throw new ArgumentException(ErrorMessages.MissingData, ErrorMessages.Data);
            }
            if (parameters.Data.List == null)
            {
                throw new ArgumentException(ErrorMessages.MissingList, ErrorMessages.List);
            }
            if (parameters.Data.List.Count <= 0)
            {
                throw new ArgumentException(ErrorMessages.EmptyList, ErrorMessages.List);
            }

            return _apiClient.CallApiAsync<CustomSpotDto>(ApiClient.CustomSpotUriBuilder(), ApiClient.CreateCustomSpotContentBuilder(parameters), HttpMethod.Post);
        }

        public Task<CustomSpotDto> CallReadCustomSpotAsync(CustomSpotParameters parameters)
        {
            ServiceUtils.ParameterValidation(parameters);
            if (string.IsNullOrEmpty(parameters.Id))
            {
                throw new ArgumentException(ErrorMessages.WrongId, ErrorMessages.Id);
            }

            return _apiClient.CallApiAsync<CustomSpotDto>(ApiClient.CustomSpotUriBuilder(), ApiClient.ReadCustomSpotContentBuilder(parameters), HttpMethod.Get);
        }

        public Task<CustomSpotDto> CallUpdateCustomSpotAsync(CustomSpotParameters parameters)
        {
            ServiceUtils.ParameterValidation(parameters);
            if (parameters.Data == null)
            {
                throw new ArgumentException(ErrorMessages.MissingData, ErrorMessages.Data);
            }
            if (parameters.Data.List == null)
            {
                throw new ArgumentException(ErrorMessages.MissingList, ErrorMessages.List);
            }
            if (parameters.Data.List.Count <= 0)
            {
                throw new ArgumentException(ErrorMessages.EmptyList, ErrorMessages.List);
            }
            if (string.IsNullOrEmpty(parameters.Id))
            {
                throw new ArgumentException(ErrorMessages.WrongId, ErrorMessages.Id);
            }

            return _apiClient.CallApiAsync<CustomSpotDto>(ApiClient.CustomSpotUriBuilder(), ApiClient.UpdateCustomSpotContentBuilder(parameters), HttpMethod.Put);
        }

        public Task CallDeleteCustomSpotAsync(CustomSpotParameters parameters)
        {
            ServiceUtils.ParameterValidation(parameters);
            if (string.IsNullOrEmpty(parameters.Id))
            {
                throw new ArgumentException(ErrorMessages.WrongId, ErrorMessages.Id);
            }

            return _apiClient.CallApiAsync<CustomSpotDto>(ApiClient.CustomSpotUriBuilder(), ApiClient.DeleteCustomSpotContentBuilder(parameters), HttpMethod.Delete);
        }

        public Task<CustomSpotsListDto> CallListAllCustomSpotsAsync()
        {
            return _apiClient.CallApiAsync<CustomSpotsListDto>(ApiClient.CustomSpotUriBuilder(), null, HttpMethod.Get);
        }
    }
}