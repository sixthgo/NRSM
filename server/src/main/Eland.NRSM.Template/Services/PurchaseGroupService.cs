using Eland.NRSM.Core.Services;
using Eland.NRSM.Template.Dao;
using Formular.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain = Eland.NRSM.Core.Domain;
using Eland.NRSM.Template.ZQUERYPOGDISPLAYIN;

namespace Eland.NRSM.Template.Services
{
    public class PurchaseGroupService : GenericService<Domain.PurchaseGroup>, IPurchaseGroupService
    {
        IPurchaseGroupDao dao { get { return genericDao as IPurchaseGroupDao; } }

        public List<Domain.PurchaseGroup> GetPurchaseGroup()
        {
            List<Domain.PurchaseGroup> result = new List<Domain.PurchaseGroup>();
            result = dao.GetAll();

            return result;
        }
    }
}
