using Moq;
using ToDoApplicationMVP.Shared.ApiClient;
using ToDoApplicationMVP.Shared.Interfaces;
using ToDoApplicationMVP.Shared.Presenters;

namespace ToDoApplicationMVP.Tests
{
    public class ToDoListPresenterTests : IDisposable
    {
        private readonly Mock<IToDoListsView> _viewMock;
        private readonly Mock<IToDoApiClient> _apiClientMock;
        private readonly ToDoListsPresenter _presenter;

        public ToDoListPresenterTests()
        {
            _viewMock = new Mock<IToDoListsView>();
            _apiClientMock = new Mock<IToDoApiClient>();

            _presenter = new ToDoListsPresenter(_viewMock.Object, _apiClientMock.Object);
        }        

        [Fact]
        public void Presenter_should_load_list()
        {
            // Arrange
            _apiClientMock.Setup(c => c.List())
                          .Returns(new List<ToDoListModel>())
                          .Verifiable();

            // Act
            var presenter = new ToDoListsPresenter(_viewMock.Object, _apiClientMock.Object);

            // Assert
            _apiClientMock.VerifyAll();
        }

        [Fact]
        public void Presenter_should_select_null_item()
        {
            // Arrange
            _viewMock.SetupSet(x => x.SelectedItemId = 0).Verifiable();
            _viewMock.SetupSet(x => x.SelectedItemTitle = "").Verifiable();

            // Act
            _presenter.SelectItem(null);

            // Assert
            _viewMock.VerifyAll();
        }

        [Fact]
        public void Presenter_should_select_list()
        {
            // Arrange
            var model = new ToDoListModel { Id = 1, Title = "Abc" };
            _viewMock.SetupSet(x => x.SelectedItemId = model.Id).Verifiable();
            _viewMock.SetupSet(x => x.SelectedItemTitle = model.Title).Verifiable();

            // Act
            _presenter.SelectItem(model);

            // Assert
            _viewMock.VerifyAll();
        }

        [Fact]
        public void Presenter_should_save_existing_list()
        {
            // Arrange
            var model = new ToDoListModel { Id = 1, Title = "Abc" };
            var expectedTitle = "Def";
            _viewMock.SetupGet(x => x.SelectedItemTitle).Returns(expectedTitle).Verifiable();
            _apiClientMock.Setup(x => x.Save(model)).Verifiable();
            _apiClientMock.Setup(x => x.List()).Verifiable();

            // Act
            _presenter.SelectItem(model);
            _presenter.Save();

            // Assert
            Assert.Equal(expectedTitle, model.Title);
            _viewMock.VerifyAll();
        }

        [Fact]
        public void Presenter_should_save_new_list()
        {
            // Arrange
            var expectedTitle = "Def";
            _viewMock.SetupGet(x => x.SelectedItemTitle).Returns(expectedTitle).Verifiable();
            _apiClientMock.Setup(x => x.Save(It.IsAny<ToDoListModel>())).Verifiable();
            _apiClientMock.Setup(x => x.List()).Verifiable();

            // Act
            _presenter.SelectItem(null);
            _presenter.Save();

            // Assert
            _viewMock.VerifyAll();
        }

        [Fact]
        public void Presenter_should_delete_list()
        {
            // Arrange
            var list = new ToDoListModel { Id = 10 };
            _viewMock.SetupGet(x => x.SelectedItemId).Returns(list.Id).Verifiable();
            _apiClientMock.Setup(x => x.Delete(list.Id)).Verifiable();
            _apiClientMock.Setup(x => x.List()).Verifiable();

            // Act
            _presenter.SelectItem(list);
            _presenter.Delete();

            // Assert
            _viewMock.VerifyAll();
        }

        public void Dispose()
        {
            _apiClientMock.Object.Dispose();
        }
    }
}