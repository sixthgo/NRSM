using Eland.NRSM.Core.Domain;
using Formular.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eland.NRSM.Core.Services
{
    // [ING]
    public interface IOrderProposalService
    {
        List<OrderProposal> GetOrderProposal(string ekorg, string ekgrp, string werks, string bedat, string perno, string ztype);
    }
}
