using Formular.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eland.NRSM.Core.Domain
{
    [Serializable]
    public class SaleAmountAndStock
    {
        public string RetCd { get; set; }
        public string ReMsg { get; set; }

        public string Gubun { get; set; }

        public List<SaleAmountAndStockCu> SaleAmountAndStockCuList { get; set; }        // gubun 7
        public List<SaleAmountAndStockFloor> SaleAmountAndStockFloorList { get; set; }  // gubun 2
        public List<SaleAmountAndStockPc> SaleAmountAndStockPcList { get; set; }        // gubun 8
        public List<SaleAmountAndStockStock> SaleAmountAndStockStockList { get; set; }  // gubun 9
        public List<SaleAmountAndStockTime> SaleAmountAndStockTimeList { get; set; }    // gubun 3

        public List<SaleAmountAndStockWerks> SaleAmountAndStockWerksList { get; set; }  // gubun 1
    }
}
