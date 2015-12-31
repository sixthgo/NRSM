using Formular.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eland.NRSM.Core.Domain
{
    [Serializable]
    public class Template : BaseDomain
    {
        public string ProgramCode { get; set; }
        public string Url { get; set; }
        public long Order { get; set; }

        public string Key1 { get; set; }
        public string Value1 { get; set; }

        public string Key2 { get; set; }
        public string Value2 { get; set; }

        public string Key3 { get; set; }
        public string Value3 { get; set; }

        public string Key4 { get; set; }
        public string Value4 { get; set; }

        public string Key5 { get; set; }
        public string Value5 { get; set; }

    }
}
