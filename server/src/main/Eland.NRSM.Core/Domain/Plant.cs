using Formular.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eland.NRSM.Core.Domain
{
    [Serializable]
    public class Plant : BaseDomain, IEquatable<Plant>
    {
        public string PlantCode { get; set; }
        public string PlantName { get; set; }

        public bool Equals( Plant p)
        {
            // Check whether the compared object is null. 
            if (Object.ReferenceEquals(p, null)) return false;

            // Check whether the compared object references the same data. 
            if (Object.ReferenceEquals(this, p)) return true;

            // Check whether the products' properties are equal. 
            return PlantCode.Equals(p.PlantCode) && PlantName.Equals(p.PlantName);
        }

        public override int GetHashCode()
        {

            // Get the hash code for the Name field if it is not null. 
            int hashProductName = PlantName == null ? 0 : PlantName.GetHashCode();

            // Get the hash code for the Code field. 
            int hashProductCode = PlantCode.GetHashCode();

            // Calculate the hash code for the product. 
            return hashProductName ^ hashProductCode;
        }

    }
}
