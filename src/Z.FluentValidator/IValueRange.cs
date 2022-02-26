using System;
using System.Collections.Generic;
using System.Text;

namespace Z.FluentValidator
{
    public interface IValueRange
    {
        /// <summary>
        /// 数据类型
        /// </summary>
        Type Type { get; }

        /// <summary>
        /// 最小值
        /// </summary>
        object MinValue { get; set; }

        /// <summary>
        /// 最大值
        /// </summary>
        object MaxValue { get; set; }

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
    /// 取值范围定义
    /// </summary>
    /// <typeparam name="T">类型</typeparam>
    public class ValueRange<T> : IValueRange
    {
        public Type Type => typeof(T);

        /// <summary>
        /// 最小值
        /// </summary>
        public object MinValue { get; set; }

        /// <summary>
        /// 最大值
        /// </summary>
        public object MaxValue { get; set; }

        /// <summary>
        /// 最小值
        /// </summary>
        public T Min
        {
            get { return (T)MinValue; }
            set { MinValue = value; }
        }

        /// <summary>
        /// 最大值
        /// </summary>
        public T Max
        {
            get { return (T)MaxValue; }
            set { MaxValue = value; }
        }

        /// <summary>
        /// 是否包含最小值比较
        /// </summary>
        public bool IsContainMinValue { get; set; }

        /// <summary>
        /// 是否包含最大值比较
        /// </summary>
        public bool IsContainMaxValue { get; set; }

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
            return true;
        }
    }
}
