using Formular.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eland.NRSM.Core.Domain
{
    [Serializable]
    public class PC : BaseDomain
    {
        public string PCCode { get; set; }
        public string PCName { get; set; }
        public string CUCode { get; set; }
        public string CUName { get; set; }
    }

}
