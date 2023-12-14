using CsvHelper.Configuration.Attributes;

namespace CIronPy.Dto
{
    public class DataEmbeddingDto
    {
        [Index(0)]
        public long id { get; set; }
        [Index(1)]
        public string title { get; set; }
        [Index(2)]
        public string text { get; set; }
        [Index(3)]
        public string subject { get; set; }
        [Index(4)]
        public string data { get; set; }
        [Index(5)]
        public string LLM_Response { get; set; }
        [Index(6)]
        public bool fake_news { get; set; }
        [Index(7)]
        public string embedding { get; set; }
    }
}
