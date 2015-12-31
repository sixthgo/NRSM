using Eland.NRSM.Core.Domain;
using Formular.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eland.NRSM.Core.Services
{
    public interface IFavoriteService : IGenericService<Favorite>
    {
        List<Favorite> GetUserFavorite(string loginId);
        void AddNewFavorite(string loginId, Favorite f);
        void DeleteFavorite(string loginId, string programCode);
    }
}
