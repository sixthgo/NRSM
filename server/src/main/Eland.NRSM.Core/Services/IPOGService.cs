﻿using Eland.NRSM.Core.Domain;
using Formular.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eland.NRSM.Core.Services
{
    public interface IPOGFirstCategoryService : IGenericService<POGFirstCategory>
    {
        List<POGFirstCategory> GetFirstCategory(string plantCode);
    }

    public interface IPOGThirdCategoryService : IGenericService<POGThirdCategory>
    {
        List<POGThirdCategory> GetThirdCategory(string plantCode, string firstCategory);
    }

    public interface IPOGColumnService : IGenericService<POGColumn>
    {
        List<POGColumn> GetColumn(string plantCode, string firstCategory, string thirdCategory);
    }

    public interface IPOGGoodsService : IGenericService<POGGoods>
    {
        POGGoods GetGoods(string werks, string matnr, string fircg, string thicg, string zcol, string uname);
    }
}
