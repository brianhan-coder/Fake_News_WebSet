using AutoMapper;
using CIronPy.Dto;
using CIronPy.Model;
using CIronPy.Service.Interface;
using SqlSugar;

namespace CIronPy.Service.Implement
{
    public class DataEmbedding : IDataEmbedding
    {
        private readonly SqlSugarClient _db;
        private readonly IMapper _mapper;

        public DataEmbedding(SqlSugarClient db, IMapper mapper)
        {
            this._db = db;
            _mapper = mapper;
        }
        public int Add(List<DataEmbeddingDto> DataEmbedding)
        {
            var item = _mapper.Map<List<Model.DataEmbedding>>(DataEmbedding);
            return  _db.Insertable(item).ExecuteCommand();
        }
        public List<DataEmbeddingDto> GetDataEmbeddingList(int page, int limit, ref int total, string title, string text)
        {
            var exp = Expressionable.Create<Model.DataEmbedding>();
            if (!string.IsNullOrEmpty(title))
            {
                exp.And(o => o.title.Contains(title));
            }
            if (!string.IsNullOrEmpty(text))
            {
                exp.And(o => o.text.Contains(text));
            }
            var list = _db.Queryable<Model.DataEmbedding>().Where(exp.ToExpression()).ToPageList(page, limit, ref total).OrderByDescending(o => o.id).ToList();
            return _mapper.Map<List<DataEmbeddingDto>>(list);
        }
        public int Delete(long id)
        {
            return _db.Deleteable<Model.DataEmbedding>().Where(o => o.id == id).ExecuteCommand();
        }
    }
}
