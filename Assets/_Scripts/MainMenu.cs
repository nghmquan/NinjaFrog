using UnityEngine;

public class MainMenu: MonoBehaviour 
{
    public void ClickStartGame(){
        SceneLoader.Instance.ChangeScene(SceneName.PLAY_GAME);
        AudioManager.Instance.ClickButtonAudio();
    }

    public void ClickQuitGame(){
        Application.Quit();
        AudioManager.Instance.ClickButtonAudio();
        Debug.Log("Quit game");
    }
}