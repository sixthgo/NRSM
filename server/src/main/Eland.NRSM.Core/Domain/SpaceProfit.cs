using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eland.NRSM.Core.Domain
{
    [Serializable]
    public class SpaceProfit
    {
        public string Result { get; set; }
        public string Message { get; set; }
        public decimal Area { get; set; }
        public decimal Profit { get; set; }
    }
}
