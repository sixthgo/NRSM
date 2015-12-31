using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eland.NRSM.Core.Domain
{
    [Serializable]
    public class FloorPlanData
    {
        public string id { get; set; }
        public string changeDate { get; set; }
        public string year { get; set; }
        public string name { get; set; }
        public bool check { get; set; }
        public bool diable { get; set; }
    }
}
