using System;
using Model;
using Ninject;

namespace Presentation
{
    public class AdminOwnerPresenter
    {
        private readonly IKernel _kernel;
        private IAdminOwnerView _view;
        private IAdminOwnerService _service;
        public AdminOwnerPresenter(IAdminOwnerView view, IAdminOwnerService service, IKernel kernel)
        {
            _kernel = kernel;

            _view = view;
            _view.ShowFeeder += ShowFeeder;
            _view.AddFeeder += AddFeeder;
            _view.DeleteFeeder += DeleteFeeder;
            _view.GoBack += ShowImitationView;

            _service = service;
        }


        private void DeleteFeeder(string name)
        {
            _service.DeleteFeeder(name);
        }

        private void AddFeeder(string name)
        {
            _service.AddFeeder(name);
        }

        private void ShowFeeder()
        {
            _kernel.Get<AdminFeederPresenter>().Run();
            //presenter.ImitationUpdated += ShowInitiative;
            _view.Show();

        }

        private void ShowFeeders()
        {
            _view.ShowFeeders(_service.GetAllFeeders());
        }

        private void ShowImitationView()
        {
            _kernel.Get<AdminPresenter>().Run();
            _view.Close();
        }


        public void Run()
        {
            // ShowFeeders();
            _view.Show();
        }
    }
}

