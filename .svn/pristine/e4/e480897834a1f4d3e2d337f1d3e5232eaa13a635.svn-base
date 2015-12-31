using Eland.NRSM.Core.Domain;
using Formular.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eland.NRSM.Core.Services
{
    public interface IManageScPoPalletItemInService: IGenericService<ScPalletItem>
    {
       
        List<ScPoItem> GetScPoItemList(string EBELN, string WERKS);

        List<ScPalletItem> GetScPalletItemList(string PALET, string WERKS, DateTime BUDAT);


        Message savescPoItemList(string EBELN, string WERKS, DateTime BUDAT, List<ScPoItem> scPoItemList);

        Message saveScPalletItemList(string PALET, string WERKS, DateTime BUDAT, List<ScPalletItem> ScPalletItemList);
    }
}
