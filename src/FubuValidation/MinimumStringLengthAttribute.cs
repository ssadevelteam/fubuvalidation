using System.Collections.Generic;
using System.Reflection;
using FubuValidation.Fields;

namespace FubuValidation
{
    public class MinimumStringLengthAttribute : FieldValidationAttribute
    {
        private readonly int _length;

        public MinimumStringLengthAttribute(int length)
        {
            _length = length;
        }

        public int Length
        {
            get { return _length; }
        }

        public override IEnumerable<IFieldValidationRule> RulesFor(PropertyInfo property)
        {
            yield return new MinimumLengthRule(_length);
        }
    }
}