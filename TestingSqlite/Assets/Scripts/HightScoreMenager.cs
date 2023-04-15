using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;

public class HightScoreMenager : MonoBehaviour
{
    private string connectionString;
    IDbConnection dbConnection;
    IDbCommand dbCommand;
    IDataReader dbReader;

    private void Start() {
        dbConnection = new SqliteConnection("URI=file:" + Application.dataPath + "/DataBases/HightScoreDataBase.db");

        dbConnection.Open();

        dbCommand = dbConnection.CreateCommand();
        // dbReader = dbCommand.ExecuteReader();

        dbConnection.Close();

        // InsertScores("GiggaNigga", 100500);
        // GetScores();
        // Debug.Log(" ");
        // DeleteScore(1);
        // Debug.Log(" ");
    } 
    
    private void DeleteScore(int id){
        dbConnection.Open();

        dbCommand.CommandText = $"DELETE FROM HightScores WHERE PlayerID = \"{id}\"";

        dbCommand.ExecuteScalar();
        dbConnection.Close();
    }
    private void InsertScores(string name, int newScore){
        dbConnection.Open();

        dbCommand.CommandText = $"INSERT INTO HightScores(Name, Score) VALUES (\"{name}\", \"{newScore}\")";

        dbCommand.ExecuteScalar();
        dbConnection.Close();
    }

    private void GetScores(){
        dbConnection.Open();

        dbCommand.CommandText = "SELECT * FROM HightScores";
        while(dbReader.Read()){
            // hightScores.Add(new HightScore(reader.GetInt32(0), reader.GetInt32(2), reader.GetString(1), reader.GetDateTime(3)));
        }

        dbConnection.Close();
        dbReader.Close();
    }
}
