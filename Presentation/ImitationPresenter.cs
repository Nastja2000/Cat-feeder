using System;
using System.IO;
using Model;
using Ninject;

namespace Presentation
{
    public class ImitationPresenter
    {
        private readonly IKernel _kernel;

        private IImitationView _view;

        private IImitationService _imitationService;

        public ImitationPresenter(IKernel kernel, IImitationView view, IImitationService imitationService)
        {

            _kernel = kernel;

            _view = view;
            _view.ShowUser += ShowUser;
            _view.ShowAdmin += ShowAdmin;
            _view.StartImitation += StartImitation;
            _view.StopImitation += StopImitation;
            //_view.Step += Step;
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
           /* if (int.TryParse(_view.TurnDurationLimit, out int limit))
                _imitationServise.TurnDurationLimit = TimeSpan.FromSeconds(limit);
            _view.TurnDurationLimit = _imitationServise.TurnDurationLimit.Seconds.ToString();*/

            _imitationServise.StartImitation();
            _view.ImitationStarted();
            _view.ShowFeederStatus(_imitationServise.CountOfFood);
        }

        private void StopImitation()
        {
            _imitationServise.StopImitation();
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
            if (int.TryParse(_view.StepSizeVal, out int stepSizeVal))
            {
                _imitationServise.AddFood(stepSizeVal);
            }
            else
            {
                _view.ShowError("Invalid 'Initiative' value");
            }
        }


        private void AddFood()
        {
            if (int.TryParse(_view.CountOfFood, out int countOfFood))
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
            if (int.TryParse(_view.EatingQuantVal, out int eatingQuantVal))
            {
                _imitationServise.EatingQuant(eatingQuantVal);
            }
            else
            {
                _view.ShowError("Invalid 'Initiative' value");
            }
        }

        private void EatingFreq()
        {
            if (int.TryParse(_view.EatingFreqVal, out int eatingFreqVal))
            {
                _imitationServise.EatingFreq(eatingFreqVal);
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
