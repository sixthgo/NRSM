﻿using Eland.NRSM.Core.Services;
using Eland.NRSM.Template.Dao;
using Formular.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Domain = Eland.NRSM.Core.Domain;
using Eland.NRSM.Core.Domain;
using System.Web.Script.Serialization;
using Eland.NRSM.Template.MANAGEORDEROFFERPROGRAMIN;
using Eland.NRSM.Template.ZQUERYMATERIALPRICEINFO;

namespace Eland.NRSM.Template.Services
{
    public class FreshFoodOrderService : IFreshFoodOrderService
    {
        public OrderGoodsResult GetFreshFoods(string ekOrg, string ekGrp, string werks, string buDat, string perNo)
        {
            ManageOrderOfferProgramInClient soapClient = new ManageOrderOfferProgramInClient();

            soapClient.ClientCredentials.UserName.UserName = System.Configuration.ConfigurationManager.AppSettings["SAP_WEBSERVICE_USERNAME"];
            soapClient.ClientCredentials.UserName.Password = System.Configuration.ConfigurationManager.AppSettings["SAP_WEBSERVICE_PASSWORD"];

            int year;
            int month;
            int day;

            int.TryParse(buDat.Substring(0, 4), out year);
            int.TryParse(buDat.Substring(4, 2), out month);
            int.TryParse(buDat.Substring(6, 2), out day);

            DateTime dt = new DateTime(year, month, day);

            FreshFoodOrderQuery_sync typeMParam = new FreshFoodOrderQuery_sync()
            {
                EKGRP = ekGrp,
                WERKS = werks,
                BUDAT = dt,
                BUDATSpecified = true,
                PERNO = perNo,
                ZTYPE = "M"
            };

            FreshFoodOrderResponse_sync typeMResult = soapClient.FreshFoodOrderQueryResponse_In(typeMParam);
            ////FreshFoodOrder typeMFreshFoodOrder = new FreshFoodOrder();
            ////typeMFreshFoodOrder.E_SUBRC = typeMResult.Flag; // 0 정상, 4 에러
            ////typeMFreshFoodOrder.E_ZTEXT = typeMResult.ReturnMessage;

            //if (typeMResult.Flag == "E" || typeMResult.Flag == "4")
            //    throw new Exception(typeMResult.ReturnMessage);
            //// second call
            FreshFoodOrderQuery_sync typeAParam = new FreshFoodOrderQuery_sync()
            {
                EKGRP = ekGrp,
                WERKS = werks,
                BUDAT = dt,
                BUDATSpecified = true,
                PERNO = perNo,
                ZTYPE = "A",
                MATNRFreshFoodOrderList = typeMResult.MATNRFreshFoodOrderList
            };

            FreshFoodOrderResponse_sync typeAResult = soapClient.FreshFoodOrderQueryResponse_In(typeAParam);

            //if (typeAResult.Flag == "E" || typeAResult.Flag == "4")
            //    throw new Exception(typeAResult.ReturnMessage);

            QueryMaterialPriceInfoClient client = new QueryMaterialPriceInfoClient();
            client.ClientCredentials.UserName.UserName = System.Configuration.ConfigurationManager.AppSettings["SAP_WEBSERVICE_USERNAME"];
            client.ClientCredentials.UserName.Password = System.Configuration.ConfigurationManager.AppSettings["SAP_WEBSERVICE_PASSWORD"];
                        
            List<Matnr> matnrList = new List<Matnr>();
            MaterialVendorInfoQuery_sync mParam = null;
            OrderGoodsResult orderGoodsResult = new OrderGoodsResult();
            List<OrderGoods> orderGoodsList = new List<OrderGoods>();
            OrderGoods goods = null;
            MaterialVendorInfoResponse_sync q = null;

            orderGoodsResult.Flag = typeAResult.Flag;
            orderGoodsResult.ReturnMessage = typeAResult.ReturnMessage;
            orderGoodsResult.orderGoods = new List<OrderGoods>();

            if (typeAResult.FreshFoodOrderList != null)
            {
                foreach (var item in typeAResult.FreshFoodOrderList)
                {
                    goods = new OrderGoods();

                    goods.LIFNR = item.LIFNR;
                    goods.MATNR = item.MATNR;
                    goods.MAKTX = item.MAKTX;
                    goods.MENGE = item.MENGE;
                    goods.UMREZ = item.UMREZ;
                    ////goods.LFDAT = item.LFDAT.ToString("MMdd");
                    goods.LFDAT = item.LFDAT;
                    goods.NETPR = item.NETPR;
                    goods.LABST = item.LABST;

                    goods.ICON = item.ICON;
                    goods.ICON1 = item.ICON1;

                    goods.NAME1 = item.NAME1;

                    goods.MEINS = item.MEINS;
                    goods.WAKFG = item.WAKFG;
                    goods.MSTAE = item.MSTAE;
                    goods.TDYMG = item.TDYMG;
                    goods.MENG1 = item.MENG1;
                    goods.MENG2 = item.MENG2;
                    goods.MENG3 = item.MENG3;
                    goods.MENG0 = item.MENG0;

                    goods.TNETPR = item.TNETPR;
                    goods.BANFN = item.BANFN;
                    goods.EBELN1 = item.EBELN1;
                    goods.REMARK = item.REMARK;
                    goods.LQTY7 = item.LQTY7;
                    goods.LQTY6 = item.LQTY6;
                    goods.LQTY5 = item.LQTY5;
                    goods.LQTY4 = item.LQTY4;
                    goods.LQTY3 = item.LQTY3;
                    goods.WEQTY = item.WEQTY;
                    goods.YEQTY = item.YEQTY;
                    goods.TOQTY = item.TOQTY;

                    goods.TOTAL = item.TOTAL;
                    goods.EISBE = item.EISBE;
                    goods.DDATE = item.DDATE;
                    goods.WERKS = item.WERKS;
                    goods.EKGRP = item.EKGRP;

                    foreach (var matnr in typeAResult.MATNRFreshFoodOrderList)
                    {
                        if (item.MATNR == matnr.MATNR)
                        {
                            mParam = new MaterialVendorInfoQuery_sync();
                            mParam.EKORG = ekOrg;
                            mParam.MATNR = matnr.MATNR;

                            matnrList = new List<Matnr>();
                            q = client.MaterialVendorInfoQueryResponse_In(mParam);

                            foreach (var innerItem in q.MaterialVendorList)
                            {
                                matnrList.Add(new Matnr()
                                {
                                    MATNR = innerItem.MATNR,
                                    LIFNR_N = string.Format("{0}-{1}", innerItem.LIFNR_N, innerItem.LIFNR),
                                    LIFNR = innerItem.LIFNR
                                });
                            }

                            break;
                        }
                    }

                    goods.MATNRLIST = matnrList;

                    orderGoodsList.Add(goods);
                }
            }
            orderGoodsResult.orderGoods = orderGoodsList;

            return orderGoodsResult;
        }

        public OrderGoodsOrderResult SaveFreshFoods(string werks, string buDat, List<OrderGoods> orderGoods)
        {
            ManageOrderOfferProgramInClient soapClient = new ManageOrderOfferProgramInClient();

            soapClient.ClientCredentials.UserName.UserName = System.Configuration.ConfigurationManager.AppSettings["SAP_WEBSERVICE_USERNAME"];
            soapClient.ClientCredentials.UserName.Password = System.Configuration.ConfigurationManager.AppSettings["SAP_WEBSERVICE_PASSWORD"];

            int year;
            int month;
            int day;

            int.TryParse(buDat.Substring(0, 4), out year);
            int.TryParse(buDat.Substring(4, 2), out month);
            int.TryParse(buDat.Substring(6, 2), out day);

            DateTime dt = new DateTime(year, month, day);

            List<FreshFoodOrderList> freshFoodOrderList = new List<FreshFoodOrderList>();
            FreshFoodOrderList f = null;
            foreach (OrderGoods o in orderGoods)
            {
                f = new FreshFoodOrderList();

                f.LIFNR = o.LIFNR;
                f.MATNR = o.MATNR;
                f.MAKTX = o.MAKTX;

                f.MENGE = o.MENGE;
                f.MENGESpecified = true;

                f.UMREZ = o.UMREZ;
                f.UMREZSpecified = true;

                f.LFDAT = o.LFDAT;
                f.LFDATSpecified = true;

                f.NETPR = o.NETPR;
                f.NETPRSpecified = true;

                f.LABST = o.LABST;
                f.LABSTSpecified = true;

                f.ICON = o.ICON;
                f.ICON1 = o.ICON1;

                f.NAME1 = o.NAME1;

                f.MEINS = o.MEINS;
                f.WAKFG = o.WAKFG;
                f.MSTAE = o.MSTAE;
                f.TDYMG = o.TDYMG;
                f.TDYMGSpecified = true;

                f.MENG1 = o.MENG1;
                f.TDYMGSpecified = true;

                f.MENG2 = o.MENG2;
                f.MENG2Specified = true;

                f.MENG3 = o.MENG3;
                f.MENG3Specified = true;

                f.MENG0 = o.MENG0;
                f.MENG0Specified = true;

                f.TNETPR = o.TNETPR;
                f.BANFN = o.BANFN;
                f.EBELN1 = o.EBELN1;
                f.REMARK = o.REMARK;
                
                f.LQTY7 = o.LQTY7;
                f.LQTY7Specified = true;

                f.LQTY6 = o.LQTY6;
                f.LQTY6Specified = true;

                f.LQTY5 = o.LQTY5;
                f.LQTY5Specified = true;

                f.LQTY4 = o.LQTY4;
                f.LQTY4Specified = true;

                f.LQTY3 = o.LQTY3;
                f.LQTY3Specified = true;

                f.WEQTY = o.WEQTY;
                f.WEQTYSpecified = true;

                f.YEQTY = o.YEQTY;
                f.YEQTYSpecified = true;

                f.TOQTY = o.TOQTY;
                f.TOQTYSpecified = true;

                f.TOTAL = o.TOTAL;
                f.TOTALSpecified = true;

                f.EISBE = o.EISBE;
                f.EISBESpecified = true;

                f.DDATE = o.DDATE;
                f.DDATESpecified = true;

                f.WERKS = o.WERKS;
                f.EKGRP = o.EKGRP;

                freshFoodOrderList.Add(f);
            }

            FreshFoodOrderCrQuery_sync param = new FreshFoodOrderCrQuery_sync();
            param.WERKS = werks;
            param.BUDAT = dt;
            param.BUDATSpecified = true;
            param.FreshFoodOrderList = freshFoodOrderList.ToArray();

            FreshFoodOrderCrResponse_sync res = soapClient.FreshFoodOrderCrQueryResponse_In(param);


            OrderGoodsOrderResult result = new OrderGoodsOrderResult();

            result.Flag = res.Flag;
            result.ReturnMessage = res.ReturnMessage;
            result.orderGoodsResultItem = new List<OrderGoodsResultItem>();

            OrderGoodsResultItem item = null;
            foreach( FreshFoodOrderList i in res.FreshFoodOrderList)
            {
                item = new OrderGoodsResultItem();
                item.BANFN = i.BANFN;
                item.MAKTX = i.MAKTX;

                result.orderGoodsResultItem.Add(item);
            }

            return result;
        }
    }
}
