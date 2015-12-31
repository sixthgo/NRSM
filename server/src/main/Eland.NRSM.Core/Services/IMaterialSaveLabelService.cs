﻿using Eland.NRSM.Core.Domain;
using Formular.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eland.NRSM.Core.Services
{
    public interface IMaterialSaveLabelService : IGenericService<MaterialSaveLabel>
    {
        Message SaveMaterialLabel(MaterialSaveLabel dto);
    }
}
