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
        public readonly HttpClient _httpClient = new HttpClient();

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

    }
}
