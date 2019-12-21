﻿using System;
using System.Collections.Generic;
using System.IO;
using Model;
using Model.entities;
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
            _view.Step += Step;
            _view.addFood += addFood;
            _view.setEatingFreq += setEatingFreq;
            _view.setEatingQuan += setEatingQuan;
            _view.setStepSize += setStepSize;

            _imitationService = imitationService;
            _imitationService.ImitationDurationUpdated += ImitationDurationUpdated;
            _imitationService.FeedersUpdated += ShowFeeders;


        }

        private void ShowFeeders()
        {
            //TODO сделать более изящно?
            List<string> names = new List<string>();
            foreach(Feeder feeder in _imitationService.GetAllFeeders())
            {
                names.Add(feeder.name);
            }
            _view.ShowFood(names);
        }

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

        private void ShowUser(string name)
        {
            //TODO id
            _kernel.Get<OwnerPresenter>().Run(name);
            //presenter.ImitationUpdated += ShowInitiative;
           // _view.Close();
        }

        private void ShowAdmin()
        {
            var presenter = _kernel.Get<AdminPresenter>();
            presenter.FeedersUpdated += ShowFeeders;
            presenter.Run();
           // _view.Show();
        }


        private void Step()
        {
            _imitationService.OneStep();
        }

        //TODO переделать на set что бы проверять на надёжность
        private void setStepSize()
        {
            if (int.TryParse(_view.StepSizeVal, out int stepSizeVal))
            {
                _imitationService.StepSize = stepSizeVal;
            }
            else
            {
                _view.ShowError("Invalid 'Step Size' value");
            }
        }

        //TODO переписать
        private void addFood()
        {
            if (int.TryParse(_view.CountOfFood, out int countOfFood))
            {
                //_imitationService.addFood(_view.id, countOfFood);
            }
            else
            {
                _view.ShowError("Invalid 'Food' value");
            }
        }

        private void setEatingQuan()
        {
            if (int.TryParse(_view.EatingQuantVal, out int eatingQuantVal))
            {
                _imitationService.EatingQuan = eatingQuantVal;
            }
            else
            {
                _view.ShowError("Invalid 'Quantity' value");
            }
        }

        private void setEatingFreq()
        {
            if (int.TryParse(_view.EatingFreqVal, out int eatingFreqVal))
            {
                _imitationService.EatingFreq = eatingFreqVal;
            }
            else
            {
                _view.ShowError("Invalid 'Freq' value");
            }
        }

        public void Run()
        {
            ShowFeeders();
            _view.Show();
        }

        
    }
}
