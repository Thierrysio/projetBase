using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetBase.Services
{
    public class Apis
    {
        #region attributs
        public readonly HttpClient _httpClient = new HttpClient();
        #endregion

        #region Methodes
        public async Task<ObservableCollection<T>> GetAllAsync<T>(string url)
        {
            try
            {
                var json = await _httpClient.GetStringAsync(Constantes.BaseApiAddress + url);
                var result = JsonConvert.DeserializeObject<List<T>>(json, new IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-dd HH:mm:ss" });
                return new ObservableCollection<T>(result);
            }
            catch (Exception ex)
            {
                // Log or handle the exception as needed.
                throw;
            }
        }
        public async Task<bool> PostOneAsync<T>(string endpoint, T requestDataObj)
        {
            try
            {
                var jsonString = JsonConvert.SerializeObject(requestDataObj);
                var jsonContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync(Constantes.BaseApiAddress + endpoint, jsonContent);

                if (!response.IsSuccessStatusCode)
                {
                    // Handle or log the error based on the response status
                    return response.IsSuccessStatusCode;
                }

                var json = await response.Content.ReadAsStringAsync();
                //T result = JsonConvert.DeserializeObject<T>(json, new IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-dd HH:mm:ss" });
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                // Log or handle the exception as needed.
                return false;
            }


        }
        public async Task<T> GetOneAsync<T>(string endpoint, T requestDataObj)
        {
            try
            {
                var jsonString = JsonConvert.SerializeObject(requestDataObj);
                var jsonContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync(Constantes.BaseApiAddress + endpoint, jsonContent);

                if (!response.IsSuccessStatusCode)
                {
                    // Handle or log the error based on the response status
                    return default(T);
                }

                var json = await response.Content.ReadAsStringAsync();
                T result = JsonConvert.DeserializeObject<T>(json, new IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-dd HH:mm:ss" });
                return result;
            }
            catch (Exception ex)
            {
                // Log or handle the exception as needed.
                return default(T);
            }
        }
        #endregion

    }
}
