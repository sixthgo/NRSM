﻿using Formular.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eland.NRSM.Core.Domain
{
    [Serializable]
    public class SalePriceSend : BaseDomain
    {

        public string WERKS { get; set; }
        public string MATNR { get; set; }
        public string ZTYPE { get; set; }
    }
}