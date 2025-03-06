using System;
using System.Collections.Generic;

namespace GoogleSheetsUnity.Editor
{
    public interface IRowConverter
    {
        List<object> Convert(List<List<object>> table, Type outObjectType);
    }
}