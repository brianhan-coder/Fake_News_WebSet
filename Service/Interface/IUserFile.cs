using CIronPy.Dto;

namespace CIronPy.Service.Interface
{
    public interface IUserFile
    {
        int Add(UserFileDto user);
        int Update(UserFileDto user);
        int Delete(long id);
        void DeleteAll();
        UserFileDto GetFirst(string name);
        List<UserFileDto> GetAll();
        List<UserFileDto> GetUserList(int page, int limit, ref int total, string uid, string author, string submittime);
    }
}
