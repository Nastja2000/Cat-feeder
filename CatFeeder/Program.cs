using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ninject;
using Presentation;
using Model.services;
using Model.services.realization;

namespace CatFeeder
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Ninject.StandardKernel kernel = new StandardKernel();
            kernel.Bind<ApplicationContext>().ToConstant(new ApplicationContext());
            kernel.Bind<IOwnerView>().To<OwnerView>();
            kernel.Bind<IImitationView>().To<ImitationView>();
            kernel.Bind<IFeederView>().To<FeederView>();
            kernel.Bind<IAdminView>().To<AdminView>();
            
            kernel.Bind<IAdminMainService>().To<AdminMainService>();
            kernel.Bind<IAdminOwnerService>().To<AdminOwnerService>();
            kernel.Bind<IFeederService>().To<FeederService>();
            kernel.Bind<IImitationService>().To<ImitationService>();
            kernel.Bind<IOwnerFeederService>().To<OwnerFeederService>();
            kernel.Bind<IOwnerService>().To<OwnerService>();
            kernel.Bind<IScheduleService>().To<ScheduleService>();
            


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //TODO context
            kernel.Get<ImitationPresenter>().Run();
            Application.Run(kernel.Get<ApplicationContext>());
        }
    }
}
