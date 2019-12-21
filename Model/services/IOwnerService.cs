﻿using Model.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.services
{
    public interface IOwnerService
    {
        event Action OwnerUpdated;


        IEnumerable<Feeder> GetAllFeeders(string name);

        void changeName(int id, string name);
        //+log(owner: Owner)
    }
}
