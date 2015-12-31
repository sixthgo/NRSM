using Eland.NRSM.Core.Domain;
using Formular.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eland.NRSM.Core.Services
{
    public interface IManageRealInventoryInService : IGenericService<RealInventory>
    {
        List<RealInventory> GetRealInvertory(decimal lbst, string matrn, string mode, decimal rlabst, string uname, string werks);
    }
}
