using UnityEngine;
using UnityEngine.UI;

public class ScoresManager : Singleton<ScoresManager>
{
    private int scores = 0;
    private Text scoreText;

    private const string HighScoreText = "HighScore"; 

    void Start (){
        scoreText = GetComponent<Text>();
    }

    public void AddScore(int score){
        scores += score;
        scoreText.text = scores.ToString();
    }

    public int GetScore(){
        return scores;
    }

    public void SaveHighScore(){
        int highScore = PlayerPrefs.GetInt(HighScoreText, 0);
        if(scores > highScore){
            PlayerPrefs.SetInt(HighScoreText, scores);
            PlayerPrefs.Save();
        }
    }

    public int GetHighScore(){
        return PlayerPrefs.GetInt(HighScoreText, 0);
    }
}
