using System.Collections.Generic;
using ToDoApplicationMVP.Shared.ApiClient;
using ToDoApplicationMVP.Shared.Presenters;

namespace ToDoApplicationMVP.Shared.Interfaces
{
    public interface IToDoListsView
    {
        IList<ToDoListModel> Lists { get; set; }

        int SelectedItemId { get; set; }
        string SelectedItemTitle { get; set; }

        ToDoListsPresenter Presenter { set; }
    }
}