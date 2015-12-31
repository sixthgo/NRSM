using Eland.NRSM.Core.Services;
using Eland.NRSM.Template.Dao;
using Formular.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain = Eland.NRSM.Core.Domain;

namespace Eland.NRSM.Template.Services
{
    public class CEOReportService : GenericService<Domain.CEOReport>, ICEOReportService
    {
        ICEOReportDao ceoreportDao { get { return genericDao as ICEOReportDao; } }

        public List<Domain.CEOReport> GetCEOReportPlan(string gubun, string group)
        {
            return ceoreportDao.GetCEOReportPlan(gubun, group);
        }
    }
}
