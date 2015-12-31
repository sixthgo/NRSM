using Eland.NRSM.Core.Services;
using Eland.NRSM.Template.MANAGESAVEMATERIALLABEL;
using Formular.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain = Eland.NRSM.Core.Domain;

namespace Eland.NRSM.Template.Services
{
    public class MaterialSaveLabelService : GenericService<Domain.MaterialSaveLabel>, IMaterialSaveLabelService
    {
        public Domain.Message SaveMaterialLabel(Domain.MaterialSaveLabel dto)
        {
            Domain.Message returnMessage = new Domain.Message();

            ManageSaveMaterialLabelClient client = new ManageSaveMaterialLabelClient();

            client.ClientCredentials.UserName.UserName = System.Configuration.ConfigurationManager.AppSettings["SAP_WEBSERVICE_USERNAME"];
            client.ClientCredentials.UserName.Password = System.Configuration.ConfigurationManager.AppSettings["SAP_WEBSERVICE_PASSWORD"];

            SaveMaterialLabelQuery_sync param = new SaveMaterialLabelQuery_sync();

            MaterialPriceList material = new MaterialPriceList()
            {
                BISMT = dto.bISMT,
                DATAB = dto.dATAB,
                DATABSpecified = true,
                DPTPR = dto.dPTPR,
                DPTPRSpecified = true,
                EAN11 = dto.eAN11,
                EKGRP = dto.eKGRP,
                GESME = dto.gESME,
                GESMESpecified = true,
                GUBUN = dto.gUBUN,
                GUBUN_T = dto.gUBUN_T,
                KONWA = dto.kONWA,
                LABST = dto.lABST,
                LABST_1 = dto.lABST_1,
                LABST_1Specified = true,
                LABSTSpecified = true,
                MAKTX = dto.mAKTX,
                MATNR = dto.mATNR,
                MATNR1 = dto.mATNR1,
                MEINS = dto.mEINS,
                NOCTL = dto.nOCTL,
                PERNO = dto.pERNO,
                PRICE = dto.pRICE,
                STPRC = dto.sTPRC,
                STPRCSpecified = true,
                TOQTY = dto.tOQTY,
                TOQTYSpecified = true,
                TOTAL = dto.tOTAL,
                TOTALSpecified = true,
                WERKS = dto.wERKS,
                ZCNT = dto.zCNT,
                ZCNTSpecified = true,
                ZFLAG = dto.zFLAG,
                ZFLAG_T = dto.zFLAG_T,
                ZRSUM = dto.zRSUM
            };

            param.MaterialPriceList = material;

            SaveMaterialLabelResponse_sync respone = client.SaveMaterialLabelQueryResponse_In(param);

            if (respone != null)
            {
                returnMessage.Flag = respone.Flag;
                returnMessage.ReturnMessage = respone.ReturnMessage;
            }

            return returnMessage;
        }
    }
}
