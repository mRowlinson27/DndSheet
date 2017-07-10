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

        public string PopulateDefaultEntities
        {
            get { return _populateDefaultEntities; }
        }

        public string PopulateDefaultPredicates
        {
            get { return _populateDefaultPredicates; }
        }

        private string _createEntitiesTable = 
@"CREATE TABLE Entities (
Eid INTEGER PRIMARY KEY,
DataType VARCHAR(50) NOT NULL,
Value VARCHAR(50));";

        private string _createPredicatesTable =
@"CREATE TABLE Predicates (
Subject INTEGER,
Relationship VARCHAR(50),
Object INTEGER,
PRIMARY KEY (Object, Subject),
FOREIGN KEY (Object) REFERENCES Entities (Eid),
FOREIGN KEY (Subject) REFERENCES Entities (Eid));";

        private string _populateDefaultEntities =
@"INSERT INTO Entities (Eid, DataType, Value) VALUES
(0, 'Head', 'Page1'),
(1, 'GraphNode', ''),
(2, 'GraphNode', ''),
(3, 'GraphNode', ''),
(4, 'String', 'Character Details'),
(5, 'String', 'Ability Scores'),
(6, 'String', 'Str');";

        private string _populateDefaultPredicates =
@"INSERT INTO Predicates (Subject, Relationship, Object) VALUES
(0, 'Has', 1),
(0, 'Has', 2),
(1, 'Has', 3),
(1, 'Has', 4),
(2, 'Has', 4);";
    }
}
