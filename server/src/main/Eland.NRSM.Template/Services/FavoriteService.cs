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
    public class FavoriteService : GenericService<Domain.Favorite>, IFavoriteService
    {
        IFavoriteDao favoriteDao { get { return genericDao as IFavoriteDao; } }

        public void InsertMethod()
        {

        }
        
        public List<Domain.Favorite> GetUserFavorite(string loginId)
        {
            List<Domain.Favorite> result = new List<Domain.Favorite>();
            result = favoriteDao.GetAll(loginId);

            return result;
        }

        public void AddNewFavorite( string loginId, Domain.Favorite f) {
            favoriteDao.AddNewFavorite(loginId, f);
        }

        public void DeleteFavorite(string loginId, string programCode)
        {
            favoriteDao.DeleteFavorite(loginId, programCode);
        }
    }
}
