using Formular.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eland.NRSM.Core.Domain
{
    [Serializable]
    public class SaleAmountAndStockPc
    {
        public decimal Total { get; set; }
        public string Werks { get; set; }
        public string Text1 { get; set; }
        public string Ekgrp { get; set; }
        public string Eknam { get; set; }

        public decimal Zmums { get; set; }
        public decimal Rate1 { get; set; }
        public decimal Smums { get; set; }
    }
}
