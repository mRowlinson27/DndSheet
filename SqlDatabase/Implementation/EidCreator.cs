using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlDatabase.API;
using SqlDatabase.Interfaces;
using Utilities.API;

namespace SqlDatabase.Implementation
{
    public class EidCreator : IEidCreator
    {
        private readonly IDatabase _database;
        private readonly IMostlyFullSequence _mostlyFullSequence;

        public EidCreator(IDatabase database, IMostlyFullSequence mostlyFullSequence)
        {
            _database = database;
            _database.Connected += OnDatabaseConnected;
            _mostlyFullSequence = mostlyFullSequence;
        }

        private void OnDatabaseConnected(object sender, EventArgs eventArgs)
        {
            var eids = _database.FindAllEids();
            _mostlyFullSequence.Clear();
            _mostlyFullSequence.InsertMultiple(eids);
        }

        public int GetNextEid()
        {
            return _mostlyFullSequence.Add();
        }

        public List<int> GetNextXEids(int x)
        {
            return _mostlyFullSequence.AddMultiple(x);
        }

        public void DeleteEidAt(int index)
        {
            _mostlyFullSequence.DeleteAt(index);
        }

        public void DeleteMultipleEidsAt(List<int> indexes)
        {
            _mostlyFullSequence.DeleteMultipleAt(indexes);
        }
    }
}
