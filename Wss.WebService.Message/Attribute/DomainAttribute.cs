using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Wss.WebService.Message.Attribute
{
    public class DomainAttribute:ValidationAttribute
    {
        public IEnumerable<string> Values { get; private set; }

        public DomainAttribute(string value)
        {
            this.Values = new string[] { value };
        }
        public override bool IsValid(object value)
        {
            return this.Values.Any(i => value.ToString() == i);
        }

        public override string FormatErrorMessage(string name)
        {
            string[] values = this.Values.Select(
                value => string.Format("'{0}'", value)).ToArray();
            return string.Format(base.ErrorMessageString, name,
                string.Join(",", values));
        }
    }
}
