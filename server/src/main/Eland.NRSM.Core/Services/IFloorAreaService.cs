using Eland.NRSM.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eland.NRSM.Core.Services
{
    public interface IFloorAreaService
    {
        List<FloorArea> ManageFloorCodeIn(string werks, string floor);

        List<SumCurrentTimeSales> QueryRevenueIn(string werks, string floor);
    }
}
