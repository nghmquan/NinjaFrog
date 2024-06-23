using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] private float gameSpeed = 1f;
    [SerializeField] private float speedIncreaseTime = 0.1f;
    
    private float elapsedTime = 0f;
    private bool isNinjaFrogDeath = false;
    
    private List<GameObject> objectsList = new List<GameObject>();

    // Update is called once per frame
    void Update(){
        GameSpeedIncreaseOverTime();
    }

    public float GetGameSpeed(){
        return gameSpeed;
    }

    private void GameSpeedIncreaseOverTime(){
        elapsedTime += Time.deltaTime;
        gameSpeed += speedIncreaseTime * Time.deltaTime;
    }

    public void SetNinjaFrogDeath(bool isDeath){
        isNinjaFrogDeath = isDeath;
        if(isDeath){
            ClearSpawnedObject();
        }
    }

    public bool IsNinjaFrogDeath(){
        return isNinjaFrogDeath;
    }

    public void AddSpawnedObjects(GameObject gameObject){
        objectsList.Add(gameObject);
    }

    public void RemoveSpawnedObjects(GameObject gameObject){
        objectsList.Remove(gameObject);
    }

    private void ClearSpawnedObject(){
        foreach (var objects in objectsList){
            if(objects != null){
                Destroy(objects);
            }
        }
        objectsList.Clear();
    }
}
