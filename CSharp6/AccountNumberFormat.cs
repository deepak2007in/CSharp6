using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp6
{
    class AccountNumberFormat : IFormatProvider, ICustomFormatter
    {
        private const int ACCT_LENGTH = 12;

        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            if(arg.GetType() != typeof(Int64))
            {
                try
                {
                    return HandleOtherFormats(format: format, argument: arg);
                }
                catch(FormatException e)
                {
                    throw new FormatException(string.Format("The format of '{0}' is invalid.", arg0: format), innerException: e);
                }
            }
            var ufmt = format.ToUpper(culture: CultureInfo.InvariantCulture);
            if (!(ufmt == "H" || ufmt == "I"))
            {
                try
                {
                    return HandleOtherFormats(format: format, argument: arg);
                }
                catch (FormatException e)
                {
                    throw new FormatException(string.Format("The format of '{0}' is invalid.", arg0: format), innerException: e);
                }
            }

            var result = arg.ToString();
            if (result.Length < ACCT_LENGTH)
            {
                result = result.PadLeft(ACCT_LENGTH, '0');
            }
            else
            {
                result = result.Substring(0, ACCT_LENGTH);
            }

            if(ufmt == "I")
            {
                return result;
            }
            else
            {
                return result.Substring(0, 5) + "-" + result.Substring(5, 3) + "-" + result.Substring(8);
            }
        }

        private string HandleOtherFormats(string format, object argument)
        {
            if(argument is IFormattable)
            {
                return ((IFormattable)argument).ToString(format, CultureInfo.CurrentCulture);
            }
            else if(argument != null)
            {
                return argument.ToString();
            }
            else
            {
                return string.Empty;
            }
        }

        public object GetFormat(Type formatType)
        {
            if(formatType == typeof(ICustomFormatter))
            {
                return this;
            }
            else
            {
                return null;
            }
        }
    }
}
