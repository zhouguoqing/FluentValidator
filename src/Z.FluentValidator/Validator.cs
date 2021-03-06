using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Z.FluentValidator
{
    [Serializable]
    public partial class Validator
    {
        #region " Constructor "


        /// <summary>
        /// Validate properties and types using this class
        /// </summary>
        public Validator()
        {
            Errors = new List<ValidationError>();
            MessageContainer = MessageFactory.Create();
        }

        public Validator(LanguageCodes code)
        {
            Errors = new List<ValidationError>();
            MessageContainer = MessageFactory.Create(code);
        }

        public Validator(MessageContainer container)
        {
            Errors = new List<ValidationError>();
            MessageContainer = container;
        }

        #endregion

        #region " Properties "

        public MessageContainer MessageContainer { get; set; }

        private ValidationError _LastError = null;

        /// <summary>
        /// 是否校验通过.e.g: True: 通过; False: 校验不通过
        /// </summary>
        public bool IsValid
        {
            get
            {
                return Errors.Count == 0;
            }
        }

        #endregion

        #region " Validation Errors "

        /// <summary>
        /// The full list of errors currently available
        /// </summary>
        public List<ValidationError> Errors { get; set; }

        /// <summary>
        /// Returns a list of errors with the specified name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public List<ValidationError> ErrorByName(string name)
        {
            return Errors.Where(o => o.Name == name).ToList();
        }

        /// <summary>
        /// This will return a unique set of Errors by Name and return the first instance of each error.
        /// </summary>
        public List<ValidationError> UniqueErrors
        {
            get
            {
                return Errors
                    .GroupBy(o => o.Name)
                    .Select(o => o.First())
                    .ToList();
            }
        }

        #endregion

        #region " Validation Methods "

        #region " IsNotNull "

        public Validator IsNotNull(object value)
        {
            return IsNotNull("", value);
        }

        public Validator IsNotNull(string name, object value)
        {
            return IsNotNull(name, value, string.Format(MessageContainer.IsNotNullMessage, name));
        }

        public Validator IsNotNull(string name, object value, string message)
        {
            // do the check
            if (value.IsNotNull())
            {
                return NoError();
            }
            else
            {
                return AddError(name, message);
            }
        }

        #endregion

        #region " Is "

        public Validator Is(Func<bool> func)
        {
            return Is("", func);
        }

        public Validator Is(string name, Func<bool> func)
        {
            return Is(name, func, MessageContainer.IsMessage);
        }

        public Validator Is(string name, Func<bool> func, string message)
        {
            // do the check
            if (func())
            {
                return NoError();
            }
            else
            {
                return AddError(name, message);
            }
        }

        #endregion

        #region " IsNot "

        public Validator IsNot(Func<bool> func)
        {
            return IsNot("", func);
        }

        public Validator IsNot(string name, Func<bool> func)
        {
            return IsNot(name, func, MessageContainer.IsNotMessage);
        }

        public Validator IsNot(string name, Func<bool> func, string message)
        {
            // do the check
            if (func())
            {
                return AddError(name, message);
            }
            else
            {
                return NoError();
            }
        }

        #endregion

        #region " IsRule "

        public Validator IsRule(IValidatorRule rule)
        {
            return IsRule("", rule);
        }

        public Validator IsRule(string name, IValidatorRule rule)
        {
            return IsRule(name, rule, MessageContainer.IsRuleMessage);
        }

        public Validator IsRule(string name, IValidatorRule rule, string message)
        {
            // do the check
            if (name.IsRule(rule))
            {
                return NoError();
            }
            else
            {
                return AddError(name, message);
            }
        }

        #endregion

        #endregion

        #region " WithMessage "

        /// <summary>
        /// 附加提示信息
        /// </summary>
        /// <param name="message">提示信息</param>
        /// <returns>校验器</returns>
        public Validator WithMessage(string message)
        {
            if (_LastError != null)
            {
                _LastError.Message = message;
            }

            return this;
        }

        #endregion

        #region " Helpers "

        public Validator AddError(string message)
        {
            return AddError("", message);
        }

        public Validator AddError(string name, string message)
        {
            ValidationError error = ValidationError.Create(name.EmptyStringIfNull(), message);
            Errors.Add(error);
            _LastError = error;

            return this;
        }

        public void ThrowValidationException(string exceptionCode)
        {
            StringBuilder sb = new StringBuilder();
            this.Errors.ForEach(i => {
                sb.Append(i.Name + i.Message);
            });
            var ex = new Exception(exceptionCode+sb.ToString());
            throw ex;
        }

        /// <summary>
        /// Throws an exception if errors are found 
        /// </summary>
        /// <returns>If no errors are found it returns an instance of the validator. </returns>
        public Validator ThrowValidationExceptionIfInvalid(string exceptionCode)
        {
            if (!IsValid)
            {
                StringBuilder sb = new StringBuilder();
                this.Errors.ForEach(i => {
                    sb.Append(i.Name + i.Message);
                });
                var ex = new Exception(exceptionCode+":"+sb.ToString());
                throw ex;
            }

            return this;
        }

        protected Validator NoError()
        {
            _LastError = null;
            return this;
        }

        #endregion
    }
}
