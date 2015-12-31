﻿using Eland.NRSM.Core.Services;
using Eland.NRSM.Template.MANAGESTOCKINSPECTIONCREATEIN;
using Eland.NRSM.Template.ZQUERYMATERIALPRICEINFO;
using Formular.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain = Eland.NRSM.Core.Domain;

namespace Eland.NRSM.Template.Services
{
    public class ManageStockInspectionCreateInService : GenericService<Domain.SaveStock>, IManageStockInspectionCreateInService
    {

        public String GetSaveStock(string MATNR, string WERKS)
        {
            QueryMaterialPriceInfoClient client = new QueryMaterialPriceInfoClient();

            client.ClientCredentials.UserName.UserName = System.Configuration.ConfigurationManager.AppSettings["SAP_WEBSERVICE_USERNAME"];
            client.ClientCredentials.UserName.Password = System.Configuration.ConfigurationManager.AppSettings["SAP_WEBSERVICE_PASSWORD"];

            MaterialPriceInfoQuery_sync param = new MaterialPriceInfoQuery_sync();

            param.MATNR = MATNR;
            param.WERKS = WERKS;

            MaterialPriceInfoResponse_sync respone = client.MaterialPriceInfoQueryResponse_In(param);

            string maktx = string.Empty;

            if (respone != null && respone.MaterialPriceList != null)
            {
                maktx = respone.MaterialPriceList.FirstOrDefault().MAKTX;
            }

            return maktx;
        }


        public Domain.Message SaveStock(Domain.SaveStock dto)
        {
            ManageStockInspectionCreateInClient client = new ManageStockInspectionCreateInClient();

            client.ClientCredentials.UserName.UserName = System.Configuration.ConfigurationManager.AppSettings["SAP_WEBSERVICE_USERNAME"];
            client.ClientCredentials.UserName.Password = System.Configuration.ConfigurationManager.AppSettings["SAP_WEBSERVICE_PASSWORD"];

            StockInspectionCreateQuery_sync param = new StockInspectionCreateQuery_sync();

            param.DISQTY = dto.DISQTY;
            param.DISQTYSpecified = true;
            param.DZLDAT = dto.DZLDAT;
            param.DZLDATSpecified = true;
            param.ERFNM = dto.ERFNM;
            param.FIXID = dto.FIXID;
            param.MATNR = dto.MATNR;
            param.WERKS = dto.WERKS;

            StockInspectionCreateResponse_sync respone = client.StockInspectionCreateQueryResponse_In(param);

            Domain.Message returnDto = new Domain.Message();

            if (respone != null)
            {
                returnDto.Flag = respone.Flag;
                returnDto.ReturnMessage = respone.ReturnMessage;
            }

            return returnDto;
        }
    }
}
