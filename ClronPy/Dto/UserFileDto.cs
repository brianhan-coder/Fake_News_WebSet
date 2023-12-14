namespace CIronPy.Dto
{
    public class UserFileDto
    {
        public long Id { get; set; }
        public int Uid { get; set; }
        public string Author { get; set; }
        public string Topic { get; set; }
        public string AccessLink { get; set; }
        public string FeatureLink { get; set; }
        public DateTime SubmitTime { get; set; }
    }
}
