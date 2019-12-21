using System;
using System.Collections.Generic;
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
            _view.Save += saveFeeder;

            _service = service;
            
        }

        private void ShowOwnerView(string name)
        {
            _kernel.Get<AdminOwnerPresenter>().Run(name);
            _view.Close();
        }
        private void saveFeeder(string ownerName, IEnumerable<string> fields)
        {

            _service.SaveFeeder(ownerName, fields);
          //  FeederUpdated?.Invoke();
        }

        /*private void DeleteSch(string name)
        {
            _service.DeleteSch(name);
        }*/
        /*  private void ShowSchs()
        {
            _view.ShowSchs(_service.GetAllSchedules());
        }*/

        private void ImportSchedule(string path, string feederName)
        {
            try
            {
                using (StreamReader reader = File.OpenText(path))
                {
                    //TODO разберись c id
                    int id = 0;
                    _service.ImportSchedule(reader, feederName);
                }
            }
            catch (Exception ex)
            {
                //_view.ShowError(ex.Message);
            }
        }

        private void ExportSchedule(string path, string feederName)
        {
            try
            {
                using (StreamWriter writer = File.CreateText(path))
                {
                    //TODO разберись c id
                    int id = 0;
                    _service.ExportSchedule(writer, feederName);
                }
            }
            catch (Exception ex)
            {
                //_view.ShowError(ex.Message);
            }
        }

    /*    private void ShowSch()
        {
            _kernel.Get<SchedulePresenter>().Run();
            //presenter.ImitationUpdated += ShowInitiative;
            _view.Show();

        }*/

        public void Run(string ownerName, string federName)
        {
            _view.feederName = federName;
            _view.ownerName = ownerName;
            //ShowFeed();
            _view.Show();
        }

    }
}
