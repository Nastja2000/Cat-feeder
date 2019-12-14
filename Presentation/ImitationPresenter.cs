using System;
using System.IO;
using Model;
using Model.services;
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
            _view.StartImmitation += StartImmitation;
            _view.StopImmitation += StopImmitation;
            //_view.Step += Step;
            _view.addFood += addFood;
            _view.setEatingFreq += setEatingFreq;
            _view.setEatingQuan += setEatingQuan;
            _view.setStepSize += setStepSize;


            _imitationService = imitationService;
           // _imitationService.TurnFinished += TurnFinished;
            

        }
        /*private void TurnFinished()
        {
            _view.ShowFeederStatus(_imitationService.CountOfFood);
        }*/

        private void ImitationDurationUpdated()
        {
            _view.ShowTime(_imitationService.ImitationDuration);
        }

        private void StartImmitation()
        {
            /* if (int.TryParse(_view.TurnDurationLimit, out int limit))
                 _imitationServise.TurnDurationLimit = TimeSpan.FromSeconds(limit);
             _view.TurnDurationLimit = _imitationServise.TurnDurationLimit.Seconds.ToString();*/

            _imitationService.StartImmitation();
            _view.ImitationStarted();
            //_view.ShowFeederStatus(_imitationService.CountOfFood);
        }

        private void StopImmitation()
        {
            _imitationService.StopImmitation();
            _view.ImitationStopped();
            
        }

        private void ShowUser()
        {
            _kernel.Get<OwnerPresenter>().Run();
            //presenter.ImitationUpdated += ShowInitiative;
            _view.Close();
        }

        private void ShowAdmin()
        {
            _kernel.Get<AdminPresenter>().Run();
            //presenter.ImitationUpdated += ShowInitiative;
           // _view.Show();
        }


  /*      private void Step()
        {
            _imitationService.ImitationDurationUpdated();
        }*/

        private void setStepSize()
        {
            if (int.TryParse(_view.StepSizeVal, out int stepSizeVal))
            {
                _imitationService.setStepSize(stepSizeVal);
            }
            else
            {
                _view.ShowError("Invalid 'Initiative' value");
            }
        }


        private void addFood()
        {
            if (int.TryParse(_view.CountOfFood, out int countOfFood))
            {
                _imitationService.addFood(_view.id, countOfFood);
            }
            else
            {
                _view.ShowError("Invalid 'Initiative' value");
            }
        }

        private void setEatingQuan()
        {
            if (int.TryParse(_view.EatingQuantVal, out int eatingQuantVal))
            {
                _imitationService.setEatingQuan(eatingQuantVal);
            }
            else
            {
                _view.ShowError("Invalid 'Initiative' value");
            }
        }

        private void setEatingFreq()
        {
            if (int.TryParse(_view.EatingFreqVal, out int eatingFreqVal))
            {
                _imitationService.setEatingFreq(eatingFreqVal);
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
