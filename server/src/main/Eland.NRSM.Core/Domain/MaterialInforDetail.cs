﻿using Formular.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eland.NRSM.Core.Domain
{
    [Serializable]
    public class MaterialInforDetail : BaseDomain
    {
        public string mATNR;

        public string mAKTX;

        public string lIFNR;

        public string lIFNR_TX;

        public string bEHVO;

        public string bEHVO_T;

        public decimal zSTD;

        public string mEINH;

        public string tAKLV;

        public string tAKLV_TX;

        public decimal vERPR;

        public string wAERS;
    }
}
