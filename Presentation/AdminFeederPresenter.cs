using System;
using System.IO;
using Model;
using Ninject;

namespace Presentation
{
    public class AdminFeederPresenter
    {
        private readonly IKernel _kernel;
        private IAdminFeederView _view;
        private IAdminFeederService _service;
        public AdminFeederPresenter(IAdminFeederView view, IAdminFeederService service, IKernel kernel)
        {
            _kernel = kernel;

            _view = view;
          //  _view.ShowSch += ShowSch;
         //   _view.AddSch += AddSch;
         //   _view.DeleteSch += DeleteSch;
            _view.ImportSch += ImportSch;
            _view.ExportSch += ExportSch;
            _view.GoBack += ShowOwnerView;

            _service = service;
        }

        private void ShowOwnerView()
        {
            _kernel.Get<AdminPresenter>().Run();
            _view.Close();
        }

       /* private void DeleteSch(string name)
        {
            _service.DeleteSch(name);
        }*/

     /*   private void AddSch(string name)
        {
            _service.CreateSchedule(name);
        }*/

      /*  private void ShowSchs()
        {
            _view.ShowSchs(_service.GetAllUsers());
        }*/

        private void ImportSch(string path)
        {
            try
            {
                using (StreamReader reader = File.OpenText(path))
                {
                    _service.ImportSchedule(reader);
                }
            }
            catch (Exception ex)
            {
                _view.ShowError(ex.Message);
            }
        }

        private void ExportSch(string path)
        {
            try
            {
                using (StreamWriter writer = File.CreateText(path))
                {
                    _service.ExportSchedule(writer);
                }
            }
            catch (Exception ex)
            {
                _view.ShowError(ex.Message);
            }
        }

    /*    private void ShowSch()
        {
            _kernel.Get<SchedulePresenter>().RunUser();
            //presenter.ImitationUpdated += ShowInitiative;
            _view.Show();

        }*/

        public void Run()
        {
            //ShowSchs();
            _view.Show();
        }

    }
}
