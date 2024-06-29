using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    [SerializeField] private float gameSpeed = 1f;
    [SerializeField] private float speedIncreaseTime = 0.1f;
    
    private float elapsedTime = 0f;
    private bool isNinjaFrogDeath = false;
    
    private bool isPlayerClick = false;

    private List<GameObject> objectsList = new List<GameObject>();
    [SerializeField] private SpawnWeapon spawnWeapon;
    [SerializeField] private SpawnItems spawnItems;

    [SerializeField] private GameObject[] uiObject;

    // Update is called once per frame
    void Update(){

        if(Input.GetMouseButtonDown(0) && !isPlayerClick){
            isPlayerClick = true;
            AudioManager.Instance.BackgroundMusic();
            StartCoroutine(spawnItems.ItemsSpawn());
            StartCoroutine(spawnWeapon.WeaponsSpawn());
            for(int i = 0; i < uiObject.Length; i++){
                Destroy(uiObject[i]);
            }

        }

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
