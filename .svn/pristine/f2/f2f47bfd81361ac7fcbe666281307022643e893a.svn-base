using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eland.NRSM.Core.Domain
{
    [Serializable]
    public class StoreDetail
    {
        public StoreDetailInfoList InfoList { get; set; }
        public StoreDetailItemList ItemList { get; set; }
        public StoreDetailEventList EventList { get; set; }
    }
    [Serializable]
    public class StoreDetailEventList
    {
        public string LayoutCode { get; set; }
        public string LayoutName { get; set; }
        public decimal Revenue { get; set; }
    }
    [Serializable]
    public class StoreDetailInfoList
    {
        public string VendorCode { get; set; }
        public string VendorName { get; set; }
        public string Merchandiser { get; set; }
        public string Lgrade { get; set; }
        public string ProfitCenter { get; set; }
        public string ProfitCenterText { get; set; }
        public string SalesType { get; set; }
        public string SalesTypeText { get; set; }
    }
    [Serializable]
    public class StoreDetailItemList
    {
        public string MaterialName { get; set; }
        public decimal Percent { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Material { get; set; }
    }
}