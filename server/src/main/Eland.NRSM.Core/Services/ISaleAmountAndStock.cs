using Eland.NRSM.Core.Domain;
using Formular.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eland.NRSM.Core.Services
{
    public interface ISaleAmountAndStockService : IGenericService<SaleAmountAndStock>
    {
        SaleAmountAndStock GetSaleAmountAndStock(string gubun, string werks, string floor, string cu, string pu, string matnr, string wstaw, string pernr, DateTime date);
    }
}
