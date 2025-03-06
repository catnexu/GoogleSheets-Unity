using System;

namespace GoogleSheetsUnity.Editor
{
    public class StringConverter : ValueConverter<string>
    {
        public override object Convert(string input, Type type)
        {
            return string.IsNullOrEmpty(input) ? string.Empty : input;
        }
    }
}