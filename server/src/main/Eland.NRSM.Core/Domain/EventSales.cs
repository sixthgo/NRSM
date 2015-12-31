using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Eland.NRSM.Core.Domain
{
    [Serializable]
    public class EventBaseType
    {
        public decimal Total { get; set; }
        public decimal Amount { get; set; }
        public decimal Rate { get; set; }
        public decimal PerSum { get; set; }
        public decimal Count { get; set; }
        public decimal SpaceSum { get; set; }

        public virtual string code { get; set; }
        public virtual string name { get; set; }
    }

    [Serializable]
    public class EventWerkisList : EventBaseType
    {
        public string PlantCode { get; set; }
        public string PlantName { get; set; }

        public override string code
        {
            get
            {
                return this.PlantCode;
            }
            set
            {
                this.PlantCode = value;
            }
        }
        public override string name
        {
            get
            {
                return this.PlantName;
            }
            set
            {
                this.PlantName = value;
            }
        }
    }

    [Serializable]
    public class EventLaygrList : EventBaseType
    {
        public string LayoutCode { get; set; }
        public string LayoutName { get; set; }
        public override string code
        {
            get
            {
                return this.LayoutCode;
            }
            set
            {
                this.LayoutCode = value;
            }
        }
        public override string name
        {
            get
            {
                return this.LayoutName;
            }
            set
            {
                this.LayoutName = value;
            }
        }

    }

    [Serializable]
    public class EventTimeList : EventBaseType
    {
        public string Time { get; set; }

        public override string code
        {
            get
            {
                return this.Time;
            }
            set
            {
                this.Time = value;
            }
        }
        public override string name
        {
            get
            {
                return this.Time;
            }
            set
            {
                this.Time = value;
            }
        }
    }

    [Serializable]
    public class EventFloorTimeList : EventBaseType
    {
        public string Time { get; set; }

        public override string code
        {
            get
            {
                return this.Time;
            }
            set
            {
                this.Time = value;
            }
        }
        public override string name
        {
            get
            {
                return this.Time;
            }
            set
            {
                this.Time = value;
            }
        }
    }

    [Serializable]
    public class EventLaygrTimeList : EventBaseType
    {
        public string BrandCode { get; set; }
        public string BrandName { get; set; }

        public override string code
        {
            get
            {
                return this.BrandCode;
            }
            set
            {
                this.BrandCode = value;
            }
        }
        public override string name
        {
            get
            {
                return this.BrandName;
            }
            set
            {
                this.BrandName = value;
            }
        }
    }

    [Serializable]
    public class EventBrandList : EventBaseType
    {
        public string BrandCode { get; set; }
        public string BrandName { get; set; }

        public override string code
        {
            get
            {
                return this.BrandCode;
            }
            set
            {
                this.BrandCode = value;
            }
        }
        public override string name
        {
            get
            {
                return this.BrandName;
            }
            set
            {
                this.BrandName = value;
            }
        }
    }

    [Serializable]
    public class EventBrandPlantList : EventBaseType
    {
        public string PlantCode { get; set; }
        public string PlantName { get; set; }

        public override string code
        {
            get
            {
                return this.PlantCode;
            }
            set
            {
                this.PlantCode = value;
            }
        }
        public override string name
        {
            get
            {
                return this.PlantName;
            }
            set
            {
                this.PlantName = value;
            }
        }

    }

    [Serializable]
    public class EventFloorList : EventBaseType
    {
        public string Floor { get; set; }

        public override string code
        {
            get
            {
                return this.Floor;
            }
            set
            {
                this.Floor = value;
            }
        }
        public override string name
        {
            get
            {
                return this.Floor;
            }
            set
            {
                this.Floor = value;
            }
        }

    }

    [Serializable]
    [XmlInclude(typeof(EventBaseType))]
    [SoapInclude(typeof(EventBaseType))]
    [XmlInclude(typeof(EventWerkisList))]
    [SoapInclude(typeof(EventWerkisList))]
    [XmlInclude(typeof(EventBrandPlantList))]
    [SoapInclude(typeof(EventBrandPlantList))]
    [XmlInclude(typeof(EventBrandList))]
    [SoapInclude(typeof(EventBrandList))]
    [XmlInclude(typeof(EventLaygrTimeList))]
    [SoapInclude(typeof(EventLaygrTimeList))]
    [XmlInclude(typeof(EventTimeList))]
    [SoapInclude(typeof(EventTimeList))]
    [XmlInclude(typeof(EventFloorTimeList))]
    [SoapInclude(typeof(EventFloorTimeList))]
    [XmlInclude(typeof(EventFloorList))]
    [SoapInclude(typeof(EventFloorList))]
    [XmlInclude(typeof(EventLaygrList))]
    [SoapInclude(typeof(EventLaygrList))]
    public class ResultEventList
    {
        public string Result { get; set; }
        public string Message { get; set; }
        public decimal Total { get; set; }
        public List<EventBaseType> Salesdata { get; set; }
    }

    [Serializable]
    public class EventSales
    {
        public string Result { get; set; }
        public string Message { get; set; }
        public EventWerkisList RevenueWerksList { get; set; }
        public EventLaygrList RevenueLaygrList { get; set; }
        public EventTimeList RevenueTimeList { get; set; }
        public EventLaygrTimeList RevenueLTimeList { get; set; }
        public EventBrandList RevenueBrandList { get; set; }
        public EventBrandPlantList RevenueBrandPlantList { get; set; }
    }
}
