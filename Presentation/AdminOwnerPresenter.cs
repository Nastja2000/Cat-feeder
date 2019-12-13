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
<<<<<<< HEAD
            _view.AddFeeder += AddFeeder;
        //    _view.DeleteFeeder += DeleteFeeder;
=======
            _view.addFeeder += addFeeder;
            _view.deleteFeeder += deleteFeeder;
>>>>>>> common_branch
            _view.GoBack += ShowImitationView;

            _service = service;
        }


<<<<<<< HEAD
        private void DeleteFeeder(int id)
        {
            _service.deleteFeeder(id);
=======
        private void deleteFeeder(string name)
        {
            _service.deleteFeeder(int.Parse(name));
>>>>>>> common_branch
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

<<<<<<< HEAD
    /*    private void ShowFeeders()
=======
       /* private void ShowFeeders()
>>>>>>> common_branch
        {
            _view.ShowFeeders(_service.GetAllFeeders());
        }*/

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

