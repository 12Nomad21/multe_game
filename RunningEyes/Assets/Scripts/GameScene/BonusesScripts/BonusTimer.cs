using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BonusTimer : MonoBehaviour
{
    private Coroutine _showTimeBonusRoutine;
    [SerializeField] private Text _timeText;
    public static float _timerTime;

    private void OnEnable() {
        _showTimeBonusRoutine = StartCoroutine(ShowTimeBonus(_timerTime));
    }

    private IEnumerator ShowTimeBonus(float time)
    {
        while(time > 0){
            _timeText.text = time.ToString();
            time--;

            yield return new WaitForSeconds(1f);
        }

        gameObject.SetActive(false);
    }
}
