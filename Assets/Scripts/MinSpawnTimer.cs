using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinSpawnTimer : MonoBehaviour
{
    //ACHTUNG: WEITER AUSFEILEN, WIE GENAU GESPAWNED WIRD! vlt mit rays realisieren und kreisförmig spawnen?? 
    //oder nacheinander wie bei lol, das wäre die einfachste variante
    private bool minSpawned;
    private float spawnTimer;
    public float spawnTimerReset=5;
    public int minCounter=1;
    public GameObject dummyDMG;
    public GameObject dummyTank;
    Vector3 spawnPoint = new Vector3 (0,1,0);


    // Start is called before the first frame update
    void Start()
    {
        spawnTimer = spawnTimerReset;
    }


    // Update is called once per frame
    void Update()
    {    
        //erst bei Ablauf des Spawntimer wird gespawnt
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0)
        {
            for (minCounter = 1; minCounter > 0; minCounter--)
            {
                //Instantiate(dummyTank, transform.position + spawnPoint, transform.rotation);
                Instantiate(dummyDMG, transform.position + spawnPoint, transform.rotation);
            }
            minSpawned = true;
        }

        //reset des Spawntimers, wenn gerade gespawned wurde
        if (minSpawned == true)
        {
            spawnTimer = spawnTimerReset;
            minSpawned = false;
        }
    }
}
