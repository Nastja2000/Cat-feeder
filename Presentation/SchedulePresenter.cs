using System;

using System.Collections;
using System.Collections.Generic;
using System.IO;
using Model;
using Model.entities;
using Model.services;
using Ninject;

namespace Presentation
{
    public class SchedulePresenter
    {
        private readonly IKernel _kernel;
        private IScheduleView _view;
        private IScheduleService _service;
        public SchedulePresenter(IScheduleView view, IScheduleService service, IKernel kernel)
        {
            _kernel = kernel;

            _view = view;

            _view.Save += Save;
            //   _view.AddMark += AddMark;
            _view.GoBack += ShowImitationView;

            _service = service;
        }

        private void ShowImitationView(string ownerName, string feederName)
        {
            _kernel.Get<FeederPresenter>().Run(ownerName, feederName);
            _view.Close();
        }

        /*     private void AddMark(string flag)
             {
                 _service.AddMark(flag);
             }*/


        private void Save(IEnumerable<string> fields)
        {
            _service.Save(fields);
        }

        private void ShowStats(string name)
        {
            Schedule schedule = _service.GetSchedule(name);
            _view.TurnDurationLimit = schedule.interval.ToString();
            _view.TurnFoodAmount = schedule.amountOfFood.ToString();
        }

        public void Run(string ownerName, string feederName, string scheduleName)
        {
            //ShowSchs();
            _view.scheduleName = scheduleName;
            _view.feederName = feederName;
            _view.ownerName = ownerName;
            ShowStats(scheduleName);
            _view.Show();
        }

    }
}
