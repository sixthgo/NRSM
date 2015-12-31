﻿using Eland.NRSM.Core.Domain;
using Formular.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eland.NRSM.Core.Services
{
    public interface IFloorPlanService
    {
        List<FloorPlanData> SearchChangeHistoryDate(string werks, string floor, string fromDate, string toDate);

        List<ChangeHistoryData> SearchChangeHistoryData(string werks, string floor, string dates);

        List<FloorPlanFile> GetFloorPlanFile(string werks, string floor);

    }
}
