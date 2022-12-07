using UnityEngine;

public class MoveGem : MonoBehaviour
{
    private MoveRoads moveRoads = new MoveRoads();
    private float _gemSpeedMove;
    
    private void Awake() {
        _gemSpeedMove = moveRoads._speedMove;
    }

    private void Update() {
        gameObject.transform.Translate(Vector3.left * _gemSpeedMove * Time.deltaTime, Space.World);
    }
}
