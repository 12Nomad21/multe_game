using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using TMPro;
using System;

public class CreateNewTask : MonoBehaviour
{
    private string connectionString;

    [SerializeField] private TMP_InputField taskDescription;
    [SerializeField] private Transform taskContainer;
    [SerializeField] private Transform taskPattern;

    private void Start() {
        connectionString = $"URI=file:{Application.dataPath}/DataBases/TestDataBase.db";
    }

    public void SaveTask(){
        Transform newTask = taskPattern;
        TMP_Text newTaskName = newTask.GetChild(0).GetComponent<TextMeshProUGUI>();

        int recordsNumberInTasksTable;

        using(IDbConnection connection = new SqliteConnection(connectionString)){
            connection.Open();

            using(IDbCommand insertTaskCommand = connection.CreateCommand()){
                insertTaskCommand.CommandText = $"INSERT INTO tasks(taskName, taskDescription) VALUES ('Задание номер {taskContainer.transform.childCount + 1}', '{taskDescription.text}');";
                insertTaskCommand.ExecuteNonQuery();
                insertTaskCommand.Dispose();
            }
            using(IDbCommand selectReacordsCommand = connection.CreateCommand()){
                selectReacordsCommand.CommandText = $"SELECT COUNT(*) FROM tasks;";
                recordsNumberInTasksTable = Convert.ToInt32(selectReacordsCommand.ExecuteScalar());
                Debug.Log(recordsNumberInTasksTable);
                selectReacordsCommand.Dispose();
            }
            using(IDbCommand makeAutoincrementIs1 = connection.CreateCommand()){
                makeAutoincrementIs1.CommandText = $"ALTER TABLE tasks AUTO_INCREMENT = 1;";
                makeAutoincrementIs1.ExecuteNonQuery();
                makeAutoincrementIs1.Dispose();
            }

            connection.Close();
        }

        while(taskContainer.childCount > 0){
            Destroy(taskContainer.GetChild(0));
        }

        for(int i = 0; i < recordsNumberInTasksTable; i++){
            string newTaskNameString = $"задание номер {taskContainer.transform.childCount + 1}";
            newTaskName.text = newTaskNameString;

            Instantiate(newTask, taskContainer);
        }

        UserLogin.MainCamera.transform.position = new Vector3(0, (int)UserLogin.Windows.teacherWindow * - 10, UserLogin.MainCamera.transform.position.z);
    }   
}