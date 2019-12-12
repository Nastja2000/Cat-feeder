using System;
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
            _view.Save += Save;
            //_view.AddMark += AddMark;
            _view.GoBack += ShowImitationView;

            _service = service;
        }

        private void ShowImitationView()
        {
            _kernel.Get<FeederPresenter>().Run();
            _view.Close();
        }

       /* private void AddMark(bool flag)
        {
            _service.AddMark(flag);
        }*/

        private void Save(string name)
        {
            _service.Save(name);
        }

        public void Run()
        {
            //ShowSchs();
            _view.Show();
        }

    }
}
