using System;
using System.Collections.Generic;
using System.Text;

namespace Z.FluentValidator
{
    public interface IValueEnum
    {
        Type Type { get; }

        /// <summary>
        /// 校验数据
        /// </summary>
        /// <param name="name">校验项目描述</param>
        /// <param name="data">待校验数据</param>
        /// <param name="targetValue">目标数据</param>
        /// <param name="tips">提示信息</param>
        /// <returns>校验结果。True：通过，false：失败</returns>
        bool Validate(string name, object data, object targetValue, out string tips);
    }

    /// <summary>
    /// 枚举值类型定义
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ValueEnum<T> : IValueEnum
    {
        public List<object> Values { get; set; }

        public Type Type => typeof(T);

        /// <summary>
        /// 校验数据是否合法
        /// </summary>
        /// <param name="name">校验对象描述</param>
        /// <param name="data">待校验数据</param>
        /// <param name="targetValue">目标值</param>
        /// <param name="tips">校验不通过的提示信息</param>
        /// <returns>校验结果。true：通过，false：不通过</returns>
        public virtual bool Validate(string name, object data, object targetValue, out string tips)
        {
            tips = string.Empty;

            if (Values == null)
                return true;

            if (Values.Contains(data))
                return true;
            else
            {
                tips = name + "的值不符合预期！";
                return false;
            }
        }
    }
}
