using UnityEngine;

public class DisableSpikes : MonoBehaviour
{
    [SerializeField] private float _edge = -23f;

    private void Update() {
        DisableSpike();
    }

    private void DisableSpike(){
        if(gameObject.transform.position.x < _edge){
            gameObject.SetActive(false);
        }
    }
}
