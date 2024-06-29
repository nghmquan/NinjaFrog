using System.Collections;
using UnityEngine;

public class SpawnItems : MonoBehaviour
{
    [SerializeField] private GameObject[] objectsPrefabs;
    [SerializeField] private float secondSpawn = 5f;
    [SerializeField] private float minPos;
    [SerializeField] private float maxPos;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start(){
        gameManager = FindObjectOfType<GameManager>();
    }

    public IEnumerator ItemsSpawn(){
        while (true) 
        {
            if(gameManager.IsNinjaFrogDeath()) yield break;

            yield return new WaitForSeconds(1f);
            var wanted = Random.Range(minPos, maxPos);
            var position = new Vector3(wanted, transform.position.y);
            GameObject gameObject = Instantiate(objectsPrefabs[Random.Range(0, objectsPrefabs.Length)],
                position, Quaternion.identity);
            gameManager.AddSpawnedObjects(gameObject);
            yield return new WaitForSeconds(secondSpawn);
            Destroy(gameObject, 3f);
            gameManager.RemoveSpawnedObjects(gameObject);
        }
    }
}