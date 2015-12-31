using Eland.NRSM.Core.Services;
using Eland.NRSM.Template.MANAGESALEPRICESENDIN;
using Formular.Core.Service;
using Formular.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain = Eland.NRSM.Core.Domain;

namespace Eland.NRSM.Template.Services
{
    public class ManageSalePriceSendInService : GenericService<Domain.Message>, IManageSalePriceSendInService
    {
         public Domain.Message SaveBarCode(string plantCode, string barCode, string ztype)
         {
             ManageSalePriceSendInClient client = new ManageSalePriceSendInClient();

             client.ClientCredentials.UserName.UserName = System.Configuration.ConfigurationManager.AppSettings["SAP_WEBSERVICE_USERNAME"];
             client.ClientCredentials.UserName.Password = System.Configuration.ConfigurationManager.AppSettings["SAP_WEBSERVICE_PASSWORD"];

             SalePriceSendQuery_sync param = new SalePriceSendQuery_sync();

             param.MATNR = barCode;
             param.WERKS = plantCode;
             param.ZTYPE = ztype;

             Domain.Message dto = new Domain.Message();

             SalePriceSendResponse_sync respone = client.SalePriceSendQueryResponse_In(param);

             if (respone != null)
             {
                 dto.Flag = respone.Flag;
                 dto.ReturnMessage = respone.ReturnMessage;
             }


             return dto;
         }
    }
}
