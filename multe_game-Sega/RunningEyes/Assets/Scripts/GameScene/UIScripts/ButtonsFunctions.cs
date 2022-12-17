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

    private void Start()
    {
        _pausePanelAnim.updateMode = AnimatorUpdateMode.UnscaledTime;
    }

    public void StopContinueGame()
    {
        if(Time.timeScale > 0f){
            // _pausePanelAnim.SetBool("GamePaused", true);
            _pausePanel.SetActive(true);

            Time.timeScale = 0f;            
        }
        else{
            // _pausePanelAnim.SetBool("GamePaused", false);
            _pausePanel.SetActive(false);

            _smoothContinuationGame = SmoothContinuationGame();
            StartCoroutine(_smoothContinuationGame);
        }
    }

    private IEnumerator SmoothContinuationGame()
    {
        while(Time.timeScale < 1){
            Time.timeScale += _timeBoost;

            yield return new WaitForSeconds(_speedContinuationGame);
        }

        Time.timeScale = 1f;
        StopCoroutine(_smoothContinuationGame);
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }
}
