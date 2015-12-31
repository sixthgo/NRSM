﻿using Eland.NRSM.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eland.NRSM.Core.Services
{
    public interface IFloorHistoryRecordService
    {
        List<FloorHistoryRecord> QueryFloorRevenueIn(string werks, string floor, string selectDate);
    }
}