using UnityEngine;
using System.Data;
using System.Collections.Generic;
using Mono.Data.Sqlite;

public class DataStorage : MonoBehaviour
{
    private IDbConnection connection;
    private IDbCommand dbcmd;
    
    public DataStorage(string databaseName) {
        connection = new SqliteConnection($"URI=file:{Application.dataPath}/DataBases/{databaseName}");
    }

    private void Start() {
        dbcmd = connection.CreateCommand();
    }

    private void CreateTable(string tableName, string fields) {
        connection.Open();

        dbcmd.CommandText = $"CREATE TABLE {tableName} ({fields})";
        dbcmd.ExecuteNonQuery();

        connection.Close();
    }
    // public void SaveData(string tableName, string fields,) {
    //     connection.Open();
    //     dbcmd.CommandText = string.Format($"INSERT INTO {tableName} ({fields}) VALUES ('{name}', {score})");

    //     dbcmd.ExecuteNonQuery();

    //     connection.Close();
    // }
    public List<string> LoadNames() {
        List<string> names = new List<string>();
        dbcmd.CommandText = "SELECT name FROM myTable";

        IDataReader reader = dbcmd.ExecuteReader();
        while (reader.Read()) {
            names.Add(reader.GetString(0));
        }

        reader.Close();
        return names;
    }

}
