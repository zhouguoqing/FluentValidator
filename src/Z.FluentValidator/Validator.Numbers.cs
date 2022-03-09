using System;
using System.Collections.Generic;
using System.Text;

namespace Z.FluentValidator
{
    public partial class Validator
    {
        #region " IsNotZero "

        public Validator IsNotZero(int value)
        {
            return IsNotZero("", value);
        }

        public Validator IsNotZero(string name, int value)
        {
            return IsNotZero(name, value, string.Format(MessageContainer.IsNotZeroMessage, name));
        }

        public Validator IsNotZero(string name, int value, string message)
        {
            // do the check
            if (value.IsNotZero())
            {
                return NoError();
            }
            else
            {
                return AddError(name, message);
            }
        }

        #endregion
    }
}
