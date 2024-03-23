using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikedBallSpawn : MonoBehaviour
{
    [SerializeField] private GameObject[] spikePrefab;
    [SerializeField] private float secondSpawn = 0.5f;
    [SerializeField] private float minSpike;
    [SerializeField] private float maxSpike;

    //Start is called before the first from update
    private void Start()
    {
        StartCoroutine(SpikeSpawn());
      
    }

    IEnumerator SpikeSpawn()
    {
        while (true)
        {
            var wanted = Random.Range(minSpike, maxSpike);
            var position = new Vector3(wanted, transform.position.y);
            GameObject gameObject = Instantiate(spikePrefab[Random.Range(0, spikePrefab.Length)],
                position, Quaternion.identity);
            yield return new WaitForSeconds(secondSpawn);
            Destroy(gameObject, 0f);
        }
    }
}
