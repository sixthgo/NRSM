﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Formular.Data;
using Domain = Eland.NRSM.Core.Domain;
using NHibernate.Transform;

namespace Eland.NRSM.Template.Dao
{
    public interface IFavoriteDao : IGenericDao<Domain.Favorite>
    {
        List<Domain.Favorite> GetAll(string loginId);
        void AddNewFavorite(string loginId, Domain.Favorite f);
        void DeleteFavorite(string loginId, string programCode);
    }

    public class FavoriteDao : HibernateGenericDao<Domain.Favorite>, IFavoriteDao
    {
        public List<Domain.Favorite> GetAll(string loginId)
        {
            var result = Session.GetNamedQuery("NRSM_FavoriteMenu_R01")
                .SetParameter("LoginId", loginId)
                .SetResultTransformer(Transformers.AliasToBean(typeof(Domain.Favorite)))
                .List<Domain.Favorite>();

            return result as List<Domain.Favorite>;
        }

        public void AddNewFavorite(string loginId, Domain.Favorite f)
        {
            string result;
            string emptyValue = " "; // string.Empty. empty valus is SP dependency..

            result = Session.GetNamedQuery("NRSM_FavoriteMenu_C01")
                 .SetParameter("Loginid", loginId)

                 .SetParameter("ProgramCode", f.ProgramCode)

                .SetParameter("Key1", f.Key1)
                .SetParameter("Value1", f.Value1)

                .SetParameter("Key2", f.Key2)
                .SetParameter("Value2", f.Value2)

                .SetParameter("Key3", f.Key3)
                .SetParameter("Value3", f.Value3)

                .SetParameter("Key4", f.Key4)
                .SetParameter("Value4", f.Value4)

                .SetParameter("Key5", f.Key5)
                .SetParameter("Value5", f.Value5)

                 //.SetParameter("Key1", string.IsNullOrEmpty(f.Key1) ? emptyValue : f.Key1)
                 //.SetParameter("Value1", string.IsNullOrEmpty(f.Value1) ? emptyValue : f.Value1)

                 //.SetParameter("Key2", string.IsNullOrEmpty(f.Key2) ? emptyValue : f.Key2)
                 //.SetParameter("Value2", string.IsNullOrEmpty(f.Value2) ? emptyValue : f.Value2)

                 //.SetParameter("Key3", string.IsNullOrEmpty(f.Key3) ? emptyValue : f.Key3)
                 //.SetParameter("Value3", string.IsNullOrEmpty(f.Value3) ? emptyValue : f.Value3)

                 //.SetParameter("Key4", string.IsNullOrEmpty(f.Key4) ? emptyValue : f.Key4)
                 //.SetParameter("Value4", string.IsNullOrEmpty(f.Value4) ? emptyValue : f.Value4)

                 //.SetParameter("Key5", string.IsNullOrEmpty(f.Key5) ? emptyValue : f.Key5)
                 //.SetParameter("Value5", string.IsNullOrEmpty(f.Value5) ? emptyValue : f.Value5)

                 .UniqueResult<string>();
            //int test = 0;
        }

        public void DeleteFavorite(string loginId, string programCode)
        {
            string result;
            result = Session.GetNamedQuery("NRSM_FavoriteMenu_D01")
                 .SetParameter("Loginid", loginId)
                 .SetParameter("ProgramCode", programCode)
                 .UniqueResult<string>();
        }
    }
}
