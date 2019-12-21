using System;
using System.Collections.Generic;
using System.IO;
using Model;
using Model.entities;
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
            _view.SetActive += SetActive;

            _service = service;
            _service.FeederUpdated += ShowSchs;
        }

        private void ShowOwnerView(string name)
        {
            //TODO id
            _kernel.Get<OwnerPresenter>().Run(name);
            _view.Close();
        }

        private void CreateSchedule(string feederName, string name)
        {
            //TODO назвать нормально и распарсить
            //вписать вниз соответсвенно
            _service.CreateSchedule(feederName, name);
        }

        private void ShowSchs(string feederName)
        {
            List<string> names = new List<string>();
            foreach (Schedule schedule in _service.GetAllSchedules(feederName))
            {
                names.Add(schedule.name);
            }
            ;
            _view.ShowSchs(names);
        }

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
                _view.ShowError(ex.Message);
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
                _view.ShowError(ex.Message);
            }
        }

        private void ShowSch(string ownerName, string feederName, string scheduleName)
        {
            _kernel.Get<SchedulePresenter>().Run(ownerName, feederName, scheduleName);
            //presenter.ImitationUpdated += ShowInitiative;
            _view.Show();

        }

        private void SetActive(string feederName, string scheduleName)
        {
            _service.chooseSchedule(feederName, scheduleName);
            //presenter.ImitationUpdated += ShowInitiative;
            _view.Show();

        }

        public void Run(string ownerName, string feederName)
        {
            _view.ownerName = ownerName;
            _view.feederName = feederName;
            ShowSchs(feederName);
            _view.Show();
        }

    }
}
