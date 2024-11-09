using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI highScoreText;
    private int finalscore;
    private int highscore;

    void Start()
    {
        finalscore = PlayerPrefs.GetInt("finalscore", 0);
        highscore = PlayerPrefs.GetInt("highscore", 0);
        ScoreText.text = finalscore.ToString();
        highScoreText.text = highscore.ToString();
    }
}
