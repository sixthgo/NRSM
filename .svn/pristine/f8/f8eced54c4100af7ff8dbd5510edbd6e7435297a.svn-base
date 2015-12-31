using Eland.NRSM.Core.Domain;
using Formular.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eland.NRSM.Core.Services
{
    public interface IQueryMaterialPriceInfoService : IGenericService<MaterialPriceInfo>
    {
        MaterialPriceInfo GetMaterialPriceInforList(string werks, string matnr);

        List<MaterialPriceInfo> GetMaterialPriceInforListAll(string burks, string matnr);

        MaterialInforDetail GetMaterialInforDetail(MaterialPriceInfo materialPrice);
    }
}
