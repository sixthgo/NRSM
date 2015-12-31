﻿using Eland.NRSM.Core.Domain;
using Formular.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eland.NRSM.Core.Services
{
    public interface IFloorPlanCompareService
    {
        List<FloorPlanHistoryCompare> QueryHistoryIn(string werks, string floor, string firstDate, string secondDate);
    }
}