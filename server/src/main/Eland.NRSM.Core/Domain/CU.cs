using Formular.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eland.NRSM.Core.Domain
{
    [Serializable]
    public class CU : BaseDomain, IEquatable<CU>
    {
        public string CUCode { get; set; }
        public string CUName { get; set; }

        public bool Equals(CU p)
        {
            // Check whether the compared object is null. 
            if (Object.ReferenceEquals(p, null)) return false;

            // Check whether the compared object references the same data. 
            if (Object.ReferenceEquals(this, p)) return true;

            // Check whether the products' properties are equal. 
            return CUCode.Equals(p.CUCode) && CUName.Equals(p.CUName);
        }

        public override int GetHashCode()
        {

            // Get the hash code for the Name field if it is not null. 
            int hashProductName = CUName == null ? 0 : CUName.GetHashCode();

            // Get the hash code for the Code field. 
            int hashProductCode = CUCode.GetHashCode();

            // Calculate the hash code for the product. 
            return hashProductName ^ hashProductCode;
        }
    }
}
