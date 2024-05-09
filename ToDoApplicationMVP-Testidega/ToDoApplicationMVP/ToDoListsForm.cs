using ToDoApplicationMVP.Shared.ApiClient;
using ToDoApplicationMVP.Shared.Interfaces;
using ToDoApplicationMVP.Shared.Presenters;

namespace ToDoApplicationMVP
{
    public partial class ToDoListsForm : Form, IToDoListsView
    {
        public ToDoListsForm()
        {
            InitializeComponent();
        }

        public IList<ToDoListModel> Lists
        {
            get { return (IList<ToDoListModel>)ToDoListsListBox.DataSource; }
            set { ToDoListsListBox.DataSource = value; }
        }

        public ToDoListsPresenter Presenter { private get; set; }
        public int SelectedItemId
        {
            get { return int.Parse(IdField.Text); }
            set { IdField.Text = value.ToString(); }
        }

        public string SelectedItemTitle
        {
            get { return TitleField.Text; }
            set { TitleField.Text = value; }
        }

        private void ToDoListsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Presenter.SelectItem((ToDoListModel)ToDoListsListBox.SelectedItem);
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            Presenter.Save();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            Presenter.Delete();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            Presenter.SelectItem(null);
        }
    }
}