using Formular.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eland.NRSM.Core.Domain
{
    [Serializable]
    public class SaleAmountAndStockFloor
    {
        public decimal Total { get; set; }
        public string Floor { get; set; }
        public decimal Zmums { get; set; }
        public decimal Rate1 { get; set; }
        public decimal Persum { get; set; }

        public decimal Count { get; set; }
        public decimal Smums { get; set; }
    }
}
