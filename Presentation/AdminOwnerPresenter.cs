﻿using System;
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



        private void deleteFeeder(string name)
        {
            //TODO принимаем чья и какая
            _service.deleteFeeder(0, int.Parse(name));

        }

        private void addFeeder(string name)
        {
            //TODO принимаем чья и как зовут
            _service.addFeeder(0, name);
        }

        private void ShowFeeder()
        {
            _kernel.Get<AdminFeederPresenter>().Run();
            //presenter.ImitationUpdated += ShowInitiative;
            _view.Show();

        }

        private void ShowFeeders(int id)
        {
            _view.ShowFeeders(_service.GetAllFeeders(id));
        }

        private void ShowImitationView()
        {
            _kernel.Get<AdminPresenter>().Run();
            _view.Close();
        }


        public void Run(int id)
        {
             ShowFeeders(id);
            _view.Show();
        }
    }
}

