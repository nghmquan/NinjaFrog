using System.Collections;
using UnityEngine;

public class SpawnWeapon : MonoBehaviour
{
    [SerializeField] private GameObject[] objectsPrefabs;
    [SerializeField] private float secondSpawn = 0.5f;
    [SerializeField] private float minPos;
    [SerializeField] private float maxPos;

    private float elapsedTime = 0f;

    private NinjaFrogMovement ninjaFrog;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start(){
        gameManager = FindFirstObjectByType<GameManager>();
        ninjaFrog = FindObjectOfType<NinjaFrogMovement>();
        StartCoroutine(ObjectsSpawn());
    }

    // Update is called once per frame
    void Update(){
        elapsedTime = Time.deltaTime;
    }

    IEnumerator ObjectsSpawn(){
        while (true)
        {
            if(gameManager.IsNinjaFrogDeath()) yield break;
            
            float adjustedSecondSpawn = CalculateSpawnInterval(gameManager.GetGameSpeed(), ninjaFrog.GetMoveSpeed());
            for (int i = 0; i < objectsPrefabs.Length; i++)
            {
                var wanted = Random.Range(minPos, maxPos);
                var position = new Vector3(wanted, transform.position.y, 0);
                GameObject gameObject = Instantiate(objectsPrefabs[Random.Range(0, objectsPrefabs.Length)],
                    position, Quaternion.identity);
                gameManager.AddSpawnedObjects(gameObject);
                Destroy(gameObject, 5f);
                gameManager.RemoveSpawnedObjects(gameObject);
            }

             // Increase gravity scale over time
            Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                float gravityScale = CalculateGravityScale();
                rb.gravityScale = gravityScale;
            }

            yield return new WaitForSeconds(adjustedSecondSpawn);
        }
    }

    private float CalculateSpawnInterval(float gameSpeed, float ninjaFrogSpeed){
        float baseInterval = secondSpawn;
        float combinedFactor = (gameSpeed + ninjaFrogSpeed) / 2f;
        float timeFactor = 1f / (1f + elapsedTime / 60f);
        float spawnInterval = baseInterval * timeFactor / Mathf.Pow(combinedFactor, 0.5f);

        return Mathf.Max(spawnInterval, 0.5f);
    }

    private float CalculateGravityScale(){
        float baseGravityScale = 1f; // Initial gravity scale
        float gravityScaleIncreaseRate = 0.1f; // Rate at which gravity scale increases
        return baseGravityScale + gravityScaleIncreaseRate * elapsedTime;
    }
}
