namespace CIronPy.Model
{
    public class UserFile
    {
        /// <summary>
        /// 主键编号
        /// </summary>
        public long id { get; set; }
        /// <summary>
        /// 用户Id
        /// </summary>
        public int uid { get; set; }
        /// <summary>
        /// 作者
        /// </summary>
        public string author { get; set; }    
        /// <summary>
        /// 话题
        /// </summary>
        public string topic { get; set; }    
        /// <summary>
        /// 用户地址
        /// </summary>
        public string accesslink { get; set; }
        /// <summary>
        /// 功能地址
        /// </summary>
        public string featurelink { get; set; }
        /// <summary>
        /// 提交时间
        /// </summary>
        public DateTime submittime { get; set; }

    }
}
