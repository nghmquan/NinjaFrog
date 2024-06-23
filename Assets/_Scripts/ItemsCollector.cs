using UnityEngine;

public class ItemsCollector : MonoBehaviour
{
     private void HandleCollision(GameObject collidedObject){
         if(collidedObject.CompareTag("Fruit")){
            ScoresManager.Instance.AddScore(5);
            AudioManager.Instance.ItemsCollectAudio();
            Destroy(collidedObject);
        }
     }

    private void OnCollisionEnter2D(Collision2D collision){
        HandleCollision(collision.gameObject);
    }    

    private void OnTriggerEnter2D(Collider2D collision){
        HandleCollision(collision.gameObject);
    }
}