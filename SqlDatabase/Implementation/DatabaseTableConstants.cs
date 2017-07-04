using SqlDatabase.Interfaces;

namespace SqlDatabase.Implementation
{
    public class DatabaseTableConstants : IDatabaseTableConstants
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
Name varchar(50) PRIMARY KEY,
DataType varchar(50) NOT NULL,
Value varchar(50))";

        private string _createPredicatesTable =
@"CREATE TABLE Predicates (
Object varchar(50),
Subject varchar(50),
Relationship varchar(50),
PRIMARY KEY (Object, Subject),
FOREIGN KEY (Object) REFERENCES Entities (Name),
FOREIGN KEY (Subject) REFERENCES Entities (Name))";

    }
}
