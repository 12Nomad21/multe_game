using UnityEngine;

public class FirstStartGame : MonoBehaviour
{
    private void Awake() {
        PlayerPrefs.DeleteAll();
    }
}
