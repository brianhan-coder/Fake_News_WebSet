namespace CIronPy.Dto
{
    public class AdminDto
    {
        /// <summary>
        /// 主键编号
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string PassWord { get; set; }
        /// <summary>
        /// 状态默认0
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// 提交时间
        /// </summary>
        public DateTime SubmitTime { get; set; }
    }
}
