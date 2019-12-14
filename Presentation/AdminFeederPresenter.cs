using System;
using System.IO;
using Model;
using Model.services;
using Ninject;

namespace Presentation
{
    public class AdminFeederPresenter
    {
        private readonly IKernel _kernel;
        private IAdminFeederView _view;
        private IFeederService _service;
        public AdminFeederPresenter(IAdminFeederView view, IFeederService service, IKernel kernel)
        {
            _kernel = kernel;

            _view = view;

            //_view.ShowSch += ShowSch;
            //_view.DeleteSch += DeleteSch;
            _view.ImportSchedule += ImportSchedule;
            _view.ExportSchedule += ExportSchedule;
            _view.GoBack += ShowOwnerView;

            _service = service;
        }

        private void ShowOwnerView()
        {
            _kernel.Get<AdminPresenter>().Run();
            _view.Close();
        }

        /*private void DeleteSch(string name)
        {
            _service.DeleteSch(name);
        }*/
        /*  private void ShowSchs()
        {
            _view.ShowSchs(_service.GetAllSchedules());
        }*/

        private void ImportSchedule(string path)
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

        private void ExportSchedule(string path)
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
            _kernel.Get<SchedulePresenter>().Run();
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
