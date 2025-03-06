using System;

namespace GoogleSheetsUnity.Editor
{
    public interface IValueConverter
    {
        Type Type { get; }
        
        object Convert(string input, Type type);
        string Convert(object input);
    }
}