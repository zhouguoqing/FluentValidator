using System;
using System.Collections.Generic;
using System.Text;

namespace Z.FluentValidator
{
    public class DateTimeValueRange : ValueRange<DateTime>
    {
        /// <summary>
        /// 校验数据是否合法
        /// </summary>
        /// <param name="name">校验对象描述</param>
        /// <param name="data">待校验数据</param>
        /// <param name="targetValue">目标值</param>
        /// <param name="tips">校验不通过的提示信息</param>
        /// <returns>校验结果。true：通过，false：不通过</returns>
        public override bool Validate(string name, object data, object targetValue, out string tips)
        {
            tips = string.Empty;

            if (this.IsContainMinValue == true)
            {
                if ((DateTime)data < this.Min)
                {
                    tips = string.Format("{0} 值应大于：{1}，实际值为：{2}", name, this.Min.ToString("yyyy-MM-dd HH:mm:ss.fff"), ((DateTime)data).ToString("yyyy-MM-dd HH:mm:ss.fff"));
                    return false;
                }
            }
            else
            {
                if ((DateTime)data <= this.Min)
                {
                    tips = string.Format("{0} 值应大于：{1}，实际值为：{2}", name, this.Min.ToString("yyyy-MM-dd HH:mm:ss.fff"), ((DateTime)data).ToString("yyyy-MM-dd HH:mm:ss.fff"));
                    return false;
                }
            }

            if (this.IsContainMaxValue == true)
            {
                if ((DateTime)data > this.Max)
                {
                    tips = string.Format("{0} 值应小于：{1}，实际值为：{2}", name, this.Max.ToString("yyyy-MM-dd HH:mm:ss.fff"), ((DateTime)data).ToString("yyyy-MM-dd HH:mm:ss.fff"));
                    return false;
                }
            }
            else
            {
                if ((DateTime)data >= this.Max)
                {
                    tips = string.Format("{0} 值应小于：{1}，实际值为：{2}", name, this.Max.ToString("yyyy-MM-dd HH:mm:ss.fff"), ((DateTime)data).ToString("yyyy-MM-dd HH:mm:ss.fff"));
                    return false;
                }
            }

            return true;
        }
    }
}
