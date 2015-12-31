using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eland.NRSM.Core.Domain
{
    [Serializable]
    public class FreshFoodOrder
    {
        public string E_SUBRC { get; set; }
        public string E_ZTEXT { get; set; }

        public List<FreshFoodOrderData> FreshFoodOrderDataList { get; set; }
        public List<FreshFoodOrderMatnr> FreshFoodOrderMatnrList { get; set; }

    }
}
