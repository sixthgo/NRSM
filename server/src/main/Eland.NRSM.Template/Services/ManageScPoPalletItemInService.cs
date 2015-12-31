using Eland.NRSM.Core.Domain;
using Eland.NRSM.Core.Services;
using Eland.NRSM.Template.MANAGESCPOPALLETITEMIN;
using Formular.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eland.NRSM.Template.Services
{
    public class ManageScPoPalletItemInService:GenericService<ScPalletItem>,IManageScPoPalletItemInService
    {
        public List<ScPoItem> GetScPoItemList(string EBELN, string WERKS) {
            ManageScPoPalletItemInClient client = new ManageScPoPalletItemInClient();
            client.ClientCredentials.UserName.UserName = System.Configuration.ConfigurationManager.AppSettings["SAP_WEBSERVICE_USERNAME"];
            client.ClientCredentials.UserName.Password = System.Configuration.ConfigurationManager.AppSettings["SAP_WEBSERVICE_PASSWORD"];


            ScPoItemDpQuery_sync param = new ScPoItemDpQuery_sync();

            param.EBELN = EBELN;
            param.WERKS = WERKS;

            ScPoItemDpResponse_sync respone = client.ScPoItemDpQueryResponse_In(param);

            List<ScPoItem> list = new List<ScPoItem>();

            if (respone != null && respone.ScPoItemList != null && respone.ScPoItemList.Count() > 0)
            {
                foreach (ScPoItemList p in respone.ScPoItemList)
                {
                    list.Add(new ScPoItem()
                    {

                        EBELP=p.EBELP, 
                        LIFNR =p.LIFNR,
                        LOEVM =p.LOEVM,
                        MATNR =p.MATNR,
                        MEINS=p.MEINS,
                        MENGE=p.MENGE,
                        MENGESpecified=p.MENGESpecified,
                        NAME1 =p.NAME1,
                        NETPR =p.NETPR,
                        NETPRSpecified =p.NETPRSpecified,
                        NETWR =p.NETWR,
                        NETWRSpecified=p.NETWRSpecified,
                        TXZ01 =p.TXZ01,
                        UMREZ =p.UMREZ,
                        UMREZSpecified =p.UMREZSpecified
                       
                    });
                }

            }

            return list;
        }

        public List<ScPalletItem> GetScPalletItemList(string PALET, string WERKS, DateTime BUDAT)
        {

            ManageScPoPalletItemInClient client = new ManageScPoPalletItemInClient();
            client.ClientCredentials.UserName.UserName = System.Configuration.ConfigurationManager.AppSettings["SAP_WEBSERVICE_USERNAME"];
            client.ClientCredentials.UserName.Password = System.Configuration.ConfigurationManager.AppSettings["SAP_WEBSERVICE_PASSWORD"];


            ScPalletItemDpQuery_sync param = new ScPalletItemDpQuery_sync();

            param.PALET = PALET;
            param.WERKS = WERKS;
            param.BUDAT = BUDAT;
            param.BUDATSpecified = true;
            
            ScPalletItemDpResponse_sync respone = client.ScPalletItemDpQueryResponse_In(param);

            List<ScPalletItem> list = new List<ScPalletItem>();

            if (respone != null && respone.ScPalletItemList != null && respone.ScPalletItemList.Count() > 0)
            {
                foreach (ScPalletItemList p in respone.ScPalletItemList)
                {
                    list.Add(new ScPalletItem()
                    {

                        ARKTX = p.ARKTX,
                        BOXQTY = p.BOXQTY,
                        BOXQTYSpecified = p.BOXQTYSpecified,
                        LFIMG = p.LFIMG,
                        LFIMGC = p.LFIMGC,
                        LFIMGCSpecified = p.LFIMGCSpecified,
                        LFIMGD = p.LFIMGD,
                        LFIMGDSpecified = p.LFIMGDSpecified,
                        LFIMGSpecified = p.LFIMGSpecified,
                        MATNR = p.MATNR,
                        POSNR = p.POSNR,
                        UMREZ = p.UMREZ,
                        UMREZSpecified = p.UMREZSpecified,
                        VBELN = p.VBELN,
                        VRKME = p.VRKME

                    });
                }

            }

            return list;
        }


        public Message savescPoItemList(string EBELN, string WERKS, DateTime BUDAT, List<ScPoItem> scPoItemList) {
            ManageScPoPalletItemInClient client = new ManageScPoPalletItemInClient();

            client.ClientCredentials.UserName.UserName = System.Configuration.ConfigurationManager.AppSettings["SAP_WEBSERVICE_USERNAME"];
            client.ClientCredentials.UserName.Password = System.Configuration.ConfigurationManager.AppSettings["SAP_WEBSERVICE_PASSWORD"];


            ScPoItemGrQuery_sync param = new ScPoItemGrQuery_sync();

            param.EBELN = EBELN;
            param.WERKS = WERKS;
            param.BUDAT = BUDAT;
            param.BUDATSpecified = true;
            

            ScPoItemList[] list = new ScPoItemList[scPoItemList.Count];
            if (scPoItemList.Count > 0) {

                for(int i=0;i<scPoItemList.Count;i++){
                    ScPoItem p = scPoItemList[i];
                    ScPoItemList po = new ScPoItemList()
                    {

                        EBELP = p.EBELP,
                        LIFNR = p.LIFNR,
                        LOEVM = p.LOEVM,
                        MATNR = p.MATNR,
                        MEINS = p.MEINS,
                        MENGE = p.MENGE,
                        MENGESpecified = p.MENGESpecified,
                        NAME1 = p.NAME1,
                        NETPR = p.NETPR,
                        NETPRSpecified = p.NETPRSpecified,
                        NETWR = p.NETWR,
                        NETWRSpecified = p.NETWRSpecified,
                        TXZ01 = p.TXZ01,
                        UMREZ = p.UMREZ,
                        UMREZSpecified = p.UMREZSpecified

                    };
                    list[i] = po;
                }
            }

            param.ScPoItemList = list;

            ScPoItemGrResponse_sync respone = client.ScPoItemGrQueryResponse_In(param);

           Message returnDto = new Message();
            
            returnDto.Flag = respone.Flag;
            returnDto.ReturnMessage = respone.ReturnMessage;

            return returnDto;
        }

        public Message saveScPalletItemList(string PALET, string WERKS, DateTime BUDAT, List<ScPalletItem> ScPalletItemList)
        {

            ManageScPoPalletItemInClient client = new ManageScPoPalletItemInClient();

            client.ClientCredentials.UserName.UserName = System.Configuration.ConfigurationManager.AppSettings["SAP_WEBSERVICE_USERNAME"];
            client.ClientCredentials.UserName.Password = System.Configuration.ConfigurationManager.AppSettings["SAP_WEBSERVICE_PASSWORD"];


            ScPalletItemGrQuery_sync param = new ScPalletItemGrQuery_sync();

            param.PALET = PALET;
            param.WERKS = WERKS;
            param.BUDAT = BUDAT;
            param.BUDATSpecified = true;

            ScPalletItemList[] list = new ScPalletItemList[ScPalletItemList.Count];
            if (ScPalletItemList.Count > 0)
            {

                for (int i = 0; i < ScPalletItemList.Count; i++)
                {
                    ScPalletItem p = ScPalletItemList[i];
                    ScPalletItemList pall = new ScPalletItemList()
                    {

                        ARKTX = p.ARKTX,
                        BOXQTY = p.BOXQTY,
                        BOXQTYSpecified = p.BOXQTYSpecified,
                        LFIMG = p.LFIMG,
                        LFIMGC = p.LFIMGC,
                        LFIMGCSpecified = p.LFIMGCSpecified,
                        LFIMGD = p.LFIMGD,
                        LFIMGDSpecified = p.LFIMGDSpecified,
                        LFIMGSpecified = p.LFIMGSpecified,
                        MATNR = p.MATNR,
                        POSNR = p.POSNR,
                        UMREZ = p.UMREZ,
                        UMREZSpecified = p.UMREZSpecified,
                        VBELN = p.VBELN,
                        VRKME = p.VRKME
                    };
                    list[i] = pall;
                }
            }

            param.ScPalletItemList = list;

            ScPalletItemGrResponse_sync respone = client.ScPalletItemGrQueryResponse_In(param);

            Message returnDto = new Message();
            returnDto.Flag = respone.Flag;
            returnDto.ReturnMessage = respone.ReturnMessage;

            return returnDto;
        }

       
    }
}
