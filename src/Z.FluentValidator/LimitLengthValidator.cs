using System;
using System.Collections.Generic;
using System.Text;

namespace Z.FluentValidator
{
    public class LimitLengthValidator : IDataValidator<string>
    {
        /// <summary>
        /// 校验数据是否合法
        /// </summary>
        /// <param name="name">校验对象描述</param>
        /// <param name="data">待校验数据</param>
        /// <param name="targetValue">目标值</param>
        /// <param name="tips">校验不通过的提示信息</param>
        /// <returns>校验结果。true：通过，false：不通过</returns>
        public bool Validate(string name, string data, object targetValue, out string tips)
        {
            tips = string.Empty;
            if (data == null)
                return true;
            if (Convert.ToString(data).Length > (int)targetValue)
            {
                tips = name + "超出长度：" + (int)targetValue;
                return false;
            }

            return true;
        }
    }
}
