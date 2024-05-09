using ToDoApplicationMVP.Shared.ApiClient;
using ToDoApplicationMVP.Shared.Interfaces;

namespace ToDoApplicationMVP.Shared.Presenters
{
    public class ToDoListsPresenter
    {
        private readonly IToDoListsView _view;
        private readonly IToDoApiClient _apiClient;

        private ToDoListModel _selectedItem;

        public ToDoListsPresenter(IToDoListsView view, IToDoApiClient apiClient)
        {
            _view = view;
            _view.Presenter = this;

            _apiClient = apiClient;

            LoadLists();
        }

        private void LoadLists()
        {
            _view.Lists = _apiClient.List();
        }

        public void SelectItem(ToDoListModel selectedItem)
        {
            _selectedItem = selectedItem;

            if (_selectedItem == null)
            {
                _view.SelectedItemId = 0;
                _view.SelectedItemTitle = "";
            }
            else
            {
                _view.SelectedItemId = _selectedItem.Id;
                _view.SelectedItemTitle = _selectedItem.Title;
            }
        }

        public void Save()
        {
            var list = _selectedItem;
            if(list == null)
            {
                list = new ToDoListModel();
            }

            list.Title = _view.SelectedItemTitle;

            _apiClient.Save(list);

            LoadLists();
        }

        public void Delete()
        {
            _apiClient.Delete(_view.SelectedItemId);

            LoadLists();
        }
    }
}