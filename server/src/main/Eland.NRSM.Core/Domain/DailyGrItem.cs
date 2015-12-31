﻿using Formular.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eland.NRSM.Core.Domain
{
    [Serializable]
    public class DailyGrItem : BaseDomain
    {
        public decimal INPUT { set; get; }
        public bool INPUTSpecified { set; get; }
        public string MAKTX { set; get; }
        public string MATNR { set; get; }
        public string MEINS { set; get; }
        public string SEQNR { set; get; }
        public string WERKS { set; get; }
        public DateTime GRDAT { set; get; }
    }
}