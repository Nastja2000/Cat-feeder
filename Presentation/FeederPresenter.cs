using System;
using System.IO;
using Model;
using Ninject;

namespace Presentation
{
     public class FeederPresenter
    {
        private readonly IKernel _kernel;
        private IFeederView _view;
        private IFeederService _service;
        public FeederPresenter(IFeederView view, IFeederService service, IKernel kernel)
        {
            _kernel = kernel;

            _view = view;
            _view.ShowSch += ShowSch;
            //_view.ShowUsers += ShowUsers;
            _view.AddSch += AddSch;
            _view.ImportSch += ImportSch;
            _view.ExportSch += ExportSch;
            _view.GoBack += ShowOwnerView;

            _service = service;
        }

        private void ShowOwnerView()
        {
            _kernel.Get<OwnerPresenter>().Run();
            _view.Close();
        }

        private void AddSch(string name)
        {
            _service.AddSch(name);
        }

        private void ShowSchs()
        {
            _view.ShowSchs(_service.GetAllUsers());
        }

        private void ImportSch(string path)
        {
            try
            {
                using (StreamReader reader = File.OpenText(path))
                {
                    _service.ImportSch(reader);
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
                    _service.ExportSch(writer);
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
