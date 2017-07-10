﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlDatabase.API.DTO;
using SqlDatabase.Interfaces;

namespace SqlDatabase.Implementation
{
    public class SqlQueryConstructor : ISqlQueryConstructor
    {
        public string InsertIntoEntitiesQuery(List<TableEntity> tableEntities)
        {
            var sql = "INSERT INTO Entities (Eid, DataType, Value) VALUES";
            var firstLoop = true;
            foreach (var tableEntity in tableEntities)
            {
                if (firstLoop)
                {
                    firstLoop = false;
                }
                else
                {
                    sql += ",";
                }
                sql += "\r\n(" + tableEntity.Eid + ", '" + tableEntity.DataType + "', '" + tableEntity.Value + "')";
            }
            sql += ";";
            return sql;
        }

        public string UpdateEntitiesQuery(List<TableEntity> tableEntities)
        {
            var sqlPart1 = "UPDATE Entities\r\nSET DataType =\r\nCASE";
            var sqlPart2 = "";
            var sqlPart3 = "\r\nEND,\r\nValue =\r\nCASE";
            var sqlPart4 = "";
            var sqlPart5 = "\r\nEND\r\nWHERE\r\nEid IN (";
            var sqlPart6 = "";
            var sqlPart7 = ");";
            var firstLoop = true;
            foreach (var tableEntity in tableEntities)
            {
                sqlPart2 += "\r\nWHEN Eid = " + tableEntity.Eid + " THEN '" + tableEntity.DataType + "'";
                sqlPart4 += "\r\nWHEN Eid = " + tableEntity.Eid + " THEN '" + tableEntity.Value + "'";
                if (firstLoop)
                {
                    firstLoop = false;
                }
                else
                {
                    sqlPart6 += ", ";
                }
                sqlPart6 += tableEntity.Eid;
            }

            return sqlPart1 + sqlPart2 + sqlPart3 + sqlPart4 + sqlPart5 + sqlPart6 + sqlPart7;
        }

        public string InsertIntoPredicatesQuery(List<Triple> triples)
        {
            var sql = "INSERT INTO Predicates (Subject, Relationship, Object) VALUES";
            var firstLoop = true;
            foreach (var triple in triples)
            {
                if (firstLoop)
                {
                    firstLoop = false;
                }
                else
                {
                    sql += ",";
                }
                sql += "\r\n(" + triple.Subject + ", '" + triple.Relationship + "', " + triple.Object + ")";
            }
            sql += ";";
            return sql;
        }

        public string UpdatePredicatesQuery(List<Triple> triples)
        {
            var sqlPart1 = "UPDATE Predicates\r\nSET Relationship =\r\nCASE";
            var sqlPart2 = "";
            var sqlPart3 = "\r\nEND\r\nWHERE\r\n";
            var sqlPart4 = "";
            var sqlPart5 = ";";
            var firstLoop = true;
            foreach (var triple in triples)
            {
                sqlPart2 += "\r\nWHEN Subject = " + triple.Subject + " AND Object = " + triple.Object + " THEN '" + triple.Relationship + "'";
                if (firstLoop)
                {
                    firstLoop = false;
                }
                else
                {
                    sqlPart4 += " OR ";
                }
                sqlPart4 += "Subject = " + triple.Subject + " AND Object = " + triple.Object;
            }

            return sqlPart1 + sqlPart2 + sqlPart3 + sqlPart4 + sqlPart5;
        }

        public string FindAllEntitiesQuery()
        {
            return @"SELECT * FROM Entities;";
;        }

        public string FindEntitiesByEidQuery(List<int> eids)
        {
            var sql = "SELECT * FROM Entities\r\nWHERE ";

            var firstLoop = true;
            foreach (var eid in eids)
            {
                if (firstLoop)
                {
                    firstLoop = false;
                    sql += "Eid = " + eid;
                }
                else
                {
                    sql += " OR Eid = " + eid;
                }
            }

            return sql + ";";
        }

        public string FindEntitiesByDataTypeQuery(string dataType)
        {
            return "SELECT * FROM Entities\r\nWHERE DataType = '" + dataType + "';";
        }

        public string FindPredicatesAffectedBySubjectQuery(int subjectEid)
        {
            return "SELECT * FROM Predicates\r\nWHERE Subject = " + subjectEid + ";";
        }

        public string FindPredicatesAffectingObjectQuery(int objectEid)
        {
            return "SELECT * FROM Predicates\r\nWHERE Object = " + objectEid + ";";
        }
    }
}