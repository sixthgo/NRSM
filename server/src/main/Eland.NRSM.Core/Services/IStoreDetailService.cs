using Eland.NRSM.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eland.NRSM.Core.Services
{
    public interface IStoreDetailService
    {
        List<StoreDetail> QueryStoreDetailInfoIn(string werks, string floor, string layoutCode);

        List<StoreDetail> QueryStoreDetail2InfoIn(string werks, string floor, string layoutCode, string selectDate);
    }
}