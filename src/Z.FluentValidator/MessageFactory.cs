using System;
using System.Collections.Generic;
using System.Text;

namespace Z.FluentValidator
{
    public class MessageFactory
    {
        private MessageFactory()
        {
        }

        /// <summary>
        /// Provides the default language instance of the messages
        /// </summary>
        /// <returns></returns>
        public static MessageContainer Create()
        {
            return Create(LanguageCodes.en_GB);
        }

        public static MessageContainer Create(LanguageCodes code)
        {
            switch (code)
            {
                case LanguageCodes.en_GB:
                    return new MessageContainer()
                    {
                        IsNotNullMessage = "'{0}' cannot be null.",
                        IsNotNullOrEmptyMessage = "'{0}' cannot be null or empty.",
                        IsNotNullOrWhiteSpaceMessage = "'{0}' cannot be null or whitespace only.",
                        IsNotZeroMessage = "'{0}' cannot be zero.",
                        IsPasswordMessage = "'{0}' is not a valid password. Passwords must be 8 to 30 characters, at least on 1 uppercase letter, at least 1 lowercase letter and at least one number.",
                        IsMinLengthMessage = "'{0}' must be a at least {1} characters.",
                        IsMaxLengthMessage = "'{0}' must be {1} characters or less.",
                        IsExactLengthMessage = "'{0}' must be exactly {1} characters.",
                        IsBetweenLengthMessage = "'{0}' must be at least {1} and at most {2} characters.",
                        IsMessage = "'{0}' does not match the specified criteria.",
                        IsNotMessage = "'{0}' does not match the specified criteria.",
                        IsEmailMessage = "'{0}' is not a valid email address.",
                        IsRegexMessage = "'{0}' does not match the provided regular expression.",
                        IsMatchMessage = "'{0}' did not match the specified criteria.",
                        IsDateMessage = "'{0}' is not a valid date.",
                        IsRuleMessage = "'{0}' failed the provided business rule provided.",

                        // Dates
                        IsGreaterThanMessage = "'{0}' must be greater than '{1}'.",
                        IsGreaterThanOrEqualToMessage = "'{0}' must be greater than or equal to '{1}'.",
                        IsLessThanMessage = "'{0}' must be less than '{1}'.",
                        IsLessThanOrEqualToMessage = "'{0}' must be less than or equal to '{1}'.",
                        IsEqualToMessage = "'{0}' must be equal to '{1}'.",
                        IsBetweenInclusiveMessage = "'{0}' must be between '{1}' and '{2}' (inclusive).",
                        IsBetweenExclusiveMessage = "'{0}' must be between '{1}' and '{2}' (exclusive)."
                    };
                case LanguageCodes.zh_CN:
                    return new MessageContainer()
                    {
                        IsNotNullMessage = "'{0}'不能为Null.",
                        IsNotNullOrEmptyMessage = "'{0}'不能为Null或空.",
                        IsNotNullOrWhiteSpaceMessage = "'{0}'不能为Null或者只有空白字符.",
                        IsNotZeroMessage = "'{0}'不能是0.",
                        IsPasswordMessage = "'{0}'不是有效的密码. 密码必须是8到30个字符，至少一个大写字母,至少一个小写字母一个数字.",
                        IsMinLengthMessage = "'{0}'必须至少{1}个字符.",
                        IsMaxLengthMessage = "'{0}'必须最多{1}个字符.",
                        IsExactLengthMessage = "'{0}'必须只有{1}个字符.",
                        IsBetweenLengthMessage = "'{0}'必须至少{1}个,至多{2}个字符.",
                        IsMessage = "'{0}'不匹配指定的规则.",
                        IsNotMessage = "'{0}'不匹配指定的规则.",
                        IsEmailMessage = "'{0}'不匹配指定的规则.",
                        IsRegexMessage = "'{0}'不匹配提供的正则表达式.",
                        IsMatchMessage = "'{0}'不匹配指定的正则表达式.",
                        IsDateMessage = "'{0}'不是个有效的日期.",
                        IsRuleMessage = "'{0}'不匹配提供的业务逻辑规则.",

                        // Dates
                        IsGreaterThanMessage = "'{0}'必须大于'{1}'.",
                        IsGreaterThanOrEqualToMessage = "'{0}'必须大于等于'{1}'.",
                        IsLessThanMessage = "'{0}'必须小于'{1}'.",
                        IsLessThanOrEqualToMessage = "'{0}'必须小于等于'{1}'.",
                        IsEqualToMessage = "'{0}'必须等于'{1}'.",
                        IsBetweenInclusiveMessage = "'{0}'必须在 '{1}'和'{2}'范围内.",
                        IsBetweenExclusiveMessage = "'{0}'必须不在'{1}' and '{2}'范围内."
                    };
                default:
                    return Create(LanguageCodes.en_GB);
            }


        }
    }
}
