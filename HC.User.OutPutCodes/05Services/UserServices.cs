using HC.Common.Base.Services;
using HC.Common.Base.Base;
using HC.User.DB.Entitys;
using HC.User.DTO.Models;
using HC.User.IRepository;
using HC.User.IServices;

namespace HC.User.Services
{
	public class UserServices : BaseServices<User>, IUserServices
    {
        IUserRepository _UserRepository;
		public  UserServices(IUserRepository UserRepository)
        {
            _UserRepository =UserRepository;           
        }
	}
}
