using Eland.NRSM.Core.Domain;
using Formular.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eland.NRSM.Core.Services
{
    public interface IManageDailyGrInService
    {
        List<DailyGrHead> GetDailyHeadList(string WERKS, DateTime GRDAT, string MATNR);

        Message SaveDailyHeadList(List<DailyGrItem> list);
    }
}
