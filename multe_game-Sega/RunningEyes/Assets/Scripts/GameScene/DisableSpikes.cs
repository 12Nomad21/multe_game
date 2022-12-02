using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableSpikes : MonoBehaviour
{
    [SerializeField] private float _edge = -23f;

    private void Update() {
        DisableSpikesMethod();
    }

    private void DisableSpikesMethod(){
        if(gameObject.transform.position.x < _edge){
            gameObject.SetActive(false);
        }
    }

    // private void DestroySpikes(){
    //     Destroy(gameObject);
    // }
}
