using HC.Common.Base;
using HC.Common.Base.Repository;
using SqlSugar;
using System.Collections.Generic;
using System.Threading.Tasks;
using HC.User.DB.Entitys;
using HC.User.IRepository;

namespace HC.User.Repository
{
	public class MenusRepository : BaseRepository<Menus>,IMenusRepository
	{
	    public MenusRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
	}
}

