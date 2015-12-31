using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eland.NRSM.Core.Domain
{
    [Serializable]
    public class FloorPlanHistoryCompare
    {
        public FloorPlanFirst FirstFloorPlan { get; set; }
        public FloorPlanSecond SeondFloorPlan { get; set; }
        public FloorPlanCompare CompareFloorPlan { get; set; }
    }

    [Serializable]
    public class FloorPlanFirst
    {
        public string Gubun { get; set; }
        public string LayoutCode { get; set; }
        public decimal GSpaceSize { get; set; }
        public decimal NSpaceSize { get; set; }
        public string LayoutName { get; set; }
    }

    [Serializable]
    public class FloorPlanSecond
    {
        public string Gubun { get; set; }
        public string LayoutCode { get; set; }
        public decimal GSpaceSize { get; set; }
        public decimal NSpaceSize { get; set; }
        public string LayoutName { get; set; }
    }

    [Serializable]
    public class FloorPlanCompare
    {
        public string Gubun { get; set; }
        public string LayoutCode { get; set; }
        public string Color { get; set; }
        public decimal Value { get; set; }
    }
}
