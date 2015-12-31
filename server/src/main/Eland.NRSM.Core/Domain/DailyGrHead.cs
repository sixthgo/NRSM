﻿using Formular.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eland.NRSM.Core.Domain
{
    [Serializable]
    public class DailyGrHead : BaseDomain
    {
        public DateTime GRDAT { set; get; }
        public bool GRDATSpecified { set; get; }
        public decimal INPUT { set; get; }
        public bool INPUTSpecified { set; get; }
        public string LIFNR { set; get; }
        public decimal MACNT { set; get; }
        public bool MACNTSpecified { set; get; }
        public string MAKTX { set; get; }
        public string MATNR { set; get; }
        public string MEINS { set; get; }
        public decimal MENGE { set; get; }
        public bool MENGESpecified { set; get; }
        public string MESSG { set; get; }
        public string NAME1 { set; get; }
        public decimal PRICE { set; get; }
        public bool PRICESpecified { set; get; }
        public string RCODE { set; get; }
        public string WERKS { set; get; }

        public string Flag { get; set; }

        public string ReturnMessage { get; set; }
    }
}
