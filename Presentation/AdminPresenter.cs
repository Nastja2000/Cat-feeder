using System;
using System.IO;
using Model;
using Model.services;
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

            _view.ShowOwner += ShowOwner;
            _view.addOwner += addOwner;
            _view.deleteOwner += deleteOwner;

            _view.GoBack += ShowImitationView;

            _service = service;
        }

        private void deleteOwner(string name)
        {
            _service.deleteOwner(int.Parse(name));
        }

        private void addOwner(string name)
        {
            _service.addOwner(name);
        }

        private void ShowOwner()
        {
            _kernel.Get<AdminOwnerPresenter>().Run();
            //presenter.ImitationUpdated += ShowInitiative;
            _view.Show();

        }


        private void ShowOwners()
        {
            //TODO разобраться с тем, передавать ли id
            _view.ShowOwners(_service.GetAllOwners());
        }


        private void ShowImitationView()
        {
            _kernel.Get<ImitationPresenter>().Run();
            _view.Close();
        }

        public void Run()
        {
            ShowOwners();
            _view.Show();
        }

        /*public void RunUser()
        {
            //_view.ShowUser(_service.GetUser());
            _view.Show();
        }*/
    }
}
