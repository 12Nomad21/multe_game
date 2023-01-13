using UnityEngine;

public class DisableGems : MonoBehaviour
{
    [SerializeField] private float _edge = -150f;

    private void Update() {
        DisableGem();
    }

    private void DisableGem(){
        if(gameObject.transform.position.x < _edge){
            gameObject.SetActive(false);
        }
    }
}
