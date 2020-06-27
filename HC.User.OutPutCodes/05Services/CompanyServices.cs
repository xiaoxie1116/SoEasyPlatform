using HC.Common.Base.Services;
using HC.Common.Base.Base;
using HC.User.DB.Entitys;
using HC.User.DTO.Models;
using HC.User.IRepository;
using HC.User.IServices;

namespace HC.User.Services
{
	public class CompanyServices : BaseServices<Company>, ICompanyServices
    {
        ICompanyRepository _CompanyRepository;
		public  CompanyServices(ICompanyRepository CompanyRepository)
        {
            _CompanyRepository =CompanyRepository;           
        }
	}
}
