using UnityEngine;

public class MainHeroDragging : MonoBehaviour
{
    private Vector3 _newPlayerPosition;
    [SerializeField] private float _speed = 5f;

    private void OnMouseDrag() {
        _newPlayerPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        transform.position = Vector3.MoveTowards(transform.position, new Vector3(_newPlayerPosition.x, _newPlayerPosition.y, 0), _speed * Time.deltaTime);
    }
}