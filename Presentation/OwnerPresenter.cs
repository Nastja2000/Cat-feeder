using System;
using System.Collections.Generic;
using Model;
using Model.entities;
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

        private void ShowFeeder(string ownerName, string feederName)
        {
            _kernel.Get<FeederPresenter>().Run(ownerName, feederName);
            //presenter.ImitationUpdated += ShowInitiative;
          //  _view.Show();

        }

        private void ShowFeeders(string name)
        {
            
            List<string> names = new List<string>();
            
            foreach (Feeder feeder in _service.GetAllFeeders(name))
            {
                names.Add(feeder.name);
            }
            _view.ShowFeeders(names);
        }

        private void ShowImitationView()
        {
            _kernel.Get<ImitationPresenter>().Run();
            _view.Close();
        }

        
        public void Run(string name)
        {
            ShowFeeders(name);
            _view.Show();
        }        
    }
}

