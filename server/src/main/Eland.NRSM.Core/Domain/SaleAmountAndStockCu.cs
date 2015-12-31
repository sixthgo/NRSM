﻿using Formular.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eland.NRSM.Core.Domain
{
    [Serializable]
    public class SaleAmountAndStockCu
    {
        public decimal Total { get; set; }
        public string Target1 { get; set; }
        public string FloorDesc { get; set; }
        public string Werks { get; set; }
        public string Text1 { get; set; }

        public decimal Zmums { get; set; }
        public decimal Rate1 { get; set; }
        public decimal Persum { get; set; }
        public decimal Count { get; set; }
        public decimal Smums { get; set; }
    }
}
