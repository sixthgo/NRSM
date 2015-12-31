using Eland.NRSM.Core.Services;
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
using Eland.NRSM.Template.ZQUERYSTOREDETAILINFOIN;

namespace Eland.NRSM.Template.Services
{
    public class StoreDetailService : IStoreDetailService
    {
        public List<StoreDetail> QueryStoreDetailInfoIn(string werks, string floor, string layoutCode)
        {
            QueryStoreDetailInfoInClient soapClient = new QueryStoreDetailInfoInClient();

            //soapClient.ClientCredentials.UserName.UserName = "ceuser";
            //soapClient.ClientCredentials.UserName.Password = "ceuser";

            soapClient.ClientCredentials.UserName.UserName = System.Configuration.ConfigurationManager.AppSettings["SAP_WEBSERVICE_USERNAME"];
            soapClient.ClientCredentials.UserName.Password = System.Configuration.ConfigurationManager.AppSettings["SAP_WEBSERVICE_PASSWORD"];

            List<StoreDetail> detailResult = new List<StoreDetail>();

            if (layoutCode.Length > 6)
            {
                StoreDetailInfoByListQueryMessage_sync param = new StoreDetailInfoByListQueryMessage_sync()
                {
                    PlantCode = werks,
                    Floor = floor,
                    LayoutCode = layoutCode
                };
                StoreDetailInfoByListResponseMessage_sync result = soapClient.StoreDetailInfoByListElementsQueryResponse_In(param);



                if (result.StoreInfoList != null)
                {
                    foreach (StoreInfoList infoList in result.StoreInfoList)
                    {
                        detailResult.Add(new StoreDetail()
                        {
                            InfoList = new StoreDetailInfoList()
                            {
                                VendorCode = infoList.VendorCode,
                                VendorName = infoList.VendorName,
                                Merchandiser = infoList.Merchandiser,
                                Lgrade = (infoList.LGrade == null) ? "-" : infoList.LGrade,
                                ProfitCenter = infoList.ProfitCenter,
                                ProfitCenterText = infoList.ProfitCenterText,
                                SalesType = infoList.SalesType,
                                SalesTypeText = infoList.SalesTypeText
                            }
                        });
                    }
                }
                else
                {
                    detailResult.Add(new StoreDetail()
                    {
                        InfoList = new StoreDetailInfoList()
                        {
                            VendorCode = "-",
                            VendorName = "-",
                            Merchandiser = "-",
                            Lgrade = "-",
                            ProfitCenter = "-",
                            ProfitCenterText = "-",
                            SalesType = "-",
                            SalesTypeText = "-"
                        }
                    });
                }

                if (result.StoreItemList != null)
                {
                    foreach (StoreItemList itemList in result.StoreItemList)
                    {
                        detailResult.Add(new StoreDetail()
                        {
                            ItemList = new StoreDetailItemList()
                            {
                                MaterialName = itemList.MaterialName,
                                Percent = itemList.Percent,
                                StartDate = itemList.StartDate,
                                EndDate = itemList.EndDate,
                                Material = itemList.Material
                            }
                        });
                    }
                }
                else
                {
                    detailResult.Add(new StoreDetail()
                    {
                        ItemList = new StoreDetailItemList()
                        {
                            MaterialName = "-",
                            Percent = 0,
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now,
                            Material = "-"
                        }
                    });
                }


                if (result.StoreEventList != null)
                {
                    foreach (StoreEventList eventList in result.StoreEventList)
                    {
                        detailResult.Add(new StoreDetail()
                        {
                            EventList = new StoreDetailEventList()
                            {
                                LayoutCode = eventList.LayoutCode,
                                LayoutName = eventList.LayoutName,
                                Revenue = eventList.Revenue
                            }
                        });
                    }
                }
                else
                {
                    detailResult.Add(new StoreDetail()
                    {
                        EventList = new StoreDetailEventList()
                        {
                            LayoutCode = "-",
                            LayoutName = "-",
                            Revenue = 0
                        }
                    });
                }
            }
            else
            {
                detailResult.Add(new StoreDetail()
                {
                    InfoList = new StoreDetailInfoList()
                    {
                        VendorCode = "-",
                        VendorName = "-",
                        Merchandiser = "-",
                        Lgrade = "-",
                        ProfitCenter = "-",
                        ProfitCenterText = "-",
                        SalesType = "-",
                        SalesTypeText = "-"
                    },
                    ItemList = new StoreDetailItemList()
                    {
                        MaterialName = "-",
                        Percent = 0,
                        StartDate = DateTime.Now,
                        EndDate = DateTime.Now,
                        Material = "-"
                    },
                    EventList = new StoreDetailEventList()
                    {
                        LayoutCode = "-",
                        LayoutName = "-",
                        Revenue = 0
                    }
                });
            }


            return detailResult;
        }

        public List<StoreDetail> QueryStoreDetail2InfoIn(string werks, string floor, string layoutCode, string selectDate)
        {

            QueryStoreDetailInfoInClient soapClient = new QueryStoreDetailInfoInClient();

            soapClient.ClientCredentials.UserName.UserName = System.Configuration.ConfigurationManager.AppSettings["SAP_WEBSERVICE_USERNAME"];
            soapClient.ClientCredentials.UserName.Password = System.Configuration.ConfigurationManager.AppSettings["SAP_WEBSERVICE_PASSWORD"];

            List<StoreDetail> detailResult = new List<StoreDetail>();

            if (layoutCode.Length > 6)
            {
                StoreDetailInfoByList2QueryMessage_sync param = new StoreDetailInfoByList2QueryMessage_sync()
                {
                    PlantCode = werks,
                    Floor = floor,
                    LayoutCode = layoutCode,
                    YearMonth = selectDate
                };

                StoreDetailInfoByList2ResponseMessage_sync result = soapClient.StoreDetailInfoByList2ElementsQueryResponse_In(param);



                if (result.StoreInfoList != null)
                {
                    foreach (StoreInfoList infoList in result.StoreInfoList)
                    {
                        detailResult.Add(new StoreDetail()
                        {
                            InfoList = new StoreDetailInfoList()
                            {
                                VendorCode = infoList.VendorCode,
                                VendorName = infoList.VendorName,
                                Merchandiser = infoList.Merchandiser,
                                Lgrade = (infoList.LGrade == null) ? "-" : infoList.LGrade,
                                ProfitCenter = infoList.ProfitCenter,
                                ProfitCenterText = infoList.ProfitCenterText,
                                SalesType = infoList.SalesType,
                                SalesTypeText = infoList.SalesTypeText
                            }
                        });
                    }
                }
                else
                {
                    detailResult.Add(new StoreDetail()
                    {
                        InfoList = new StoreDetailInfoList()
                        {
                            VendorCode = "-",
                            VendorName = "-",
                            Merchandiser = "-",
                            Lgrade = "-",
                            ProfitCenter = "-",
                            ProfitCenterText = "-",
                            SalesType = "-",
                            SalesTypeText = "-"
                        }
                    });
                }

                if (result.StoreItemList != null)
                {
                    foreach (StoreItemList itemList in result.StoreItemList)
                    {
                        detailResult.Add(new StoreDetail()
                        {
                            ItemList = new StoreDetailItemList()
                            {
                                MaterialName = itemList.MaterialName,
                                Percent = itemList.Percent,
                                StartDate = itemList.StartDate,
                                EndDate = itemList.EndDate,
                                Material = itemList.Material
                            }
                        });
                    }
                }
                else
                {
                    detailResult.Add(new StoreDetail()
                    {
                        ItemList = new StoreDetailItemList()
                        {
                            MaterialName = "-",
                            Percent = 0,
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now,
                            Material = "-"
                        }
                    });
                }


                if (result.StoreEventList != null)
                {
                    foreach (StoreEventList eventList in result.StoreEventList)
                    {
                        detailResult.Add(new StoreDetail()
                        {
                            EventList = new StoreDetailEventList()
                            {
                                LayoutCode = eventList.LayoutCode,
                                LayoutName = eventList.LayoutName,
                                Revenue = eventList.Revenue
                            }
                        });
                    }
                }
                else
                {
                    detailResult.Add(new StoreDetail()
                    {
                        EventList = new StoreDetailEventList()
                        {
                            LayoutCode = "-",
                            LayoutName = "-",
                            Revenue = 0
                        }
                    });
                }
            }
            else
            {
                detailResult.Add(new StoreDetail()
                {
                    InfoList = new StoreDetailInfoList()
                    {
                        VendorCode = "-",
                        VendorName = "-",
                        Merchandiser = "-",
                        Lgrade = "-",
                        ProfitCenter = "-",
                        ProfitCenterText = "-",
                        SalesType = "-",
                        SalesTypeText = "-"
                    },
                    ItemList = new StoreDetailItemList()
                    {
                        MaterialName = "-",
                        Percent = 0,
                        StartDate = DateTime.Now,
                        EndDate = DateTime.Now,
                        Material = "-"
                    },
                    EventList = new StoreDetailEventList()
                    {
                        LayoutCode = "-",
                        LayoutName = "-",
                        Revenue = 0
                    }
                });
            }

            return detailResult;
        }
    }
}
