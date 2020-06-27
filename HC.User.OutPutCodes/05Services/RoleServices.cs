using HC.Common.Base.Services;
using HC.Common.Base.Base;
using HC.User.DB.Entitys;
using HC.User.DTO.Models;
using HC.User.IRepository;
using HC.User.IServices;

namespace HC.User.Services
{
	public class RoleServices : BaseServices<Role>, IRoleServices
    {
        IRoleRepository _RoleRepository;
		public  RoleServices(IRoleRepository RoleRepository)
        {
            _RoleRepository =RoleRepository;           
        }
	}
}
