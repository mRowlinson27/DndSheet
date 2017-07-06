using SqlDatabase.Interfaces;

namespace SqlDatabase.Implementation
{
    public class DatabaseTableCreationQueries : IDatabaseTableCreationQueries
    {
        public string CreateEntitiesTable
        {
            get { return _createEntitiesTable; }
        }

        public string CreatePredicatesTable
        {
            get { return _createPredicatesTable; }
        }

        private string _createEntitiesTable = 
@"CREATE TABLE Entities (
Eid INTEGER PRIMARY KEY,
DataType VARCHAR(50) NOT NULL,
Value VARCHAR(50))";

        private string _createPredicatesTable =
@"CREATE TABLE Predicates (
Subject INTEGER,
Relationship VARCHAR(50),
Object INTEGER,
PRIMARY KEY (Object, Subject),
FOREIGN KEY (Object) REFERENCES Entities (Eid),
FOREIGN KEY (Subject) REFERENCES Entities (Eid))";

    }
}
