using Formular.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eland.NRSM.Core.Domain
{
    [Serializable]
    public class SaleAmountAndStockStock
    {
        public decimal Total1 { get; set; }        
        public string Werks { get; set; }
        public string Name1 { get; set; }
        public string Satnr { get; set; }
        public string Matnr { get; set; }

        public string Ean11 { get; set; }
        public string Maktx { get; set; }
        public decimal Qty { get; set; }
        public decimal Total { get; set; }
        public string Price { get; set; }

        public decimal Umrez { get; set; }
        public string Meins { get; set; }
        public decimal Labst { get; set; }
        public decimal Labst2 { get; set; }
    }
}
