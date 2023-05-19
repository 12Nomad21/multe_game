using System.Data;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Mono.Data.Sqlite;

public class UserLogin : MonoBehaviour
{
    [SerializeField] private TMP_InputField usernameField;
    [SerializeField] private TMP_InputField passwordField;
    [SerializeField] private TMP_Text infoMessage;

    private string connectionString;

    [SerializeField] private Camera mainCamera;
    public static Camera MainCamera;
    [SerializeField] private List<GameObject> windows;
    public static List<GameObject> windowsListForOtherScripts;

    private void Start() {
        connectionString = $"URI=file:{Application.dataPath}/DataBases/TestDataBase.db";

        windowsListForOtherScripts = windows;
        MainCamera = mainCamera;
    }

    public void Login(){
        string username = usernameField.text;
        string password = passwordField.text;

        using(IDbConnection connection = new SqliteConnection(connectionString)){
            connection.Open();

            using(IDbCommand command = connection.CreateCommand()){
                string SQLQuery = $"SELECT role FROM users WHERE username = '{username}' AND password = '{password}';";
                command.CommandText = SQLQuery;

                using(IDataReader reader = command.ExecuteReader()){
                    if(reader.Read()){
                        infoMessage.text = "";

                        string role = reader.GetString(0);
                        Debug.Log($"role = {role}");
                        switch(role){
                            case "admin":
                                MainCamera.transform.position = new Vector3(0, (int)Windows.admin * -10, MainCamera.transform.position.z);
                                break;
                            case "teacher":
                                MainCamera.transform.position = new Vector3(0, (int)Windows.teacherWindow * -10, MainCamera.transform.position.z);
                                break;
                            case "student":
                                MainCamera.transform.position = new Vector3(0, (int)Windows.student * -10, MainCamera.transform.position.z);
                                break;
                        }
                    }
                    else{
                        infoMessage.text = $"Неверно введён логин или пароль";
                    }

                    reader.Close();
                }
            }

            connection.Close();
        }

        usernameField.text = "";
        passwordField.text = "";
    }

    public enum Windows {
        autorization,
        admin,
        addUser,
        teacherWindow,
        createTask,
        student,
        viewTheory,
        trainingWindow,
        testingWindow,
        viewResults
    }
}
