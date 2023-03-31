using UnityEngine;

public class UseWeapon : MonoBehaviour
{
    [SerializeField] private Transform BladePosition;
    [SerializeField] private Camera cam;

    static public float PlayerWeaponRotation;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != collision.gameObject && (collision.gameObject.tag == "enemy" && Input.GetKey(KeyCode.Mouse0)))
        {
            Debug.Log("HIT");
        }
    }
    void FixedUpdate()
    {
        Vector3 directional = cam.ScreenToWorldPoint(Input.mousePosition) - BladePosition.position;
        directional.Normalize();
        PlayerWeaponRotation = Mathf.Atan2(directional.y, directional.x) * Mathf.Rad2Deg;
        BladePosition.transform.rotation = Quaternion.AngleAxis(PlayerWeaponRotation, Vector3.forward);
    }
}
