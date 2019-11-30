﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.entities;

namespace Model
{
    interface IOwnerService
    {
        event Action OwnerUpdated;


        IEnumerable<Feeder> GetAllFeeders();

        void changeName(int id, string name);
        //+log(owner: Owner)
    }
}
