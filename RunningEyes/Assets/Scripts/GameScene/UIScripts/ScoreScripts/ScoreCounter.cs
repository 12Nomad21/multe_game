using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    public static Coroutine _addScoreCoroutine;
    [Header("player game score")]
    public static ulong _gameScore;
    [Header("Score settings")]
    public float _addScoreCoolDown = 0.2f;
    public static int _countAddedScore = 1;
    [SerializeField] private Text _textWidthGameScore;
    [SerializeField] private float _boostingDuration = 30f;
    [SerializeField] private float _stepScoreBoosting = 0.01f;

    private void Start()
    {
        _gameScore = 0;
        _countAddedScore = 1;
        _addScoreCoroutine = StartCoroutine(AddScore());
        StartCoroutine(BoostingScoreCounting());
    }

    public IEnumerator AddScore()
    {
        while(true){
            _gameScore += (ulong)_countAddedScore;
            _textWidthGameScore.text = _gameScore.ToString();

            yield return new WaitForSeconds(_addScoreCoolDown);
        }
    }

    private IEnumerator BoostingScoreCounting()
    {
        while(_addScoreCoolDown > 0.01f){
            yield return new WaitForSeconds(_boostingDuration);
            _addScoreCoolDown -= _stepScoreBoosting;
        }

        _addScoreCoolDown = 0.01f;
    }
}
