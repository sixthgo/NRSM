﻿using Eland.NRSM.Core.Services;
using Eland.NRSM.Template.MANAGEMANUALORDERIN;
using Formular.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain = Eland.NRSM.Core.Domain;

namespace Eland.NRSM.Template.Services
{
    public class ManageManualOrderInService : GenericService<Domain.ManualOrderMatInfo>, IManageManualOrderInService
    {
        public List<Domain.ManualOrderMatInfo> GetManualOrderMathInfo(string matnr, string werks)
        {
            ManageManualOrderInClient client = new ManageManualOrderInClient();

            client.ClientCredentials.UserName.UserName = System.Configuration.ConfigurationManager.AppSettings["SAP_WEBSERVICE_USERNAME"];
            client.ClientCredentials.UserName.Password = System.Configuration.ConfigurationManager.AppSettings["SAP_WEBSERVICE_PASSWORD"];

            ManualOrderMatInfoQuery_sync param = new ManualOrderMatInfoQuery_sync();

            param.MATNR = matnr;
            param.WERKS = werks;

            ManualOrderMatInfoResponse_sync respone = client.ManualOrderMatInfoQueryResponse_In(param);

            List<Domain.ManualOrderMatInfo> list = new List<Domain.ManualOrderMatInfo>();

            if (respone != null && respone.ManualOrderMatInfoList != null && respone.ManualOrderMatInfoList.Count() > 0)
            {
                foreach (ManualOrderMatInfoList p in respone.ManualOrderMatInfoList)
                {
                    list.Add(new Domain.ManualOrderMatInfo()
                    {
                        BEDAT = p.BEDAT,
                        BWSCL = p.BWSCL,
                        BWSCL_TX = p.BWSCL_TX,
                        LABST = p.LABST,
                        MAKTX = p.MAKTX,
                        MATNR = p.MATNR,
                        MATNR1 = p.MATNR1,
                        MEINS = p.MEINS,
                        MENGE = p.MENGE,
                        MTART = p.MTART,
                        NOCTL = p.NOCTL,
                        OPENPO = p.OPENPO,
                        PERNO = p.PERNO,
                        PLIFZ = p.PLIFZ,
                        TOQTY = p.TOQTY,
                        UMREZ = p.UMREZ,
                        WEKGR = p.WEKGR,
                        WERKS = p.WERKS,
                        YEQTY = p.YEQTY
                    });
                }

            }

            return list;

        }

        public Domain.Message SaveManualOrderMathInfo(Domain.ManualOrderMatInfo dto)
        {
            ManageManualOrderInClient client = new ManageManualOrderInClient();

            client.ClientCredentials.UserName.UserName = System.Configuration.ConfigurationManager.AppSettings["SAP_WEBSERVICE_USERNAME"];
            client.ClientCredentials.UserName.Password = System.Configuration.ConfigurationManager.AppSettings["SAP_WEBSERVICE_PASSWORD"];

            SaveManualOrderQuery_sync param = new SaveManualOrderQuery_sync();

            //param.ManualOrderMatInfoList = new ManualOrderMatInfoList();

            //param.ManualOrderMatInfoList.BEDAT = dto.BEDAT;
            //param.ManualOrderMatInfoList.BWSCL = dto.BWSCL;
            //param.ManualOrderMatInfoList.BWSCL_TX = dto.BWSCL_TX;
            //param.ManualOrderMatInfoList.LABST = dto.LABST;
            //param.ManualOrderMatInfoList.MAKTX = dto.MAKTX;
            //param.ManualOrderMatInfoList.MATNR = dto.MATNR;
            //param.ManualOrderMatInfoList.MATNR1 = dto.MATNR1;
            //param.ManualOrderMatInfoList.MEINS = dto.MEINS;
            //param.ManualOrderMatInfoList.MENGE = dto.MENGE;
            //param.ManualOrderMatInfoList.MTART = dto.MTART;
            //param.ManualOrderMatInfoList.NOCTL = dto.NOCTL;
            //param.ManualOrderMatInfoList.OPENPO = dto.OPENPO;
            //param.ManualOrderMatInfoList.PERNO = dto.PERNO;
            //param.ManualOrderMatInfoList.PLIFZ = dto.PLIFZ;
            //param.ManualOrderMatInfoList.TOQTY = dto.TOQTY;
            //param.ManualOrderMatInfoList.UMREZ = dto.UMREZ;
            //param.ManualOrderMatInfoList.WEKGR = dto.WEKGR;
            //param.ManualOrderMatInfoList.WERKS = dto.WERKS;
            //param.ManualOrderMatInfoList.YEQTY = dto.YEQTY;

            ManualOrderMatInfoList manulOrderDto = new ManualOrderMatInfoList();

            manulOrderDto.BEDAT = dto.BEDAT;
            manulOrderDto.BWSCL = dto.BWSCL;
            manulOrderDto.BWSCL_TX = dto.BWSCL_TX;
            manulOrderDto.LABST = dto.LABST;
            manulOrderDto.MAKTX = dto.MAKTX;
            manulOrderDto.MATNR = dto.MATNR;
            manulOrderDto.MATNR1 = dto.MATNR1;
            manulOrderDto.MEINS = dto.MEINS;
            manulOrderDto.MENGE = dto.MENGE;
            manulOrderDto.MTART = dto.MTART;
            manulOrderDto.NOCTL = dto.NOCTL;
            manulOrderDto.OPENPO = dto.OPENPO;
            manulOrderDto.PERNO = dto.PERNO;
            manulOrderDto.PLIFZ = dto.PLIFZ;
            manulOrderDto.TOQTY = dto.TOQTY;
            manulOrderDto.UMREZ = dto.UMREZ;
            manulOrderDto.WEKGR = dto.WEKGR;
            manulOrderDto.WERKS = dto.WERKS;
            manulOrderDto.YEQTY = dto.YEQTY;

            param.ManualOrderMatInfoList = manulOrderDto;


            Domain.Message returnDto = new Domain.Message();

            SaveManualOrderResponse_sync respone = client.SaveManualOrderQueryResponse_In(param);

            returnDto.Flag = respone.Flag;
            returnDto.ReturnMessage = respone.ReturnMessage;

            return returnDto;
        }

    }
}
