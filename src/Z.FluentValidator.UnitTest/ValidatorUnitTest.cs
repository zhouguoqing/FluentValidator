using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Z.FluentValidator.UnitTest
{
    [TestClass]
    public class ValidatorUnitTest
    {
        [TestMethod]
        public void IsNullTest()
        {
            Validator validator = new Validator();
            validator.IsNotNull(null).WithMessage("Parameter is null");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void IsNullThrowExceptionTest()
        {
            Validator validator = new Validator();
            validator.IsNotNull(null).WithMessage("Parameter is null").ThrowValidationException("Ex-0001");
        }
    }
}
