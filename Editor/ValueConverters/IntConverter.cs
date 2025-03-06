using System;

namespace GoogleSheetsUnity.Editor
{
    public class IntConverter : ValueConverter<int>
    {
        public override object Convert(string input, Type type)
        {
            int result = 0;
            int.TryParse(input, out result);
            return result;
        }
    }
}