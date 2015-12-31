using Eland.NRSM.Core.Services;
using Eland.NRSM.Template.MANAGEREALINVENTORYIN;
using Formular.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain = Eland.NRSM.Core.Domain;

namespace Eland.NRSM.Template.Services
{
    public class ManageRealInventoryInService : GenericService<Domain.RealInventory>, IManageRealInventoryInService
    {
        public List<Domain.RealInventory> GetRealInvertory(decimal lbst, string matrn, string mode, decimal rlabst, string uname, string werks)
        {
            ManageRealInventoryInClient client = new ManageRealInventoryInClient();

            client.ClientCredentials.UserName.UserName = System.Configuration.ConfigurationManager.AppSettings["SAP_WEBSERVICE_USERNAME"];
            client.ClientCredentials.UserName.Password = System.Configuration.ConfigurationManager.AppSettings["SAP_WEBSERVICE_PASSWORD"];

            RealInventoryQuery_sync param = new RealInventoryQuery_sync();

            param.LABST = lbst;
            param.MATNR = matrn;
            param.MODE = mode;
            param.RLABST = rlabst;
            param.UNAME = uname;
            param.WERKS = werks;


            RealInventoryResponse_sync respone = client.RealInventoryQueryResponse_In(param);

            List<Domain.RealInventory> realInventoryList = new List<Domain.RealInventory>();

            Domain.RealInventory dto = new Domain.RealInventory();

            if (respone != null)
            {
                dto.Flag = respone.Flag;
                dto.LABST = respone.LABST;
                dto.MAKTX = respone.MAKTX;
                dto.MATNR = respone.MATNR;
                dto.MSG = respone.MSG;
                dto.ReturnMessage = respone.ReturnMessage;
                dto.RLABST = respone.RLABST;
                dto.WERKS = respone.WERKS;
                dto.XDATS = respone.XDATS;
                dto.XSTAT = respone.XSTAT;
                dto.XTIMS = respone.XTIMS;
            }


            realInventoryList.Add(dto);

            return realInventoryList;
        }
    }
}
