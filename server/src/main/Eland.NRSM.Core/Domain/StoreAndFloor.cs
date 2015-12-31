using Formular.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Eland.NRSM.Core.Domain
{
    [Serializable]
    public class StoreAndFloor
    {
        public int floorIndex { get; set; }
        public int Id { get; set; }
        public string SectionCode { get; set; }
        public string SectionName { get; set; }
        //public string StoreFloorList { get; set; }
        public List<Floor> Floors { get; set; }
    }
    public class Floor
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
