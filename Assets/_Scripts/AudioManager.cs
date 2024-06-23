using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    [SerializeField] private AudioSource backgroundAudio;
    [SerializeField] private AudioSource clickAudio;
    [SerializeField] private AudioSource deathAudio;
    [SerializeField] private AudioSource itemsCollectAudio;
    [SerializeField] private AudioSource gameOverAudio;

    public void StopAudio(){
        backgroundAudio.Stop();
        clickAudio.Stop();
        deathAudio.Stop();
        itemsCollectAudio.Stop();
        gameOverAudio.Stop();
    }

    public void ClickButtonAudio(){
        clickAudio.Play();
    }

    public void BackgroundMusic(){
        backgroundAudio.Play();
    }

    public void DeathAudio(){
        deathAudio.Play();
    }

    public void ItemsCollectAudio(){
        itemsCollectAudio.Play();
    }

    public void GameOverAudio(){
        gameOverAudio.Play();
    }
}
