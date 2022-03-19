using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Z.FluentValidator
{
    public abstract class AbsDataValidatorStrategy<T> : IDataValidator<T>
    {
        /// <summary>
        /// 获取不能为空的字段
        /// </summary>
        /// <returns></returns>
        public virtual List<string> GetUnNullProperty()
        {
            return null;
        }

        /// <summary>
        /// 获取有特定长度限制的字段及长度限制
        /// </summary>
        /// <returns></returns>
        public virtual Dictionary<string, int> GetLimitLengthProperty()
        {
            return null;
        }

        /// <summary>
        /// 获取要校验取值范围的字段及校验定义
        /// </summary>
        /// <returns></returns>
        public virtual Dictionary<string, IValueEnum> GetValueEnumProperty()
        {
            return null;
        }

        /// <summary>
        /// 获取要校验取值范围的字段及校验定义
        /// </summary>
        /// <returns></returns>
        public virtual Dictionary<string, IValueRange> GetValueRangeProperty()
        {
            return null;
        }

        /// <summary>
        /// 校验数据是否合法
        /// </summary>
        /// <param name="name">校验对象描述</param>
        /// <param name="data">待校验数据</param>
        /// <param name="targetValue">目标值</param>
        /// <param name="tips">校验不通过的提示信息</param>
        /// <returns>校验结果。true：通过，false：不通过</returns>
        public virtual bool Validate(string name, T data, object targetValue, out string tips)
        {
            tips = string.Empty;
            bool isSuc = true;
            List<string> failedTips = new List<string>();

            if (CheckUnNullProperty(data, failedTips) == false)
                isSuc = false;
            if (CheckLimitLengthProperty(data, failedTips) == false)
                isSuc = false;
            if (CheckValueEnumProperty(data, failedTips) == false)
                isSuc = false;
            if (CheckValueRangeProperty(data, failedTips) == false)
                isSuc = false;

            StringBuilder sb = new StringBuilder(100);
            failedTips.ForEach(x => sb.AppendLine(x));
            tips = sb.ToString();

            return isSuc;
        }

        private bool CheckUnNullProperty(T data, List<string> failedTips)
        {
            bool isSuc = true;
            var unNullList = GetUnNullProperty();
            if (unNullList != null)
            {
                NotNullValidator checkor = new NotNullValidator();
                foreach (var item in unNullList)
                {
                    string nTips = string.Empty;
                    var value = GetValue<string>(data, item);
                    if (checkor.Validate(item, value, null, out nTips) == false)
                    {
                        isSuc = false;
                        failedTips.Add(nTips);
                    }
                }
            }

            return isSuc;
        }

        private bool CheckLimitLengthProperty(T data, List<string> failedTips)
        {
            bool isSuc = true;
            var unNullList = GetLimitLengthProperty();
            if (unNullList != null)
            {
                LimitLengthValidator checkor = new LimitLengthValidator();
                foreach (var item in unNullList)
                {
                    string nTips = string.Empty;
                    var value = GetValue<string>(data, item.Key);
                    if (checkor.Validate(item.Key, value, item.Value, out nTips) == false)
                    {
                        isSuc = false;
                        failedTips.Add(nTips);
                    }
                }
            }

            return isSuc;
        }

        private bool CheckValueEnumProperty(T data, List<string> failedTips)
        {
            bool isSuc = true;
            var unNullList = GetValueEnumProperty();
            if (unNullList != null)
            {
                ValueEnumValidator checkor = new ValueEnumValidator();
                foreach (var item in unNullList)
                {
                    string nTips = string.Empty;
                    var value = GetValue(typeof(T), data, item.Key);
                    if (checkor.Validate(item.Key, item.Value.Type, value, item.Value, out nTips) == false)
                    {
                        isSuc = false;
                        failedTips.Add(nTips);
                    }
                }
            }

            return isSuc;
        }

        private bool CheckValueRangeProperty(T data, List<string> failedTips)
        {
            bool isSuc = true;
            var unNullList = GetValueRangeProperty();
            if (unNullList != null)
            {
                ValueRangeValidator checkor = new ValueRangeValidator();
                foreach (var item in unNullList)
                {
                    string nTips = string.Empty;
                    var value = GetValue(typeof(T), data, item.Key);
                    if (checkor.Validate(item.Key, item.Value.Type, value, item.Value, out nTips) == false)
                    {
                        isSuc = false;
                        failedTips.Add(nTips);
                    }
                }
            }

            return isSuc;
        }

        private TValue GetValue<TValue>(T data, string property) where TValue : class
        {
            var memberInfo = typeof(T).GetProperties().FirstOrDefault(x => string.Equals(x.Name, property, StringComparison.OrdinalIgnoreCase));
            return memberInfo.GetValue((object)data) as TValue;
        }

        private object GetValue(Type type, object data, string property)
        {
            var memberInfo = type.GetProperties().FirstOrDefault(x => string.Equals(x.Name, property, StringComparison.OrdinalIgnoreCase));
            return memberInfo.GetValue(data);
        }
    }
}
