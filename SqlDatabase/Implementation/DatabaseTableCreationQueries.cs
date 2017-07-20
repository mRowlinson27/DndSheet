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

        public string CreatePredicatesTrigger
        {
            get { return _createPredicateTrigger; }
        }

        private string _createEntitiesTable = 
@"CREATE TABLE Entities (
Eid INTEGER PRIMARY KEY,
DataType VARCHAR(50) NOT NULL,
Value VARCHAR(50));";

        private string _createPredicatesTable =
@"CREATE TABLE Predicates (
Subject INTEGER,
Relationship INTEGER,
Object INTEGER,
PRIMARY KEY (Object, Relationship, Subject),
FOREIGN KEY (Object) REFERENCES Entities (Eid),
FOREIGN KEY (Relationship) REFERENCES Entities (Eid),
FOREIGN KEY (Subject) REFERENCES Entities (Eid));";

        private string _createPredicateTrigger =
@"CREATE TRIGGER BeforePredicateInsert BEFORE INSERT ON Predicates  
BEGIN  
SELECT CASE   
	WHEN ((SELECT Datatype FROM Entities WHERE Eid = NEW.Subject AND (Datatype = 'Uri' OR Datatype = 'BlankNode')) ISNULL)   
		THEN RAISE(ABORT, 'Subject must be a Uri or BlankNode')
    WHEN ((SELECT Datatype FROM Entities WHERE Eid = NEW.Relationship AND Datatype = 'Predicate') ISNULL)   
		THEN RAISE(ABORT, 'Relationship must be a predicate')
    WHEN ((SELECT Datatype FROM Entities WHERE Eid = NEW.Object AND (Datatype = 'Uri' OR Datatype = 'BlankNode' OR Datatype = 'Constant')) ISNULL)   
		THEN RAISE(ABORT, 'Subject must be a Uri, BlankNode or Constant')
	END;
END;";

        private string _populateDefaultEntities =
@"INSERT INTO Entities (Eid, DataType, Value) VALUES
(1, 'Uri', 'Point'),
(2, 'Uri', 'Equation'),
(3, 'Uri', 'String'),
(4, 'Uri', 'Int'),
(5, 'Predicate', 'ObjectType'),
(6, 'Predicate', 'HasValue'),
(7, 'Predicate', 'HasEquation'),
(8, 'Predicate', 'ValueOf'),
(9, 'Predicate', 'Owns'),
(10, 'BlankNode', 'BlankNode1'),
(11, 'BlankNode', 'BlankNode2'),
(12, 'Constant', '14'),
(13, 'BlankNode', 'BlankNode3'),
(14, 'Constant', '1+1');";

        private string _populateDefaultPredicates =
@"INSERT INTO Predicates (Subject, Relationship, Object) VALUES
(10, 5, 1),
(10, 6, 11),
(11, 5, 4),
(11, 8, 12),
(10, 7, 13),
(13, 5, 2),
(13, 8, 14);";
    }
}
