using System;
using System.Collections.Generic;
using System.Text;

namespace Z.FluentValidator
{
    class ValueEnumValidator : IDataValidator
    {
        public bool Validate(string name, Type type, object data, object targetValue, out string tips)
        {
            tips = string.Empty;
            IValueEnum check = targetValue as IValueEnum;
            if (check == null)
                return true;
            return check.Validate(name, data, null, out tips);
        }
    }
}
