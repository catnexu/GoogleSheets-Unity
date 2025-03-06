using System.Collections.Generic;

namespace GoogleSheetsUnity
{
    public interface ISheetSet { }

    public interface ISheetSet<TData> : ISheetSet
    {
        void SetSheet(List<TData> value);
    }
}