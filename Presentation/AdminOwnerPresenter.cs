using System;
using Model;
using Model.services;
using Ninject;

namespace Presentation
{
    public class AdminOwnerPresenter
    {
        private readonly IKernel _kernel;
        private IAdminOwnerView _view;
        private IAdminOwnerService _service;

        public event Action FeederUpdated;
        public AdminOwnerPresenter(IAdminOwnerView view, IAdminOwnerService service, IKernel kernel)
        {
            _kernel = kernel;
            _service = service;
            _view = view;
            _view.ShowFeeder += ShowFeeder;

            _view.addFeeder += addFeeder;
            _view.deleteFeeder += deleteFeeder;
            _view.GoBack += ShowImitationView;

            _service.OwnerUpdated += ShowFeeders;
        }



        private void deleteFeeder(string ownerName, string name)
        {
            //TODO принимаем чья и какая
            _service.deleteFeeder(ownerName, name);
            FeederUpdated?.Invoke();

        }

        private void addFeeder(string ownerName, string name)
        {
            //TODO принимаем чья и как зовут
            _service.addFeeder(ownerName, name);
            FeederUpdated?.Invoke();
        }

        private void ShowFeeder()
        {
            _kernel.Get<AdminFeederPresenter>().Run();
            //presenter.ImitationUpdated += ShowInitiative;
            _view.Show();

        }

        private void ShowFeeders(string name)
        {
            _view.ShowFeeders(_service.GetAllFeeders(name));
        }

        private void ShowImitationView()
        {
            _kernel.Get<AdminPresenter>().Run();
            _view.Close();
        }


        public void Run(string name)
        {
            ShowFeeders(name);
            _view.ownerName = name;
            _view.Show();
        }
    }
}

