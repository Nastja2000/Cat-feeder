using System;
using System.IO;
using Model;
using Ninject;

namespace Presentation
{
    public class AdminPresenter
    {
        private readonly IKernel _kernel;
        private IAdminView _view;
        private IAdminService _service;
        public AdminPresenter(IAdminView view, IAdminService service, IKernel kernel)
        {
            _kernel = kernel;

            _view = view;
            _view.ShowUser += ShowUser;
          //_view.ShowUsers += ShowUsers;
            _view.AddUser += AddUser;
            _view.DeleteUser += DeleteUser;
            _view.GoBack += ShowImitationView;

            _service = service;
        }

        private void ShowInitiativeView()
        {
            _kernel.Get<ImitationPresenter>().Run();
            _view.Close();
        }
        
        private void DeleteUser(string name)
        {
            _service.DeleteUser(name);
        }
        
        private void AddUser(string name)
        {
            _service.AddUser(name);
        }
        
        private void ShowUser()
        {
            _kernel.Get<AdminOwnerPresenter>().RunUser();
                //presenter.ImitationUpdated += ShowInitiative;
                _view.Show();
            
        }
            
        private void ShowUsers()
        {
            _view.ShowUsers(_service.GetAllUsers());
        }

        private void ShowImitationView()
        {
            _kernel.Get<ImitationPresenter>().Run();
            _view.Close();
        }

        public void Run()
        {
            ShowUsers();
            _view.Show();
        }

        public void RunUser()
        {
            _view.ShowUser(_service.GetUser());
            _view.Show();
        }
    }
}
