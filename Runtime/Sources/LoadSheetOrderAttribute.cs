﻿using System;

namespace GoogleSheetsUnity
{
    [AttributeUsage(AttributeTargets.Class)]
    public class LoadSheetOrderAttribute : Attribute
    {
        public readonly int SheetOrder;

        public LoadSheetOrderAttribute(int sheetOrder)
        {
            SheetOrder = sheetOrder;
        }
    }
}