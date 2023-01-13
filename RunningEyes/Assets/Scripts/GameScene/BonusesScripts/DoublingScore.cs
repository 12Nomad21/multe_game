using UnityEngine;
using System.Collections;

public class DoublingScore : MonoBehaviour
{
    ShowBonusTime _showBonusTime = new ShowBonusTime();
    private Coroutine _doubleScoreCoroutine;
    [SerializeField] private Animator _bonus;
    [SerializeField] private float _doublingTime = 15f;
    public static bool _isDoublingScore;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            _bonus.SetTrigger("GettingBonus");
            _doubleScoreCoroutine = StartCoroutine(DoubledScore());
        }
    }

    private IEnumerator DoubledScore()
    {
        _isDoublingScore = true;
        BonusTimer._timerTime = _doublingTime;

        ScoreCounter._countAddedScore = 2;

        yield return new WaitForSeconds(_doublingTime);
        
        ScoreCounter._countAddedScore = 1;

        gameObject.SetActive(false);
    }
}
