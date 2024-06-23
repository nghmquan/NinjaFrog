using UnityEngine;

public class NinjaFrogAnimation : MonoBehaviour
{
    [SerializeField] private Animator animatorNinjaFrog;
    [SerializeField] private SpriteRenderer spriteNinjaFrog;
    private NinjaFrogMovement ninjaFrog;

    // Start is called before the first frame update
    void Start(){
        animatorNinjaFrog = GetComponent<Animator>();
        spriteNinjaFrog = GetComponent<SpriteRenderer>();
        ninjaFrog = FindAnyObjectByType<NinjaFrogMovement>();
    }

    private void MoveAnimation(Vector2 direction){
        if(direction.x > 0){
            spriteNinjaFrog.flipX = false;
        }else{
            if(direction.x < 0){
                spriteNinjaFrog.flipX = true;
            }
        }
    }

    public void CheckIsRunning(bool isRunning){        
        animatorNinjaFrog.SetBool("isRunning", isRunning);
        if (isRunning){
            MoveAnimation(ninjaFrog.GetDirection());    
        }
    }

    public void DeathAnimation(){
        animatorNinjaFrog.SetTrigger("isDeath");
    }
}
