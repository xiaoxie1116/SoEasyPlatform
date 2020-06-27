using HC.Common.Base.Services;
using HC.Common.Base.Base;
using HC.User.DB.Entitys;
using HC.User.DTO.Models;
using HC.User.IRepository;
using HC.User.IServices;

namespace HC.User.Services
{
	public class OperationServices : BaseServices<Operation>, IOperationServices
    {
        IOperationRepository _OperationRepository;
		public  OperationServices(IOperationRepository OperationRepository)
        {
            _OperationRepository =OperationRepository;           
        }
	}
}
