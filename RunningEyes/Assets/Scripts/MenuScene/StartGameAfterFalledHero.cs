using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameAfterFalledHero : MonoBehaviour
{
    [SerializeField] private float _edge;

    private void Update()
    {
        if(gameObject.transform.position.y <= _edge){
            SceneManager.LoadScene(2);
        }
    }
}
