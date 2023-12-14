namespace CIronPy.Model
{
    public class Admin
    {
        /// <summary>
        /// 主键编号
        /// </summary>
        public long id { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string username { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string password { get; set; }
        /// <summary>
        /// 状态默认0
        /// </summary>
        public int status { get; set; }
        /// <summary>
        /// 提交时间
        /// </summary>
        public DateTime submittime { get; set; }

    }
}
