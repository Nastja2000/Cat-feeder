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
<<<<<<< HEAD
          //  _view.ShowSch += ShowSch;
         //   _view.AddSch += AddSch;
         //   _view.DeleteSch += DeleteSch;
            _view.ImportSch += ImportSch;
            _view.ExportSch += ExportSch;
=======
            _view.ShowSch += ShowSch;
            //_view.AddSch += AddSch;
            //_view.DeleteSch += DeleteSch;
            _view.ImportSchedule += ImportSchedule;
            _view.ExportSchedule += ExportSchedule;
>>>>>>> common_branch
            _view.GoBack += ShowOwnerView;

            _service = service;
        }

        private void ShowOwnerView()
        {
            _kernel.Get<AdminPresenter>().Run();
            _view.Close();
        }

<<<<<<< HEAD
       /* private void DeleteSch(string name)
=======
        /*private void DeleteSch(string name)
>>>>>>> common_branch
        {
            _service.DeleteSch(name);
        }*/

     /*   private void AddSch(string name)
        {
<<<<<<< HEAD
            _service.CreateSchedule(name);
=======
            _service.AddSch(name);
>>>>>>> common_branch
        }*/

      /*  private void ShowSchs()
        {
<<<<<<< HEAD
            _view.ShowSchs(_service.GetAllUsers());
=======
            _view.ShowSchs(_service.GetAllSchedules());
>>>>>>> common_branch
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
