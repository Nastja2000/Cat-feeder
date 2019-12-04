using Model.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public interface IOwnerService
    {

        IEnumerable<Feeder> GetAllFeeders();
        //      +changeName()
        //+log(owner: Owner)
    }
}
