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
        private IAdminMainService _service;
        public AdminPresenter(IAdminView view, IAdminMainService service, IKernel kernel)
        {
            _kernel = kernel;

            _view = view;
            _view.ShowUser += ShowUser;
            _view.AddUser += AddUser;
       //     _view.DeleteUser += DeleteUser;
            _view.GoBack += ShowImitationView;

            _service = service;
        }

        private void DeleteUser(int id)
        {
            _service.deleteOwner(id);
        }

        private void AddUser(string name)
        {
            _service.addOwner(name);
        }

        private void ShowUser()
        {
            _kernel.Get<AdminOwnerPresenter>().Run();
            //presenter.ImitationUpdated += ShowInitiative;
            _view.Show();

        }

     /*   private void ShowUsers()
        {
            _view.ShowUsers(_service.GetAllUsers());
        }*/

        private void ShowImitationView()
        {
            _kernel.Get<ImitationPresenter>().Run();
            _view.Close();
        }

        public void Run()
        {
            _view.Show();
        }

        /*public void RunUser()
        {
            //_view.ShowUser(_service.GetUser());
            _view.Show();
        }*/
    }
}
