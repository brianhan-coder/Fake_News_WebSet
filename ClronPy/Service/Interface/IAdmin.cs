using CIronPy.Dto;
using CIronPy.Model;

namespace CIronPy.Service.Interface
{
    public interface IAdmin
    {
        int Add(AdminDto admin);
        int Update(AdminDto admin);
        int Delete(long id);
        void DeleteAll();
        AdminDto GetFirst(long id);
        AdminDto GetFirst(string admin);
        
        List<AdminDto> GetAdminList(int page, int limit, ref int total);
    }
}
