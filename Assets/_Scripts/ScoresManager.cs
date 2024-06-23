using UnityEngine.UI;

public class ScoresManager : Singleton<ScoresManager>
{
    private int scores = 0;
    private Text scoreText;

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
}
