using HC.Common.Base.Services;
using HC.Common.Base.Base;
using HC.User.DB.Entitys;
using HC.User.DTO.Models;
using HC.User.IRepository;
using HC.User.IServices;

namespace HC.User.Services
{
	public class RoleMenuServices : BaseServices<RoleMenu>, IRoleMenuServices
    {
        IRoleMenuRepository _RoleMenuRepository;
		public  RoleMenuServices(IRoleMenuRepository RoleMenuRepository)
        {
            _RoleMenuRepository =RoleMenuRepository;           
        }
	}
}
