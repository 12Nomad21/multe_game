using UnityEngine;
using System.Collections.Generic;

public class GameOver : MonoBehaviour
{
    [SerializeField] private AudioSource _gameOverAudio;
    [SerializeField] private List<GameObject> _objectsForDisabling;
    BestScore bestScore = new BestScore();
    [SerializeField] private Animator _gameOverAnimation;
    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private AudioSource _backgroundGameAudio;
    public static bool _isGameOver = false;

    private void Start() {
        _isGameOver = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "obstacle"){
            GameOverEvent();
        }
    }

    private void GameOverEvent(){
        _isGameOver = true;

        _gameOverAudio.Play();
        DisableObjects();
        _gameOverAnimation.updateMode = AnimatorUpdateMode.UnscaledTime;
        _gameOverPanel.SetActive(true);
        _backgroundGameAudio.Pause();
        Time.timeScale = 0f;
        StopAllCoroutines();

        bestScore.WritingBestScore();
    }

    private void DisableObjects(){
        foreach(var o in _objectsForDisabling){
            o.SetActive(false);
        }
    }
}
