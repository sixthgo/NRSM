﻿using Eland.NRSM.Core.Domain;
using Eland.NRSM.Core.Services;
using Eland.NRSM.Template.MANAGEDAILYGRIN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eland.NRSM.Template.Services
{
    public class ManageDailyGrInService : IManageDailyGrInService
    {

        public List<DailyGrHead> GetDailyHeadList(string WERKS, DateTime GRDAT, string MATNR)
        {

            DailyGr100Response_sync respone = GetHeadList(WERKS, GRDAT, MATNR);
            
            List<DailyGrHead> dailyHeadList = new List<DailyGrHead>();

            DailyGrHead headDto = new DailyGrHead(); ;

            if (respone != null && respone.DailyGrHeadList != null && respone.DailyGrHeadList.Count() > 0)
            {
                headDto.Flag = respone.DailyGrHeadList[0].RCODE;
                headDto.ReturnMessage = respone.DailyGrHeadList[0].MESSG;
                headDto.GRDAT = respone.DailyGrHeadList[0].GRDAT;
                headDto.GRDATSpecified = true;
                headDto.LIFNR = respone.DailyGrHeadList[0].LIFNR;
                headDto.NAME1 = respone.DailyGrHeadList[0].NAME1;
                headDto.MAKTX = respone.DailyGrHeadList[0].MAKTX;
                headDto.PRICE = respone.DailyGrHeadList[0].PRICE;
                headDto.PRICESpecified = true;
                headDto.INPUT = respone.DailyGrHeadList[0].INPUT;
                headDto.INPUTSpecified = true;
                headDto.MATNR = respone.DailyGrHeadList[0].MATNR;
                headDto.MEINS = respone.DailyGrHeadList[0].MEINS;
                headDto.MENGE = respone.DailyGrHeadList[0].MENGE;
                headDto.MENGESpecified = true;
                headDto.MESSG = respone.DailyGrHeadList[0].MESSG;
                headDto.RCODE = respone.DailyGrHeadList[0].RCODE;
                headDto.WERKS = respone.DailyGrHeadList[0].WERKS;
                headDto.MACNT = respone.DailyGrHeadList[0].MACNT;
                headDto.MACNTSpecified = true;

                dailyHeadList.Add(headDto);
            }

            return dailyHeadList;
        }

        //public Message SaveDailyHeadList(List<DailyGrHead> list)
        //{
        //    ManageDailyGrInClient client = new ManageDailyGrInClient();

        //    client.ClientCredentials.UserName.UserName = System.Configuration.ConfigurationManager.AppSettings["SAP_WEBSERVICE_USERNAME"];
        //    client.ClientCredentials.UserName.Password = System.Configuration.ConfigurationManager.AppSettings["SAP_WEBSERVICE_PASSWORD"];

        //    DailyGr250Query_sync param = new DailyGr250Query_sync();

        //    DailyGrHeadList dto; //= new DailyGrHeadList();

        //    DailyGrHeadList[] headlist = new DailyGrHeadList[list.Count()];

        //    for (int i = 0; i < list.Count(); i++)
        //    {
        //        dto = new DailyGrHeadList()
        //        {
        //            MATNR = list[i].MATNR,
        //            INPUT = list[i].INPUT,
        //            INPUTSpecified = true,
        //            WERKS = list[i].WERKS,
        //            GRDAT = list[i].GRDAT,
        //            GRDATSpecified = true,
        //            LIFNR = list[i].LIFNR,
        //            MACNT = list[i].MACNT,
        //            MACNTSpecified = true,
        //            MAKTX = list[i].MAKTX,
        //            MEINS = list[i].MEINS,
        //            MENGE = list[i].MENGE,
        //            MENGESpecified = true,
        //            MESSG = list[i].MESSG,
        //            NAME1 = list[i].NAME1,
        //            PRICE = list[i].PRICE,
        //            PRICESpecified = true,
        //            RCODE = list[i].RCODE
        //        };
        //        headlist[i] = dto;
        //    }

        //    param.DailyGrHeadList = headlist;

        //    DailyGr250Response_sync respone = client.DailyGr250QueryResponse_In(param);



        //    Message message = new Message();

        //    if (respone != null && respone.DailyGrHeadList != null && respone.DailyGrHeadList.Count() > 0)
        //    {
        //        message.Flag = respone.DailyGrHeadList[0].RCODE;
        //        message.ReturnMessage = respone.DailyGrHeadList[0].MESSG;
        //    }

        //    return message;
        //}

        public DailyGr100Response_sync GetHeadList(string WERKS, DateTime GRDAT, string MATNR)
        {
            ManageDailyGrInClient client = new ManageDailyGrInClient();

            client.ClientCredentials.UserName.UserName = System.Configuration.ConfigurationManager.AppSettings["SAP_WEBSERVICE_USERNAME"];
            client.ClientCredentials.UserName.Password = System.Configuration.ConfigurationManager.AppSettings["SAP_WEBSERVICE_PASSWORD"];


            DailyGr100Query_sync param = new DailyGr100Query_sync();

            DailyGrHeadList[] headlist = new DailyGrHeadList[] { new DailyGrHeadList() { WERKS = WERKS, GRDAT = GRDAT, GRDATSpecified = true, MATNR = MATNR } };


            param.DailyGrHeadList = headlist;


            DailyGr100Response_sync respone = client.DailyGr100QueryResponse_In(param);

            return respone;
        }

        public Message SaveDailyHeadList(List<DailyGrItem> list)
        {
            ManageDailyGrInClient client = new ManageDailyGrInClient();

            client.ClientCredentials.UserName.UserName = System.Configuration.ConfigurationManager.AppSettings["SAP_WEBSERVICE_USERNAME"];
            client.ClientCredentials.UserName.Password = System.Configuration.ConfigurationManager.AppSettings["SAP_WEBSERVICE_PASSWORD"];

            DailyGr250Query_sync param = new DailyGr250Query_sync();

            DailyGrItemList dto; //= new DailyGrHeadList();

            DailyGrItemList[] itemList = new DailyGrItemList[list.Count()];
            DailyGrHeadList[] headList = new DailyGrHeadList[list.Count()];

            for (int i = 0; i < list.Count(); i++)
            {

                dto = new DailyGrItemList()
                {
                    MATNR = list[i].MATNR,
                    INPUT = list[i].INPUT,
                    INPUTSpecified = true
                };
                itemList[i] = dto;

                DailyGr100Response_sync headRespone = GetHeadList(list[i].WERKS, list[i].GRDAT, list[i].MATNR);
                headList[i] = headRespone.DailyGrHeadList[0];
            }

            param.DailyGrHeadList = headList;
            param.DailyGrItemList = itemList;

            DailyGr250Response_sync respone = client.DailyGr250QueryResponse_In(param);



            Message message = new Message();

            if (respone != null && respone.DailyGrHeadList != null && respone.DailyGrHeadList.Count() > 0)
            {
                message.Flag = respone.DailyGrHeadList[0].RCODE;
                message.ReturnMessage = respone.DailyGrHeadList[0].MESSG;
            }

            return message;
        }
    }
}