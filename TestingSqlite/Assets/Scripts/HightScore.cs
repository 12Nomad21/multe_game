using UnityEngine;
using TMPro;

public class HightScore : MonoBehaviour
{
    [SerializeField] private Transform playersRow;
    [SerializeField] private Transform rowsContainer;

    private TMP_Text nameText;
    private TMP_Text scoreText;

    private void Start() {
        nameText = playersRow.GetChild(0).GetComponent<TMP_Text>();
        scoreText = playersRow.GetChild(1).GetComponent<TMP_Text>();

        for(int i = 0; i <= 1000; i++){
            nameText.text = $"ababababa{i}";
            scoreText.text = $"{Random.Range(0, 999999)}";

            Instantiate(playersRow, rowsContainer);
        }
    }
}
