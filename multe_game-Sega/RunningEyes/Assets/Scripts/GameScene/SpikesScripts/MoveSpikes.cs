using UnityEngine;

public class MoveSpikes : MonoBehaviour
{
    private MoveRoads moveRoads = new MoveRoads();
    private float _spikeSpeedMove;
    
    private void Awake() {
        _spikeSpeedMove = moveRoads._speedMove;
    }

    private void Update() {
        gameObject.transform.Translate(Vector3.left * _spikeSpeedMove * Time.deltaTime, Space.World);
    }
}
