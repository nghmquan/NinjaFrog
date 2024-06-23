using System.Collections;
using UnityEngine;

public class NinjaFrogLife : MonoBehaviour
{
    [SerializeField] private float delayBeforeGameOver = 1.5f;
    private NinjaFrogAnimation ninjaFrogAnimation;
    private NinjaFrogMovement ninjaFrogMovement;
    private LoopingBackground loopingBackground;

    private GameManager gameManager;

    // Start is called before the first frame update
    void Start(){
        gameManager = FindObjectOfType<GameManager>();
        ninjaFrogAnimation = GetComponent<NinjaFrogAnimation>();
        ninjaFrogMovement = GetComponent<NinjaFrogMovement>();
        loopingBackground = FindObjectOfType<LoopingBackground>();
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.CompareTag("Weapon")){
           NinjaFrogDeath();
           StartCoroutine(GameOVerAfterDelay());
        }
    }

    public void NinjaFrogDeath(){
        AudioManager.Instance.StopAudio();
        AudioManager.Instance.DeathAudio();
        ninjaFrogMovement.SetInput(true);
        ninjaFrogAnimation.DeathAnimation();
        gameManager.SetNinjaFrogDeath(true);
        ninjaFrogMovement.GetRigidbodyNinjaFrog().bodyType = RigidbodyType2D.Static;
        this.enabled = false;
        ninjaFrogMovement.GetCollider2DNinjaFrog().isTrigger = true;
        loopingBackground.SetLooping(false);
    }

    private IEnumerator GameOVerAfterDelay(){
        yield return new WaitForSeconds(delayBeforeGameOver);
        SceneLoader.Instance.ChangeScene(SceneName.GAME_OVER);
    }
}
