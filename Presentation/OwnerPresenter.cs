using System;
using Model;
using Model.services;
using Ninject;

namespace Presentation
{
   public class OwnerPresenter
    {
        private readonly IKernel _kernel;
        private IOwnerView _view;
        private IOwnerService _service;
        public OwnerPresenter(IOwnerView view, IOwnerService service, IKernel kernel)
        {
            _kernel = kernel;

            _view = view;
            _view.ShowFeeder += ShowFeeder;
           // _view.AddFeeder += AddFeeder;
           // _view.DeleteFeeder += DeleteFeeder;
            _view.GoBack += ShowImitationView;

            _service = service;
        }


        /*
        private void DeleteFeeder(string name)
        {
            _service.DeleteFeeder(name);
        }*/

      /*  private void AddFeeder(string name)
        {
            _service.AddFeeder(name);
        }*/

        private void ShowFeeder()
        {
            _kernel.Get<FeederPresenter>().Run();
            //presenter.ImitationUpdated += ShowInitiative;
          //  _view.Show();

        }

        private void ShowFeeders(int id)
        {
            _view.ShowFeeders(_service.GetAllFeeders(id));
        }

        private void ShowImitationView()
        {
            _kernel.Get<ImitationPresenter>().Run();
            _view.Close();
        }

        
        public void Run(int id)
        {
           ShowFeeders(id);
            _view.Show();
        }        
    }
}

