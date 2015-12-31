using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eland.NRSM.Core.Domain
{
    [Serializable]
    public class FloorHistoryRecord
    {
        public RecordCurrentList HistoryCurrentList { get; set; }
        public RecordStoreInfoList HistoryStoreInfoList { get; set; }
        public RecordIFList HistoryIFList { get; set; }
    }

    [Serializable]
    public class RecordCurrentList
    {
        public string LayoutCode { get; set; }
        public string ShapeID { get; set; }
        public decimal GSpaceSize { get; set; }
        public decimal NSpaceSize { get; set; }
        public decimal GoalSum { get; set; }
        public string LayoutModuleName { get; set; }
        public decimal SalesSum { get; set; }
        public decimal ProfitSum { get; set; }
        public decimal ProfitPercent { get; set; }
    }

    [Serializable]
    public class RecordStoreInfoList
    {
        public string LayoutCode { get; set; }
        public string ShapeID { get; set; }
        public string AreaType { get; set; }
        public string ReportCode { get; set; }
        public string CalcType { get; set; }
        public decimal Value { get; set; }
        public string Color { get; set; }
    }

    [Serializable]
    public class RecordIFList
    {
        public string CalcType { get; set; }
        public string ReportCode { get; set; }
        public string Grade { get; set; }
        public decimal ValueFrom { get; set; }
        public decimal ValueTo { get; set; }
        public string Color { get; set; }
        public string VisioText { get; set; }
        public decimal Quantity { get; set; }
        public decimal Percent { get; set; }
        public int Sequence { get; set; }
    }
}
