using System;
using System.Collections.Generic;
using System.Text;

namespace Z.FluentValidator
{
    /// <summary>
    /// int类型取值范围
    /// </summary>
    public class IntValueRange : ValueRange<int>
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
                if ((int)data < this.Min)
                {
                    tips = string.Format("{0} 值应大于：{1}，实际值为：{2}", name, this.Min, data);
                    return false;
                }
            }
            else
            {
                if ((int)data <= this.Min)
                {
                    tips = string.Format("{0} 值应大于：{1}，实际值为：{2}", name, this.Min, data);
                    return false;
                }
            }

            if (this.IsContainMaxValue == true)
            {
                if ((int)data > this.Max)
                {
                    tips = string.Format("{0} 值应小于：{1}，实际值为：{2}", name, this.Max, data);
                    return false;
                }
            }
            else
            {
                if ((int)data >= this.Max)
                {
                    tips = string.Format("{0} 值应小于：{1}，实际值为：{2}", name, this.Max, data);
                    return false;
                }
            }

            return true;
        }
    }
}
