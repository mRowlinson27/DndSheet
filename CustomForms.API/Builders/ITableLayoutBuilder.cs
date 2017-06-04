﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomForms.API.Builders
{
    public interface ITableLayoutBuilder
    {
        IDataEntryForm Create(List<List<string>> dataListofList);
        IDataEntryForm Apply(IDataEntryForm dataEntryForm, List<List<string>> dataListofList);
    }
}