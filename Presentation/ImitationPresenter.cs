using System;
using Model;
using Ninject;

namespace Presentation
{
    public class ImitationPresenter
    {
        private readonly IKernel _kernel;
        private IImitationView _view;
        private IImitationService _imitationService;

        public InitiativePresenter(IKernel kernel, IImitationView view, IImitationService imitationService)
        {

            _kernel = kernel;

            _view = view;
            _view.ShowUser += ShowUser;
            _view.ShowAdmin += ShowAdmin;
            _view.StartImitation += StartImitation;
            _view.StopImitation += StopImitation;
            _view.Step += Step;
            _view.AddFood += AddFood;
            _view.EatingFreq += EatingFreq;
            _view.EatingQuant += EatingQuant;
            _view.StepSize += StepSize;


            _imitationServise = imitationServise;
            _imitationServise.TurnFinished += TurnFinished;
            

        }

        private void TurnFinished()
        {
            _view.ShowFeederStatus(_imitationServise.CountOfFood);
        }

        private void ImitationDurationUpdated()
        {
            _view.ShowTime(_imitationServise.ImitationDuration);
        }

        private void StartImitation()
        {
            if (int.TryParse(_view.TurnDurationLimit, out int limit))
                _imitationServise.TurnDurationLimit = TimeSpan.FromSeconds(limit);
            _view.TurnDurationLimit = _imitationServise.TurnDurationLimit.Seconds.ToString();

            _imitationServise.StartImitation();
            _view.ImitationtStarted();
            _view.ShowFeederStatus(_imitationServise.CountOfFood);
        }

        private void StopImitation()
        {
            _imitationServise.StopCombat();
            _view.ImitationStopped();
            
        }

        private void ShowUser()
        {
            _kernel.Get<OwnerPresenter>().Run();
            //presenter.ImitationUpdated += ShowInitiative;
            _view.Show();
        }

        private void ShowAdmin()
        {
            _kernel.Get<AdminPresenter>().Run();
            //presenter.ImitationUpdated += ShowInitiative;
           // _view.Show();
        }


        private void Step()
        {
            _imitationServise.ImitationDurationUpdated();
        }

        private void StepSize()
        {
            if (int.TryParse(_view.StepSizeVal))
            {
                _imitationServise.AddFood(StepSizeVal);
            }
            else
            {
                _view.ShowError("Invalid 'Initiative' value");
            }
        }


        private void AddFood()
        {
            if (int.TryParse(_view.CountOfFood))
            {
                _imitationServise.AddFood(countOfFood);
            }
            else
            {
                _view.ShowError("Invalid 'Initiative' value");
            }
        }

        private void EatingQuant()
        {
            if (int.TryParse(_view.EatingQuantVal))
            {
                _imitationServise.EatingQuant(EatingQuantVal);
            }
            else
            {
                _view.ShowError("Invalid 'Initiative' value");
            }
        }

        private void EatingFreq()
        {
            if (int.TryParse(_view.EatingFreqVal))
            {
                _imitationServise.EatingFreq(EatingFreqVal);
            }
            else
            {
                _view.ShowError("Invalid 'Initiative' value");
            }
        }

        public void Run()
        {
            _view.Show();
        }

        
    }
}
