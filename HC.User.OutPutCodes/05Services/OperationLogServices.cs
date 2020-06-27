using HC.Common.Base.Services;
using HC.Common.Base.Base;
using HC.User.DB.Entitys;
using HC.User.DTO.Models;
using HC.User.IRepository;
using HC.User.IServices;

namespace HC.User.Services
{
	public class OperationLogServices : BaseServices<OperationLog>, IOperationLogServices
    {
        IOperationLogRepository _OperationLogRepository;
		public  OperationLogServices(IOperationLogRepository OperationLogRepository)
        {
            _OperationLogRepository =OperationLogRepository;           
        }
	}
}
