using UnityEngine;

public class SignOut : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    public void Exit(){
        mainCamera.transform.position = new Vector3(0, 0, mainCamera.transform.position.z);
    }
}
