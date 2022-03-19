using System;
using System.Collections.Generic;
using System.Text;

namespace Z.FluentValidator
{
    /// <summary>
    /// 非空校验
    /// </summary>
    public class NotNullValidator : IDataValidator<string>
    {
        public bool Validate(string name, string data, object targetValue, out string tips)
        {
            if (string.IsNullOrEmpty(data))
            {
                tips = name + " 值不能为空！";
                return false;
            }

            tips = string.Empty;

            return true;
        }
    }
}
