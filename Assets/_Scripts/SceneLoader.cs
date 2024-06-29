using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : Singleton<SceneLoader>
{
    //Get name of scene game
   private string GetSceneName(SceneName sceneName){
        switch(sceneName){
            case SceneName.MAIN_MENU:
                return "MainMenu";
            case SceneName.PLAY_GAME:
                return "PlayGame";
            case SceneName.GAME_OVER:
                AudioManager.Instance.StopAudio();
                AudioManager.Instance.GameOverAudio();
                return "GameOver";        
        }
        return "";
   }

    //Change scene when load a new scene game
   public void ChangeScene(SceneName sceneName){
        string sceneNameSrting = GetSceneName(sceneName);

        if(sceneNameSrting == ""){
            Debug.LogError("Scene not available");
            return;
        }
        SceneManager.LoadScene(sceneNameSrting);
   }
}

public enum SceneName
{
    NONE = -1,
    MAIN_MENU = 0,
    PLAY_GAME = 1,
    GAME_OVER = 2,
}
