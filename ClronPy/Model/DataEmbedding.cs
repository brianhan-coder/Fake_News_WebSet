namespace CIronPy.Model
{
    public class DataEmbedding
    {

        public long id { get; set; }

        public string title { get; set; }
        public string subject { get; set; }

        public string text { get; set; }

        public string data { get; set; }

        public string llm_response { get; set; }

        public bool fake_news { get; set; }

        public string embedding { get; set; }
    }
}
