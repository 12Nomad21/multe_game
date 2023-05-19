using UnityEngine;

public class OpenCreateTasksWindow : MonoBehaviour
{
    public void OpenWindowOfCreateTasks(){
        UserLogin.MainCamera.transform.position = new Vector3(0, (int)UserLogin.Windows.createTask * -10, UserLogin.MainCamera.transform.position.z);
    }
}
