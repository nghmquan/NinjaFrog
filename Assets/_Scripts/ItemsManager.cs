using System.Collections;
using UnityEngine;

public class ItemsManager : MonoBehaviour
{
    [SerializeField] private BoxCollider2D colliderItems;
    [SerializeField] private Rigidbody2D rigidbodyItems;
    [SerializeField] private SpriteRenderer spriteItems;

    [SerializeField] private float flashDuration = 0.1f;
    [SerializeField] private float totalDuration = 5f;

    private Color originalColor;

    // Start is called before the first frame update
    void Start(){
        rigidbodyItems = GetComponent<Rigidbody2D>();
        colliderItems = GetComponent<BoxCollider2D>();
        spriteItems = GetComponent<SpriteRenderer>();
    }

    //Set collision items when they collide ground
    private void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.CompareTag("Ground")){
            rigidbodyItems.bodyType = RigidbodyType2D.Static;
            colliderItems.isTrigger = true;
            StartCoroutine(StartFlashAfterDelay(5f));
        }
    }

    private IEnumerator IsFlashItems(){
        float elapsedTime = 0f;
        bool isFlashing = false;

        while(elapsedTime < totalDuration){
            elapsedTime += Time.deltaTime;
            isFlashing = !isFlashing;
            spriteItems.color = isFlashing ? Color.white : originalColor;

            yield return new WaitForSeconds(flashDuration);
        }

        Destroy(gameObject);
    }

    private IEnumerator StartFlashAfterDelay(float delay){
        yield return new WaitForSeconds(delay);
        StartCoroutine(IsFlashItems());
    }
}
