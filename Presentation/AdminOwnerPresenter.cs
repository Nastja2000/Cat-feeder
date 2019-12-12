﻿using System;
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
            _view.addFeeder += addFeeder;
            _view.deleteFeeder += deleteFeeder;
            _view.GoBack += ShowImitationView;

            _service = service;
        }


        private void deleteFeeder(string name)
        {
            _service.deleteFeeder(int.Parse(name));
        }

        private void addFeeder(string name)
        {
            _service.addFeeder(name);
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

