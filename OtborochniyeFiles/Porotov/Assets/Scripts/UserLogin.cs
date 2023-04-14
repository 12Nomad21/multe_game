using System.Data;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Mono.Data.Sqlite;

public class UserLogin : MonoBehaviour
{
    [SerializeField] private TMP_Text usernameField;
    [SerializeField] private TMP_Text passwordField;
    [SerializeField] private TMP_Text infoMessage;

    private IDbConnection connection;
    private IDbCommand dbcmd;
    private IDataReader reader;

    [SerializeField] private GameObject mainCamera;
    [SerializeField] private List<GameObject> usersWindows;

    private void Start() {
        connection = new SqliteConnection($"URI=file:{Application.dataPath}/DataBases/TestDataBase.db");
        dbcmd = connection.CreateCommand();

        connection.Open();

        reader = dbcmd.ExecuteReader();

        connection.Close();
    }

    public void ClickForLoggin(){
        Login();
    }
    private void Login(){
        connection.Open();

        var username = usernameField.text;
        var password = passwordField.text;

        dbcmd.CommandText = $"SELECT role FROM users WHERE username = '{username}' AND password = '{password}';";
        var result = dbcmd.ExecuteScalar();
        
        while (reader.Read()){
            Debug.Log(reader.GetString(1) + "-" + reader.GetString(2) + "-" + reader.GetString(3));
        }

        if(result != null){
            string role = result.ToString();

            switch(role){
                case "admin":
                    mainCamera.transform.position = usersWindows[(int)Users.admin].transform.position;
                    break;
                case "teacher":
                    mainCamera.transform.position = usersWindows[(int)Users.teacher].transform.position;
                    break;
                case "student":
                    mainCamera.transform.position = usersWindows[(int)Users.student].transform.position;
                    break;
            }
        }
        else{
            infoMessage.text = $"Неверно введён логин или пароль";
        }

        connection.Close();
    }

    enum Users {
        admin,
        teacher,
        student
    }
}
