using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eland.NRSM.Core.Domain
{
    [Serializable]
    public class FloorHistoryRecordDetail
    {
        public decimal PastRevenue { get; set; }
        public decimal GrowthRate { get; set; }
        public decimal GoalSum { get; set; }
        public decimal AchieveRate { get; set; }
    }
}
