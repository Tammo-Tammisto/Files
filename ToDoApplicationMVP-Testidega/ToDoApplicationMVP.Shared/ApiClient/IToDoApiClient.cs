using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ToDoApplicationMVP.Shared.ApiClient
{
    public interface IToDoApiClient : IDisposable
    {
        IList<ToDoListModel> List();
        Task<IList<ToDoListModel>> ListAsync();
        ToDoListModel Get(int id);
        Task<ToDoListModel> GetAsync(int id);
        void Save(ToDoListModel list);
        Task SaveAsync(ToDoListModel list);
        void Delete(int id);
        Task DeleteAsync(int id);
    }
}