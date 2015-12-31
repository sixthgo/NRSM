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
    public class TemplateService : GenericService<Domain.Template>, ITemplateService
    {
        ITemplateDao templateDao { get { return genericDao as ITemplateDao; } }
        public void InsertMethod() {

        }
        public List<Domain.Template> Test(string loginId) {
            List<Domain.Template> result = new List<Domain.Template>();
            result = templateDao.SearchTemplate(loginId);

            return result;
        }
    }
}
