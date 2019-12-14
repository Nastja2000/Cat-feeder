using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ninject;
using Presentation;


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
            /*kernel.Bind<ICharacterView>().To<CharacterView>();
            kernel.Bind<IAddInitiativeView>().To<AddInitiativeView>();
            kernel.Bind<IStatisticsView>().To<StatisticsView>();
            kernel.Bind<ICombatService>().To<CombatService>();
            kernel.Bind<ICharacterService>().To<CharacterService>();
            kernel.Bind<IAddInitiativeService>().To<AddInitiativeService>();
            kernel.Bind<IRepository<Character>>().To<CharacterRepository>();
            kernel.Bind<IRepository<InitiativeEntry>>().To<InitiativeEntryRepository>();*/

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //TODO context
            kernel.Get<ImitationPresenter>().Run();
            Application.Run(kernel.Get<ApplicationContext>());
        }
    }
}
