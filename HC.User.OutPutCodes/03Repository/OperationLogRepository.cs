using HC.Common.Base;
using HC.Common.Base.Repository;
using SqlSugar;
using System.Collections.Generic;
using System.Threading.Tasks;
using HC.User.DB.Entitys;

namespace HC.User.Repository
{
	public class OperationLogRepository : BaseRepository<OperationLog>,IOperationLogRepository
	{
	    public OperationLogRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
	}
}

