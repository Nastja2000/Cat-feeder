using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.services;
using Ninject;


namespace Presentation
{
    public class ListOfOwnersPresenter
    {
        private readonly IKernel _kernel;
        private IListOfOwnersViewcs _view;
        //private IListOfOwnersService _service;
        public ListOfOwnersPresenter(IListOfOwnersViewcs view, /*IListOfOwnersService service,*/ IKernel kernel)
        {
            _kernel = kernel;
          //  _service = service;
            _view = view;


            _view.GoBack += ShowImitationView;
            _view.ShowOwner += ShowOwner;

           // _service.OwnersUpdated += ShowOwners;

        }

        private void ShowOwner(int id)
        {
            _kernel.Get<OwnerPresenter>().Run(id);
            //presenter.ImitationUpdated += ShowInitiative;
            // _view.Show();

        }

       /* private void ShowOwners()
        {
            //TODO разобраться с тем, передавать ли id
            _view.ShowOwners(/*_service.GetAllOwners());
      /*  }
    */
        private void ShowImitationView()
        {
            _kernel.Get<ImitationPresenter>().Run();
            _view.Close();
        }

        public void Run()
        {
            //ShowOwners();
            _view.Show();
        }

    }
}
