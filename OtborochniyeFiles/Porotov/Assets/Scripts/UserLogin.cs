using System;
using System.Data;
using System.Collections;
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

    [SerializeField] private GameObject mainCamera;
    [SerializeField] private List<GameObject> usersWindows;

    private void Start() {
        connection = new SqliteConnection($"URI=file:{Application.dataPath}/DataBases/TestDataBase.db");
        dbcmd = connection.CreateCommand();

        connection.Open();



        connection.Close();
    }

    public void ClickForLoggin(){
        Login();
    }
    private void Login(){
        if (connection.State != ConnectionState.Open) {
            connection.Open();
        }


        var username = usernameField.text;
        var password = passwordField.text;

        Debug.Log(username);
        Debug.Log(password);

        dbcmd.CommandText = $"SELECT role FROM users WHERE username = 'SISA' AND password = '1234';";
        var result = dbcmd.ExecuteScalar();
        
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

        connection.Close();
    }



    enum Users {
        admin,
        teacher,
        student
    }
}
