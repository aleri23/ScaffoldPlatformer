using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// GameManager handles game logic that involves interactions between multiple objects in the scene such as Game Over and current checkPoint location
/// </summary>
public class GameManager : MonoBehaviour {
    public Vector2[] Spawnbounds;
    public float Spawnrate;// enemies per second
    public GameObject[] Enemies;
    public GameObject player; //The player GameObject on the scene
    private Transform SpawnPosition; //The location that the player will spawn
    public int Maxenemies; 
    public int Currentenemies = 0;
 

    public void Enemydied() //Needs to be called from wherever we are killing the enemy
    {
        Currentenemies--;
    }
    // Use this for initialization
	void Start () {
        
	}
    public void Update()
    {
        float roll1 = Random.Range(0f, 1f);
        float roll2 = Random.Range(0f, 1f);
        if (roll1 < Time.deltaTime * Spawnrate & Currentenemies < Maxenemies)
       
        {
            Currentenemies++;

            Instantiate(Enemies[0], v2tov3(Vector2.Lerp(Spawnbounds[0], Spawnbounds[1], roll2)), Quaternion.identity);
        }
    }
    
    Vector3 v2tov3 (Vector2 v2)
    {
        return new Vector3(v2.x, v2.y, 0);
    }

    //Updates the spawnPosition
    public void UpdateSpawnPosition(Transform newPosition)
    {
        SpawnPosition = newPosition;
    }

    //Moves the player to the SPawnPosition and Calls playerHealth Healing function
    public void GameOver()
    {
        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
        StartCoroutine(RestartGame(playerHealth));
    }

    //Restarts Players health and position with a .5 second delay
    IEnumerator RestartGame(PlayerHealth playerHealth)
    {
        yield return new WaitForSeconds(.5f);
        playerHealth.HealDamage(playerHealth.maxHealth);
        player.transform.position = SpawnPosition.position;

    }
}
