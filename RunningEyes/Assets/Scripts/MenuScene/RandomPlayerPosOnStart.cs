using UnityEngine;

public class RandomPlayerPosOnStart : MonoBehaviour
{
    [SerializeField] private float _maxHorizontalPosition = 10f;
    [SerializeField] private float _maxVerticalPosition = 10f;

    private void Start()
    {
        Vector3 _position = new Vector3(Random.Range(-_maxHorizontalPosition, _maxHorizontalPosition), Random.Range(-_maxVerticalPosition, _maxVerticalPosition), gameObject.transform.position.z);

        gameObject.transform.position = _position;
    }
}
