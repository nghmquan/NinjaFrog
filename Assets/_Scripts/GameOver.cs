using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField] private Text scoreText;

    // Start is called before the first frame update
    void Start(){
        int finalScore = ScoresManager.Instance.GetScore();
        scoreText.text = finalScore.ToString();
    }

    public void ClickRestartGame(){
        SceneLoader.Instance.ChangeScene(SceneName.PLAY_GAME);
    }

    public void ClickMainMenu(){
        SceneLoader.Instance.ChangeScene(SceneName.MAIN_MENU);
    }

    public void ClickQuitGame(){
        Application.Quit();
        Debug.Log("Quit game");
    }
}
