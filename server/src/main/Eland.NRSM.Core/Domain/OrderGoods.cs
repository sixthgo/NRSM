using Formular.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eland.NRSM.Core.Domain
{
    [Serializable]
    public class OrderGoodsResult : BaseDomain
    {
        public string Flag { get; set; }
        public string ReturnMessage { get; set; }

        public List<OrderGoods> orderGoods { get; set; }
    }

    [Serializable]
    public class OrderGoods : BaseDomain
    {
        //public string LIFNR_N { get; set; }
        public List<Matnr> MATNRLIST { get; set; }
        public string LIFNR { get; set; }
        public string MATNR { get; set; }
        public string MAKTX { get; set; }
        public decimal MENGE { get; set; }
        public decimal UMREZ { get; set; }
        public DateTime LFDAT { get; set; }
        public decimal NETPR { get; set; }
        public decimal LABST { get; set; }

        //
        public string ICON { get; set; }
        public string ICON1 { get; set; }
        //public string MATNR { get; set; }
        //public string MAKTX { get; set; }
        //public string LIFNR { get; set; }
        public string NAME1 { get; set; }
        //public decimal NETPR { get; set; }
        //public decimal UMREZ { get; set; }
        public string MEINS { get; set; }
        public string WAKFG { get; set; }
        public string MSTAE { get; set; }
        public decimal TDYMG { get; set; }
        public decimal MENG1 { get; set; }
        public decimal MENG2 { get; set; }
        public decimal MENG3 { get; set; }
        public decimal MENG0 { get; set; }
        //public decimal MENGE { get; set; }
        //public DateTime LFDAT { get; set; }
        public string TNETPR { get; set; }
        public string BANFN { get; set; }
        public string EBELN1 { get; set; }
        public string REMARK { get; set; }
        public decimal LQTY7 { get; set; }
        public decimal LQTY6 { get; set; }
        public decimal LQTY5 { get; set; }
        public decimal LQTY4 { get; set; }
        public decimal LQTY3 { get; set; }
        public decimal WEQTY { get; set; }
        public decimal YEQTY { get; set; }
        public decimal TOQTY { get; set; }
        //public decimal LABST { get; set; }
        public decimal TOTAL { get; set; }
        public decimal EISBE { get; set; }
        public DateTime DDATE { get; set; }
        public string WERKS { get; set; }
        public string EKGRP { get; set; }
        //
    }

    [Serializable]
    public class Matnr : BaseDomain, IEquatable<Matnr>
    {
        public string MATNR { get; set; }
        public string LIFNR_N { get; set; }
        public string LIFNR { get; set; }

        public bool Equals(Matnr p)
        {
            // Check whether the compared object is null. 
            if (Object.ReferenceEquals(p, null)) return false;

            // Check whether the compared object references the same data. 
            if (Object.ReferenceEquals(this, p)) return true;

            // Check whether the products' properties are equal. 
            return MATNR.Equals(p.MATNR)
                && LIFNR_N.Equals(p.LIFNR_N)
                && LIFNR.Equals(p.LIFNR);
        }

        public override int GetHashCode()
        {

            // Get the hash code for the Name field if it is not null. 
            int hashProductName = LIFNR == null ? 0 : LIFNR.GetHashCode();

            // Get the hash code for the Code field. 
            int hashProductCode = MATNR.GetHashCode();

            // Calculate the hash code for the product. 
            return hashProductName ^ hashProductCode;
        }
    }

    

    //
    [Serializable]
    public class OrderGoodsParam : BaseDomain
    {
        public List<OrderGoods> orderGoods { get; set; }
    }

    [Serializable]
    public class OrderGoodsOrderResult : BaseDomain
    {
        public string Flag { get; set; }
        public string ReturnMessage { get; set; }

        public List<OrderGoodsResultItem> orderGoodsResultItem { get; set; }
    }

    [Serializable]
    public class OrderGoodsResultItem : BaseDomain
    {
        public string BANFN { get; set; }
        public string MAKTX { get; set; }
    }
}
