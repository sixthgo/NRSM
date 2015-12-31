using Eland.NRSM.Core.Services;
using Eland.NRSM.Template.Dao;
using Formular.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain = Eland.NRSM.Core.Domain;
using Eland.NRSM.Template.MANAGEORDEROFFERPROGRAMIN;

namespace Eland.NRSM.Template.Services
{
    // [ING]
    public class OrderProposalService : GenericService<Domain.OrderProposal>, IOrderProposalService
    {
        public List<Domain.OrderProposal> GetOrderProposal(string ekorg, string ekgrp, string werks, string bedat, string perno, string ztype)
        {
            throw new NotImplementedException();
        }
    }
}
