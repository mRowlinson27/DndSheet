﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataManipulation.API;
using DataManipulation.Interfaces;
using SqlDatabase.API.DTO;

namespace DataManipulation
{
    public class DatabaseAdaptor : IDatabaseAdaptor
    {
        public void Connect(string connection)
        {
            throw new NotImplementedException();
        }

        public List<IPoint> FindEntitiesByEid(List<string> eids)
        {
            throw new NotImplementedException();
        }

        public IPoint FindEntityByEid(string eid)
        {
            throw new NotImplementedException();
        }

        public List<IPoint> FindEntitiesByDatatype(string dataType)
        {
            throw new NotImplementedException();
        }
    }
}
