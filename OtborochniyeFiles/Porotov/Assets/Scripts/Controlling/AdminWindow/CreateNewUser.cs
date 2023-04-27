using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;
using TMPro;

public class CreateNewUser : MonoBehaviour
{
    private string connectionString;

    [SerializeField] private TMP_InputField userNameField;
    [SerializeField] private TMP_InputField passwordField;
    [SerializeField] private TMP_Dropdown roleDropdown;

    private void Start() {
        connectionString = $"URI=file:{Application.dataPath}/DataBases/TestDataBase.db";
    }
    public void Create(){
        string userRole = roleDropdown.options[roleDropdown.value].text;
        if(userRole.ToLower() == "студент"){
            userRole = "student";
        }
        else if(userRole.ToLower() == "преподователь"){
            userRole = "teacher";
        }

        using(IDbConnection connection = new SqliteConnection(connectionString)){
            connection.Open();

            using(IDbCommand command = connection.CreateCommand()){
                command.CommandText = $"INSERT INTO users(userName, password, role) VALUES ('{userNameField.text}', '{passwordField.text}', '{userRole}');";
                command.ExecuteNonQuery();
            }

            connection.Close();
        }
    }
}
