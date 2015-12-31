using Eland.NRSM.Core.Services;
using Eland.NRSM.Template.Dao;
using Formular.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain = Eland.NRSM.Core.Domain;
using Eland.NRSM.Template.ZQUERYPOGDISPLAYIN;
using Eland.NRSM.Template.ZQUERYSALEAMTNSTOCK1200IN;

namespace Eland.NRSM.Template.Services
{
    public class SaleAmountAndStockService : GenericService<Domain.SaleAmountAndStock>, ISaleAmountAndStockService
    {
        public Domain.SaleAmountAndStock GetSaleAmountAndStock(string gubun, string werks, string floor, string cu, string pu, string matnr, string wstaw, string pernr, DateTime date)
        {
            QuerySaleAmtNStock1200InClient client = new QuerySaleAmtNStock1200InClient();

            client.ClientCredentials.UserName.UserName = System.Configuration.ConfigurationManager.AppSettings["SAP_WEBSERVICE_USERNAME"];
            client.ClientCredentials.UserName.Password = System.Configuration.ConfigurationManager.AppSettings["SAP_WEBSERVICE_PASSWORD"];

            string tempGubun = gubun;
            if (tempGubun == "10")
                tempGubun = "9";

            SaleAmtNStock1200Query_sync param = new SaleAmtNStock1200Query_sync()
            {
                GUBUN = tempGubun,
                WERKS = werks,
                ZFLOOR = floor,
                CU = cu,
                PU = pu,
                MATNR = matnr,
                WSTAW = wstaw,
                PERNR = pernr,
                DATE = date,
                DATESpecified = true
            };

            SaleAmtNStock1200Response_sync result = client.SaleAmtNStock1200QueryResponse_In(param);

            Domain.SaleAmountAndStock saleAmountAndStock = new Domain.SaleAmountAndStock();
            saleAmountAndStock.ReMsg = result.ReturnMessage;
            saleAmountAndStock.RetCd = result.Flag;
            saleAmountAndStock.Gubun = gubun;

            bool isEmpty = false;

            if (saleAmountAndStock.RetCd != "E") // not error
            {
                if (gubun == "1")
                {
                    List<Domain.SaleAmountAndStockWerks> SaleAmountAndStockWerksList = new List<Domain.SaleAmountAndStockWerks>();
                    Domain.SaleAmountAndStockWerks a = null;

                    if (result.SaleAmtNStockWERKSList == null)
                    {
                        isEmpty = true;
                    }
                    else
                    {
                        if (result.SaleAmtNStockWERKSList.Length == 0)
                        {
                            isEmpty = true;
                        }

                        foreach (var item in result.SaleAmtNStockWERKSList)
                        {
                            a = new Domain.SaleAmountAndStockWerks();
                            a.Total = item.TOTAL;
                            a.Werks = item.WERKS;
                            a.Name1 = item.NAME1;
                            a.Zmums = item.ZMUMS;
                            a.Rate1 = item.RATE1;
                            a.Persum = item.PERSUM;
                            a.Count = item.COUNT;
                            a.Smums = item.SMUMS;

                            SaleAmountAndStockWerksList.Add(a);
                        }
                    }

                    saleAmountAndStock.SaleAmountAndStockWerksList = SaleAmountAndStockWerksList;                    
                }
                else if (gubun == "7")
                {
                    List<Domain.SaleAmountAndStockCu> SaleAmountAndStockCuList = new List<Domain.SaleAmountAndStockCu>();
                    Domain.SaleAmountAndStockCu a = null;

                    if (result.SaleAmtNStockCUList == null)
                    {
                        isEmpty = true;
                    }
                    else
                    {
                        if (result.SaleAmtNStockCUList.Length == 0)
                        {
                            isEmpty = true;
                        }

                        foreach (var item in result.SaleAmtNStockCUList)
                        {
                            a = new Domain.SaleAmountAndStockCu();
                            a.Total = item.TOTAL;
                            a.Target1 = item.TARGET1;
                            a.FloorDesc = item.ZFLOOR_DESC;
                            a.Werks = item.WERKS;
                            a.Text1 = item.TEXT1;

                            a.Zmums = item.ZMUMS;
                            a.Rate1 = item.RATE1;
                            a.Persum = item.PERSUM;
                            a.Count = item.COUNT;
                            a.Smums = item.SMUMS;

                            SaleAmountAndStockCuList.Add(a);
                        }
                    }

                    saleAmountAndStock.SaleAmountAndStockCuList = SaleAmountAndStockCuList;
                }
                else if (gubun == "3")
                {
                    List<Domain.SaleAmountAndStockTime> SaleAmountAndStockTimeList = new List<Domain.SaleAmountAndStockTime>();
                    Domain.SaleAmountAndStockTime a = null;

                    if (result.SaleAmtNStockTIMEList == null)
                    {
                        isEmpty = true;
                    }
                    else
                    {
                        if (result.SaleAmtNStockTIMEList.Length == 0)
                        {
                            isEmpty = true;
                        }

                        foreach (var item in result.SaleAmtNStockTIMEList)
                        {
                            a = new Domain.SaleAmountAndStockTime();
                            a.Total = item.TOTAL;
                            a.Ezeit = item.EZEIT;
                            a.Zmums = item.ZMUMS;
                            a.Rate1 = item.RATE1;
                            a.Persum = item.PERSUM;

                            a.Count = item.COUNT;
                            a.Smums = item.SMUMS;

                            SaleAmountAndStockTimeList.Add(a);
                        }
                    }

                    saleAmountAndStock.SaleAmountAndStockTimeList = SaleAmountAndStockTimeList;
                }
                else if (gubun == "2")
                {
                    List<Domain.SaleAmountAndStockFloor> SaleAmountAndStockFloorList = new List<Domain.SaleAmountAndStockFloor>();
                    Domain.SaleAmountAndStockFloor a = null;

                    if (result.SaleAmtNStockFLOORList == null)
                    {
                        isEmpty = true;
                    }
                    else
                    {
                        if (result.SaleAmtNStockFLOORList.Length == 0)
                        {
                            isEmpty = true;
                        }

                        foreach (var item in result.SaleAmtNStockFLOORList)
                        {
                            a = new Domain.SaleAmountAndStockFloor();
                            a.Total = item.TOTAL;
                            a.Floor = item.ZFLOOR;
                            a.Zmums = item.ZMUMS;
                            a.Rate1 = item.RATE1;
                            a.Persum = item.PERSUM;

                            a.Count = item.COUNT;
                            a.Smums = item.SMUMS;

                            SaleAmountAndStockFloorList.Add(a);
                        }
                    }

                    saleAmountAndStock.SaleAmountAndStockFloorList = SaleAmountAndStockFloorList;
                }
                else if (gubun == "8")
                {
                    List<Domain.SaleAmountAndStockPc> SaleAmountAndStockPcList = new List<Domain.SaleAmountAndStockPc>();
                    Domain.SaleAmountAndStockPc a = null;

                    if (result.SaleAmtNStockPCList == null)
                    {
                        isEmpty = true;
                    }
                    else
                    {
                        if (result.SaleAmtNStockPCList.Length == 0)
                        {
                            isEmpty = true;
                        }

                        foreach (var item in result.SaleAmtNStockPCList)
                        {
                            a = new Domain.SaleAmountAndStockPc();
                            a.Total = item.TOTAL;
                            a.Werks = item.WERKS;
                            a.Text1 = item.TEXT1;
                            a.Ekgrp = item.EKGRP;
                            a.Eknam = item.EKNAM;

                            a.Zmums = item.ZMUMS;
                            a.Rate1 = item.RATE1;
                            a.Smums = item.SMUMS;

                            SaleAmountAndStockPcList.Add(a);
                        }
                    }

                    saleAmountAndStock.SaleAmountAndStockPcList = SaleAmountAndStockPcList;
                }
                else if (gubun == "9" || gubun == "10")
                {
                    List<Domain.SaleAmountAndStockStock> SaleAmountAndStockStockList = new List<Domain.SaleAmountAndStockStock>();
                    Domain.SaleAmountAndStockStock a = null;

                    if (result.SaleAmtNStockSTOCKList == null)
                    {
                        isEmpty = true;
                    }
                    else
                    {
                        if (result.SaleAmtNStockSTOCKList.Length == 0)
                        {
                            isEmpty = true;
                        }

                        foreach (var item in result.SaleAmtNStockSTOCKList)
                        {
                            a = new Domain.SaleAmountAndStockStock();
                            a.Total1 = item.TOTAL1;
                            a.Werks = item.WERKS;
                            a.Name1 = item.NAME1;
                            a.Satnr = item.SATNR;
                            a.Matnr = item.MATNR;

                            a.Ean11 = item.EAN11;
                            a.Maktx = item.MAKTX; // , 로 split 첫번째 인덱스 
                            a.Qty = item.QTY; // 수량
                            a.Total = item.TOTAL; // 매출
                            a.Price = item.PRICE; // 판매가

                            a.Umrez = item.UMREZ;
                            a.Meins = item.MEINS;
                            a.Labst = item.LABST; // 점재고
                            a.Labst2 = item.LABST2; // 물류재고

                            SaleAmountAndStockStockList.Add(a);
                        }
                    }

                    if (cu == "F" || cu == "G")
                    {
                        if (gubun == "9")
                        {
                            string test = string.Empty;

                            var grouped = from item in SaleAmountAndStockStockList
                                          group item by item.Satnr into newList
                                          orderby newList.Key
                                          select newList;

                            List<Domain.SaleAmountAndStockStock> bbb = new List<Domain.SaleAmountAndStockStock>();
                            Domain.SaleAmountAndStockStock b = null;

                            foreach (IGrouping<string, Domain.SaleAmountAndStockStock> items in grouped)
                            {
                                b = new Domain.SaleAmountAndStockStock();

                                foreach (Domain.SaleAmountAndStockStock i in items)
                                {
                                    b.Total1 = i.Total1;
                                    b.Maktx = i.Maktx.Split(",".ToCharArray())[0];
                                    b.Price = i.Price;
                                    b.Qty += i.Qty;
                                    b.Total += i.Total;
                                    b.Labst += i.Labst;
                                    b.Labst2 += i.Labst2;
                                }

                                bbb.Add(b);
                            }

                            SaleAmountAndStockStockList = bbb;
                        }
                    }

                    saleAmountAndStock.SaleAmountAndStockStockList = SaleAmountAndStockStockList;
                }

                if (isEmpty)
                {
                    saleAmountAndStock.RetCd = "EMPTY";
                }
            }

            return saleAmountAndStock;
        }
    }
}