using System;
<<<<<<< HEAD
=======
using System.Collections;
>>>>>>> common_branch
using System.Collections.Generic;
using System.IO;
using Model;
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
<<<<<<< HEAD
         //   _view.Save += Save;
         //   _view.AddMark += AddMark;
=======
            _view.Save += Save;
            //_view.AddMark += AddMark;
>>>>>>> common_branch
            _view.GoBack += ShowImitationView;

            _service = service;
        }

        private void ShowImitationView()
        {
            _kernel.Get<FeederPresenter>().Run();
            _view.Close();
        }

<<<<<<< HEAD
     /*   private void AddMark(string flag)
=======
       /* private void AddMark(bool flag)
>>>>>>> common_branch
        {
            _service.AddMark(flag);
        }*/

<<<<<<< HEAD
        private void Save(IEnumerable<string> name)
=======
        private void Save( string name)
>>>>>>> common_branch
        {
            //TODO
            IEnumerable<string> fields = null;
            _service.Save(fields);
        }

        public void Run()
        {
            //ShowSchs();
            _view.Show();
        }

    }
}
