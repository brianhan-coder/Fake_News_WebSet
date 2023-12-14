using AutoMapper;
using CIronPy.Dto;
using CIronPy.Service.Interface;
using SqlSugar;

namespace CIronPy.Service.Implement
{
    public class UserFile : IUserFile
    {
        private readonly SqlSugarClient _db;
        private readonly IMapper _mapper;

        public UserFile(SqlSugarClient db, IMapper mapper)
        {
            this._db = db;
            _mapper = mapper;
        }
        public int Add(UserFileDto user)
        {
            var item = _mapper.Map<Model.UserFile>(user);
           return _db.Insertable<Model.UserFile>(item).ExecuteCommand();   

            throw new NotImplementedException();
        }

        public int Delete(long id)
        {
            return _db.Deleteable<Model.UserFile>().Where(o => o.id == id).ExecuteCommand();
        }

        public void DeleteAll()
        {
            throw new NotImplementedException();
        }

        public List<UserFileDto> GetAll()
        {
            var list = _db.Queryable<Model.UserFile>().ToList();
            return _mapper.Map<List<UserFileDto>>(list);
        }
        public List<UserFileDto> GetUserList(int page, int limit, ref int total,string uid,string author,string submittime)
        {
            var exp = Expressionable.Create<Model.UserFile>();
            if(!string.IsNullOrEmpty(uid))
            {
                exp.And(o => o.uid == int.Parse(uid));
            }
            if (!string.IsNullOrEmpty(author))
            {
                exp.And(o => o.author == author);
            }
            if (!string.IsNullOrEmpty(submittime))
            {
                exp.And(o => o.submittime == Convert.ToDateTime(submittime));
            }

            var list = _db.Queryable<Model.UserFile>().Where(exp.ToExpression()).ToPageList(page, limit, ref total).OrderByDescending(o => o.id).ToList();
            return _mapper.Map<List<UserFileDto>>(list);
        }

        public UserFileDto GetFirst(string name)
        {
            throw new NotImplementedException();
        }

        public int Update(UserFileDto user)
        {
            throw new NotImplementedException();
        }
    }
}
