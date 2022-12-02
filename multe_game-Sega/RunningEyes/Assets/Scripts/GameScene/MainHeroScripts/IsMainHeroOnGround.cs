using UnityEngine;

public class IsMainHeroOnGround : MonoBehaviour
{
    public static bool _mainHeroOnGround = false;

    private void OnCollisionStay2D(Collision2D other) {
        if(other.gameObject.tag == "road"){
            _mainHeroOnGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other) {
        if(other.gameObject.tag == "road"){
            _mainHeroOnGround = false;
        }
    }
}
