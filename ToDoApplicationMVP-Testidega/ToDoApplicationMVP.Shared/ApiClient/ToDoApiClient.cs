using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ToDoApplicationMVP.Shared.ApiClient
{
    public class ToDoApiClient : IToDoApiClient, IDisposable
    {
        private static HttpClient _httpClient = new HttpClient { BaseAddress = new Uri("https://localhost:7038/api/") };

        public IList<ToDoListModel> List()
        {
            var task = Task.Run(async () => await ListAsync());
            task.Wait();

            return task.Result;
        }

        public async Task<IList<ToDoListModel>> ListAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<ToDoListModel>>("lists");
        }

        public ToDoListModel Get(int id)
        {
            var task = Task.Run(async () => await GetAsync(id));
            task.Wait();

            return task.Result;
        }

        public async Task<ToDoListModel> GetAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<ToDoListModel>("lists/" + id);
        }

        public void Save(ToDoListModel list)
        {
            var task = Task.Run(async () => await SaveAsync(list));
            task.Wait();
        }

        public async Task SaveAsync(ToDoListModel list)
        {
            var url = "lists/";

            if(list.Id == 0)
            {
                await _httpClient.PostAsJsonAsync(url, list);
            }
            else
            {
                await _httpClient.PutAsJsonAsync(url + list.Id, list);
            }        
        }

        public void Delete(int id)
        {
            var task = Task.Run(async () => await DeleteAsync(id));
            task.Wait();
        }

        public async Task DeleteAsync(int id)
        {
            await _httpClient.DeleteAsync("lists/" + id);
        }

        public void Dispose()
        {
            _httpClient.Dispose();
        }
    }
}