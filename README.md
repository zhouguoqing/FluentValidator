# FluentValidator
A powerful fluent validator

The framework provides a large number of commonly used parameter validity verification capabilities Net application. At present, Apis such as null, equal to, not equal to, exceeding the maximum value, less than the minimum value, within the enumeration range, password, mailbox, mobile phone number, time and date verification are supported. At the same time, exception prompt information when verification fails is supported.

The framework supports flexible customization of verification rules

This framework supports Net 6 and Net core 3.1 and NET Framework 4.7.2

Demo Code

```cs
Validator validator = new Validator();
validator.IsNotNull(null).WithMessage("Parameter is null");
validator.IsNotNull(null).WithMessage("Parameter is null").ThrowValidationException("Ex-0001");

validator.IsNot(()=>
            {
                return 1 == 2;
            }).WithMessage("1!=2");
validator.IsNot(() =>
            {
                return 1 == 2;
            }).WithMessage("1!=2").ThrowValidationException("Ex-0002"); ;

```