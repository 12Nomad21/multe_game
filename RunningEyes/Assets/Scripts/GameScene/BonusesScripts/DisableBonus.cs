using UnityEngine;

public class DisableBonus : MonoBehaviour
{
    [SerializeField] private float _edge = -500f;

    private void Update() {
        DisableGem();
    }

    private void DisableGem(){
        if(gameObject.transform.position.x < _edge){
            gameObject.SetActive(false);
        }
    }
}
