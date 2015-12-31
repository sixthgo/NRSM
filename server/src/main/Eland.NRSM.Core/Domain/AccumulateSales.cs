using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Eland.NRSM.Core.Domain
{
    [Serializable]
    public class AccumulateBaseType
    {
        public decimal Total { get; set; }
        public decimal Amount { get; set; }
        public decimal GoalAmount { get; set; }
        public decimal Rate { get; set; }
        public decimal PastAmount { get; set; }
        public decimal GrowthRate { get; set; }
        public decimal SpaceSum { get; set; }
        public decimal SpaceProfit { get; set; }

        public virtual string code { get; set; }
        public virtual string name { get; set; }
    }

    [Serializable]
    public class AccumulateList : AccumulateBaseType
    {
        public string PlantCode { get; set; }
        public string PlantName { get; set; }
        public string CategoryUnit { get; set; }
        public string CategoryUnitName { get; set; }
        public string PurchaseGroup { get; set; }
        public string PurchaseGroupName { get; set; }
        public string BrandCode { get; set; }
        public string BrandName { get; set; }


        public string returnCode;
        public string returnName;
        public string div;

        public override string code
        {

            get
            {
                if (this.BrandCode != null && this.CategoryUnit == null)
                {
                    returnCode = this.PlantCode;
                    div = "shopbrand";
                }
                else if (this.BrandCode != null)
                {
                    returnCode = this.BrandCode;
                    div = "brand";
                }
                else if (this.PurchaseGroup != null)
                {
                    returnCode = this.PurchaseGroup;
                    div = "pc";
                }
                else if (this.CategoryUnit != null)
                {
                    returnCode = this.CategoryUnit;
                    div = "cu";
                }
                else
                {
                    returnCode = this.PlantCode;
                    div = "shop";
                }

                return returnCode;
            }
            set
            {
                if (this.BrandCode != null && this.CategoryUnit == null)
                    this.PlantCode = value;
                else if (this.BrandCode != null)
                    this.BrandCode = value;
                else if (this.PurchaseGroup != null)
                    this.PurchaseGroup = value;
                else if (this.CategoryUnit != null)
                    this.CategoryUnit = value;
                else
                    this.PlantCode = value;
            }
        }
        public override string name
        {
            get
            {
                if (this.BrandName != null && this.CategoryUnit == null)
                    returnName = this.PlantName;
                else if (this.BrandName != null)
                    returnName = this.BrandName;
                else if (this.PurchaseGroupName != null)
                    returnName = this.PurchaseGroupName;
                else if (this.CategoryUnitName != null)
                    returnName = this.CategoryUnitName;
                else
                    returnName = this.PlantName;

                return this.returnName;
            }
            set
            {
                if (this.BrandName != null && this.CategoryUnit == null)
                    this.PlantName = value;
                else if (this.BrandName != null)
                    this.BrandName = value;
                else if (this.PurchaseGroupName != null)
                    this.PurchaseGroupName = value;
                else if (this.CategoryUnitName != null)
                    this.CategoryUnitName = value;
                else
                    this.PlantName = value;


            }
        }
    }
    [Serializable]
    [XmlInclude(typeof(AccumulateList))]
    [SoapInclude(typeof(AccumulateList))]
    public class ResultAccumulateList
    {
        public string Result { get; set; }
        public string Message { get; set; }
        public decimal Total { get; set; }
        public List<AccumulateBaseType> Salesdata { get; set; }
    }

    [Serializable]
    public class AccumulateSales
    {
        public string Result { get; set; }
        public string Message { get; set; }
        //public EventWerkisList RevenueWerksList { get; set; }
        //public EventLaygrList RevenueLaygrList { get; set; }
        //public EventTimeList RevenueTimeList { get; set; }
        //public EventLaygrTimeList RevenueLaygrTimeList { get; set; }
        //public EventBrandList RevenueBrandList { get; set; }
        //public EventBrandPlantList RevenueBrandPlantList { get; set; }
    }
}