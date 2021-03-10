using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Rigidbody))]
public class BareMinionMovement : MonoBehaviour
{
    NavMeshAgent nm;
    Rigidbody rb;
    public Transform Target;
    public Transform[] WayPoints;
    private GameObject wp;
    public float speed = 1, stopDistance = 1;
    private string spawnPointName;
    public GameObject[] spawnPoints;
    public GameObject mySpawnPoint;
    private GameObject sp;



    // Start is called before the first frame update
    void Start()
    {
        nm = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();

        if (spawnPoints == null)
        {
            spawnPoints = GameObject.FindGameObjectsWithTag("Spawnpoint");
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
