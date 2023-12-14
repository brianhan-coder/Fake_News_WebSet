using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIronPy.Common
{
    public class IdGeneratorHelper
    {
        private int SnowFlakeWorkerId = 0;

        private Snowflake snowflake;

        private static readonly IdGeneratorHelper instance = new IdGeneratorHelper();

        private IdGeneratorHelper()
        {
            snowflake = new Snowflake(SnowFlakeWorkerId, 0, 0);
        }
        public static IdGeneratorHelper Instance
        {
            get
            {
                return instance;
            }
        }
        public long GetId()
        {
            return snowflake.NextId();
        }
        /// <summary>
        /// Yitter算法解决雪花64长度大于js的数值长度
        /// </summary>
        /// <returns></returns>
        public static long GetYitterNextId()
        {
            return YitterSnowFlake.Instance.NextId();
        }
    }
}
