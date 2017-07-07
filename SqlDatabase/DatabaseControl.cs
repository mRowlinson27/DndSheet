using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlDatabase.API;
using SqlDatabase.API.DTO;
using SqlDatabase.Implementation;
using SqlDatabase.Interfaces;

namespace SqlDatabase
{
    public class DatabaseControl : IDatabaseControl
    {
        private readonly ISqLiteDatabaseBuilder _sqLiteDatabaseBuilder;
        private readonly ISqlQueryConstructor _sqlQueryConstructor;
        private ISqLiteDatabase _sqLiteDatabase;

        public DatabaseControl(ISqLiteDatabaseBuilder sqLiteDatabaseBuilder, ISqlQueryConstructor sqlQueryConstructor)
        {
            _sqLiteDatabaseBuilder = sqLiteDatabaseBuilder;
            _sqlQueryConstructor = sqlQueryConstructor;
        }

        public void Connect(string connection)
        {
            _sqLiteDatabase = _sqLiteDatabaseBuilder.Build(connection);
        }

        public void InsertIntoEntites(List<TableEntity> tableEntities)
        {
            var sql = _sqlQueryConstructor.InsertIntoEntitiesQuery(tableEntities);
            _sqLiteDatabase.ExecuteNonQuery(sql);
        }

        public void InsertIntoPredicates(List<Triple> triples)
        {
            var sql = _sqlQueryConstructor.InsertIntoPredicatesQuery(triples);
            _sqLiteDatabase.ExecuteNonQuery(sql);
        }

        public List<TableEntity> FindEntitiesByEid(List<string> eids)
        {
            var sql = _sqlQueryConstructor.FindEntitiesByEidQuery(eids);
            var nameValueCollections = _sqLiteDatabase.ExecuteReader(sql);

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

        public List<TableEntity> FindEntitiesByDatatype(string dataType)
        {
            var sql = _sqlQueryConstructor.FindEntitiesByDataTypeQuery(dataType);
            var nameValueCollections = _sqLiteDatabase.ExecuteReader(sql);

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

        public List<Triple> FindPredicatesAffectedBySubject(string subjectEid)
        {
            var sql = _sqlQueryConstructor.FindPredicatesAffectedBySubjectQuery(subjectEid);
            var nameValueCollections = _sqLiteDatabase.ExecuteReader(sql);

            var response = nameValueCollections.Select(nvc => new Triple
            {
                Subject = nvc.Get("Subject"),
                Relationship = nvc.Get("Relationship"),
                Object = nvc.Get("Object")
            });
            return response.ToList();
        }

        public List<Triple> FindPredicatesAffectingObject(string objectEid)
        {
            var sql = _sqlQueryConstructor.FindPredicatesAffectingObjectQuery(objectEid);
            var nameValueCollections = _sqLiteDatabase.ExecuteReader(sql);

            var response = nameValueCollections.Select(nvc => new Triple
            {
                Subject = nvc.Get("Subject"),
                Relationship = nvc.Get("Relationship"),
                Object = nvc.Get("Object")
            });
            return response.ToList();
        }
    }
}
