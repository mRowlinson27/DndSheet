using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlDatabase.API;
using SqlDatabase.API.DTO;
using SqlDatabase.Implementation;
using SqlDatabase.Interfaces;

namespace SqlDatabase
{
    public class Database : IDatabase
    {
        private readonly ISqLiteDatabaseBuilder _sqLiteDatabaseBuilder;
        private readonly ISqlQueryConstructor _sqlQueryConstructor;
        private ISqLiteDatabase _sqLiteDatabase;

        public Database(ISqLiteDatabaseBuilder sqLiteDatabaseBuilder, ISqlQueryConstructor sqlQueryConstructor)
        {
            _sqLiteDatabaseBuilder = sqLiteDatabaseBuilder;
            _sqlQueryConstructor = sqlQueryConstructor;
        }

        public void Connect(string connection)
        {
            _sqLiteDatabase = _sqLiteDatabaseBuilder.Build(connection);
        }

        public void InsertIntoEntities(List<TableEntity> tableEntities)
        {
            var sql = _sqlQueryConstructor.InsertIntoEntitiesQuery(tableEntities);
            _sqLiteDatabase.ExecuteNonQuery(sql);
        }

        public void InsertIntoPredicates(List<Triple> triples)
        {
            var sql = _sqlQueryConstructor.InsertIntoPredicatesQuery(triples);
            _sqLiteDatabase.ExecuteNonQuery(sql);
        }

        public List<TableEntity> FindAllEntities()
        {
            var sql = _sqlQueryConstructor.FindAllEntitiesQuery();
            var nameValueCollections = _sqLiteDatabase.ExecuteReader(sql);

            return CreateTableEntities(nameValueCollections);
        }

        public TableEntity FindEntityByEid(int eid)
        {
            return FindEntitiesByEid(new List<int> {eid}).First();
        }

        public List<TableEntity> FindEntitiesByEid(List<int> eids)
        {
            var sql = _sqlQueryConstructor.FindEntitiesByEidQuery(eids);
            var nameValueCollections = _sqLiteDatabase.ExecuteReader(sql);
            return CreateTableEntities(nameValueCollections);
        }

        public List<TableEntity> FindEntitiesByDatatype(string dataType)
        {
            var sql = _sqlQueryConstructor.FindEntitiesByDataTypeQuery(dataType);
            var nameValueCollections = _sqLiteDatabase.ExecuteReader(sql);
            return CreateTableEntities(nameValueCollections);
        }

        public List<Triple> FindTriplesAffectedBySubjectEid(int subjectEid)
        {
            var sql = _sqlQueryConstructor.FindTriplesAffectedBySubjectQuery(subjectEid);
            var nameValueCollections = _sqLiteDatabase.ExecuteReader(sql);
            return CreateTriples(nameValueCollections);
        }

        public List<Triple> FindTriplesAffectingObjectEid(int objectEid)
        {
            var sql = _sqlQueryConstructor.FindTriplesAffectingObjectQuery(objectEid);
            var nameValueCollections = _sqLiteDatabase.ExecuteReader(sql);
            return CreateTriples(nameValueCollections);
        }

        public List<int> FindEidsWithGivenObjectType(string objectType)
        {
            var sql = _sqlQueryConstructor.FindEidsWithGivenObjectTypeQuery(objectType);
            var nameValueCollections = _sqLiteDatabase.ExecuteReader(sql);
            var response = new List<int>();
            foreach (var nvc in nameValueCollections)
            {
                int subjectEid;
                int.TryParse(nvc.Get("Subject"), out subjectEid);
                response.Add(subjectEid);
            }
            return response;
        }

        public List<SqlData> FindObjectDetailsFromEid(int eid)
        {
            var sql = _sqlQueryConstructor.FindObjectDetailsFromEid(eid);
            var nameValueCollections = _sqLiteDatabase.ExecuteReader(sql);
            var response = new List<SqlData>();
            foreach (var nvc in nameValueCollections)
            {
                int subjectEid;
                int.TryParse(nvc.Get("Subject"), out subjectEid);
                response.Add(new SqlData()
                {
                    Eid = subjectEid,
                    Relationship = nvc.Get("Relationship"),
                    ExtendedRelationship = nvc.Get("ExtendedRelationship"),
                    Value = nvc.Get("Value")
                });
            }
            return response;
        }

        private List<TableEntity> CreateTableEntities(List<NameValueCollection> nameValueCollections)
        {
            var response = new List<TableEntity>();
            foreach (var nvc in nameValueCollections)
            {
                int eid;
                int.TryParse(nvc.Get("Eid"), out eid);
                var tableEntity = new TableEntity
                {
                    DataType = nvc.Get("DataType"),
                    Value = nvc.Get("Value"),
                    Eid = eid
                };
                response.Add(tableEntity);
            }
            return response;
        }

        private List<Triple> CreateTriples(List<NameValueCollection> nameValueCollections)
        {
            var response = new List<Triple>();
            foreach (var nvc in nameValueCollections)
            {
                int subjectEid, objectEid, relationshipEid;
                int.TryParse(nvc.Get("Subject"), out subjectEid);
                int.TryParse(nvc.Get("Relationship"), out relationshipEid);
                int.TryParse(nvc.Get("Object"), out objectEid);
                var triple = new Triple()
                {
                    Subject = subjectEid,
                    Relationship = relationshipEid,
                    Object = objectEid
                };
                response.Add(triple);
            }
            return response;
        }
    }
}
