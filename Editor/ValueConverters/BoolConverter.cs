using System;

namespace GoogleSheetsUnity.Editor
{
    public class BoolConverter : ValueConverter<bool>
    {
        public override object Convert(string input, Type type)
        {
            bool result = false;
            bool.TryParse(input, out result);
            return result;
        }
    }
}