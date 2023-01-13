using UnityEngine;
using UnityEngine.UI;

public class BestScore : MonoBehaviour
{
    [SerializeField] private Text _bestScoreText;
    private ulong _bestScore;

    private void Start()
    {
        ShowBestScore();
    }

    private void ShowBestScore()
    {
        _bestScore = ulong.Parse(PlayerPrefs.GetString("BestScore", _bestScore.ToString()));
        _bestScoreText.text = $"BEST SCORE: {_bestScore}";
    }

    public void WritingBestScore(){
        if(GameOver._isGameOver && ulong.Parse(PlayerPrefs.GetString("BestScore", _bestScore.ToString())) < ScoreCounter._gameScore){
            _bestScore = ScoreCounter._gameScore;
            PlayerPrefs.SetString("BestScore", _bestScore.ToString());
        }
    }
}
