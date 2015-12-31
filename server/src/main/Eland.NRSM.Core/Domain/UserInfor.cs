﻿using Formular.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eland.NRSM.Core.Domain
{
    [Serializable]
    public class UserInfor : BaseDomain
    {
        public string EMPNO { get; set; }

        public string WERKS { get; set; }
    }
}
