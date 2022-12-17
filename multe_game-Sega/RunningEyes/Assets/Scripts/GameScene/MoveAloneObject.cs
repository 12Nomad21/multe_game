using UnityEngine;

public class MoveAloneObject : MonoBehaviour
{
    private void Update() {
        gameObject.transform.Translate(Vector3.left * SpeedMoveSetting._speedMove * Time.deltaTime, Space.World);
    }
}
