using System;
using System.Collections.Generic;
using System.Text;

namespace Z.FluentValidator
{
    /// <summary>
    /// IDataValidator
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IDataValidator<T>
    {
        /// <summary>
        /// Validate
        /// </summary>
        /// <param name="name">name</param>
        /// <param name="data">data</param>
        /// <param name="targetValue">targetValue</param>
        /// <param name="tips">tips</param>
        /// <returns>true：通过，false：不通过</returns>
        bool Validate(string name, T data, object targetValue, out string tips);
    }

    /// <summary>
    /// 数据校验
    /// </summary>
    public interface IDataValidator
    {
        /// <summary>
        /// Validate
        /// </summary>
        /// <param name="name">name</param>
        /// <param name="type">type</param>
        /// <param name="data">data</param>
        /// <param name="targetValue">targetValue</param>
        /// <param name="tips">tips</param>
        /// <returns>true：通过，false：不通过</returns>
        bool Validate(string name, Type type, object data, object targetValue, out string tips);
    }
}
