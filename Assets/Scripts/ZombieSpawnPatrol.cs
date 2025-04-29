using UnityEngine;

public class ZombieSpawnPatrol : MonoBehaviour
{

    public Transform[] spawnPoints;
    public GameObject[] zombies;
    public int zombieSpawnAmt = 3;


    private float reSpawnTimer = 10;
    private float resetTimer = 0;
    [HideInInspector]
    public bool canSpawn = true;

    public bool houseSpawn = false;

    private void Start()
    {
        if(houseSpawn == true)
        {
            canSpawn = false;
        }
    }


    void Update()
    {
        if (canSpawn == false && houseSpawn == false)
        {
            resetTimer += 1 * Time.deltaTime;
            if (resetTimer >= reSpawnTimer)
            {
                canSpawn = true;
                resetTimer = 0;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && canSpawn == true && SaveScript.zombiesInGame < 100)
        {
            for (int i = 0; i < zombieSpawnAmt; i++)
            {
                if(houseSpawn == false)
                {
                    Instantiate(zombies[Random.Range(0, zombies.Length)],spawnPoints[Random.Range(0, spawnPoints.Length)].position,spawnPoints[Random.Range(0, spawnPoints.Length)].rotation);
                }
                else
                {
                    Instantiate(zombies[Random.Range(0, zombies.Length)],spawnPoints[i].position,spawnPoints[i].rotation);
                }
                
                SaveScript.zombiesInGame++;
            }
            canSpawn = false;
        }
    }
}
