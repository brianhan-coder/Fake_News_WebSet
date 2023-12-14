using AutoMapper;
using CIronPy.Dto;
using CIronPy.Service.Interface;
using SqlSugar;
using System.Drawing.Printing;

namespace CIronPy.Service.Implement
{
    public class Admin : IAdmin
    {
        private readonly SqlSugarClient _db;
        private readonly IMapper _mapper;

        public Admin(SqlSugarClient db, IMapper mapper)
        {
            this._db = db;
            _mapper = mapper;
        }
        public int Add(AdminDto admin)
        {
            var item = _mapper.Map<Model.Admin>(admin);
            return _db.Insertable<Model.Admin>(item).ExecuteCommand();
        }

        public int Delete(long id)
        {
            return _db.Deleteable<Model.Admin>().Where(o => o.id == id).ExecuteCommand();
        }

        public void DeleteAll()
        {
            throw new NotImplementedException();
        }

        public List<AdminDto> GetAdminList(int page, int limit,ref int total)
        {
            var list = _db.Queryable<Model.Admin>().ToPageList(page, limit, ref total).OrderByDescending(o => o.id).ToList();
            return _mapper.Map<List<AdminDto>>(list);
        }
        public AdminDto GetFirst(long id)
        {
            var item = _db.Queryable<Model.Admin>().Where(o => o.id == id).First();
            return _mapper.Map<AdminDto>(item);
        }

        public AdminDto GetFirst(string admin)
        {
            throw new NotImplementedException();
        }

        public int Update(AdminDto admin)
        {
            var item = _mapper.Map<Model.Admin>(admin);
            return _db.Updateable<Model.Admin>(item).Where(o => o.id == item.id).ExecuteCommand();
        }
    }
}
