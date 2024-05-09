using ToDoApplicationMVP.Shared.ApiClient;
using ToDoApplicationMVP.Shared.Presenters;

namespace ToDoApplicationMVP
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {            
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            var form = new ToDoListsForm();
            var client = new ToDoApiClient();
            new ToDoListsPresenter(form, client);

            Application.Run(form);
        }
    }
}