using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    IEnumerator _coroutine;
    [Header("player game score")]
    public ulong _gameScore;
    [Header("Score settings")]
    public float _addScoreCoolDown = 0.2f;
    public int _countAddedScore = 1;
    [SerializeField] private Text _textWidthGameScore;

    private void Start() {
        _coroutine = AddScore();
        StartCoroutine(_coroutine);
    }

    private IEnumerator AddScore(){
        while(true){
            _gameScore += (ulong)_countAddedScore;
            _textWidthGameScore.text = _gameScore.ToString();

            yield return new WaitForSeconds(_addScoreCoolDown);
        }
    }
}
