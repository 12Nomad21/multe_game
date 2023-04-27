using UnityEngine;
using System.Data;
using System.Collections.Generic;
using Mono.Data.Sqlite;
using System;

public class DataStorage : MonoBehaviour
{
    protected IDbConnection dataBaseConnection;
    protected IDbCommand command;
    protected IDataReader reader;

    private void Start() {
        dataBaseConnection = new SqliteConnection($"URI=file:{Application.dataPath}/DataBases/TestDataBase.db");
        command = dataBaseConnection.CreateCommand();
        reader = command.ExecuteReader();
    }
}
