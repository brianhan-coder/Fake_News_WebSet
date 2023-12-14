using CIronPy.Dto;

namespace CIronPy.Service.Interface
{
    public interface IDataEmbedding
    {
        int Add(List<DataEmbeddingDto> DataEmbedding);
        List<DataEmbeddingDto> GetDataEmbeddingList(int page, int limit, ref int total, string title, string text);
        int Delete(long id);
    }
}
