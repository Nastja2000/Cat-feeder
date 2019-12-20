using System;
using System.IO;
using Model;
using Model.services;
using Ninject;

namespace Presentation
{
     public class FeederPresenter
    {
        private readonly IKernel _kernel;
        private IFeederView _view;
        private IOwnerFeederService _service;
        public FeederPresenter(IFeederView view, IOwnerFeederService service, IKernel kernel)
        {
            _kernel = kernel;

            _view = view;
            _view.ShowSch += ShowSch;
            _view.CreateSchedule += CreateSchedule;
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

        private void CreateSchedule(string id_plus_name)
        {
            //TODO назвать нормально и распарсить
            //вписать вниз соответсвенно
            _service.CreateSchedule(0, "name");
        }

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
                    //TODO разберись c id
                    int id = 0;
                    _service.ImportSchedule(reader, id);
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
                    //TODO разберись c id
                    int id = 0;
                    _service.ExportSchedule(writer, id);
                }
            }
            catch (Exception ex)
            {
                _view.ShowError(ex.Message);
            }
        }

        private void ShowSch()
        {
            _kernel.Get<SchedulePresenter>().Run();
            //presenter.ImitationUpdated += ShowInitiative;
            _view.Show();

        }       

        public void Run()
        {
            //ShowSchs();
            _view.Show();
        }

    }
}
