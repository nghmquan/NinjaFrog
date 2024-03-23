using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    [SerializeField] private GameObject[] itemsPrefab;
    [SerializeField] private float secondSpawn = 0.5f;
    [SerializeField] private float minItems;
    [SerializeField] private float maxItems;

    //Start is called before the first from update
    private void Start()
    {
        StartCoroutine(SpikeSpawn());

    }

    IEnumerator SpikeSpawn()
    {
        while (true)
        {
            var wanted = Random.Range(minItems, maxItems);
            var position = new Vector3(wanted, transform.position.y);
            GameObject gameObject = Instantiate(itemsPrefab[Random.Range(0, itemsPrefab.Length)],
                position, Quaternion.identity);
            yield return new WaitForSeconds(secondSpawn);
            Destroy(gameObject, 0f);
        }
    }

}
