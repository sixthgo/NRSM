using Formular.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eland.NRSM.Core.Domain
{
    [Serializable]
    public class EIMSInformation : BaseDomain
    {
        public string type { get; set; }
        public decimal ThisYear { get; set; }
        public decimal PreviousYear { get; set; }
        public decimal GrowthRate { get; set; }
        public decimal PPreviousYear { get; set; }
        public decimal PPPreviousYear { get; set; }

    }
}
