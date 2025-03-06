using System;

namespace GoogleSheetsUnity.Editor
{
    public abstract class ValueConverter<T> : IValueConverter
    {
        public Type Type => typeof(T);

        public abstract object Convert(string input, Type type);

        public virtual string Convert(object input) => ((T)input).ToString();
    }
}