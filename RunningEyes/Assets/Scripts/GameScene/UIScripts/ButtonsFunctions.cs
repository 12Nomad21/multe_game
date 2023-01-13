using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ButtonsFunctions : MonoBehaviour
{
    [Header("Animation settings")]
    [SerializeField] private Animator _pausePanelAnim;
    private IEnumerator _smoothContinuationGame;
    [SerializeField] private float _speedContinuationGame = 0.05f;
    [SerializeField] private float _timeBoost = 0.01f;
    [Header("Panel")]
    [SerializeField] private GameObject _pausePanel;
    [Header("Audio")]
    [SerializeField] private AudioSource _backgroundGameAudio;

    private void Start()
    {
        Time.timeScale = 1f;
        _pausePanelAnim.updateMode = AnimatorUpdateMode.UnscaledTime;
    }

    public void StopGame()
    {
        _pausePanel.SetActive(true);
        _pausePanelAnim.SetBool("GamePaused", true);
        _backgroundGameAudio.Pause();
        Time.timeScale = 0f;  
    }

    public void ContinueGame()
    {
        _pausePanelAnim.SetBool("GamePaused", false);
        _backgroundGameAudio.Play();

        _smoothContinuationGame = SmoothContinuationGame();
        StartCoroutine(_smoothContinuationGame);
    }

    private IEnumerator SmoothContinuationGame()
    {
        while(Time.timeScale < 1){
            Time.timeScale += _timeBoost;

            yield return new WaitForSeconds(_speedContinuationGame);
        }

        Time.timeScale = 1f;
        _pausePanel.SetActive(false);
        StopCoroutine(_smoothContinuationGame);
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(2);
    }
}
