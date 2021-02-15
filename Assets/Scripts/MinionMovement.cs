using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Rigidbody))]
public class MinionMovement : MonoBehaviour
{
    NavMeshAgent nm;
    Rigidbody rb;
    public Transform Target;
    public Transform[] WayPoints;
    private GameObject wp;
    public int maxWaypoints = 8;
    private int curWaypoint = 0;
    private int wpIndex;
    //private int loopSafe;
    public float speed = 1, stopDistance = 1;






    // Start is called before the first frame update
    void Start()
    {
        nm = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
        nm.acceleration = speed;
        nm.stoppingDistance = stopDistance;
        WayPoints = new Transform[maxWaypoints];

        // WP-Zuweisung an das Array, welches in der Bewegungsroutine genutzt wird
        for(wpIndex=0; wpIndex < maxWaypoints; wpIndex++)
        {
            wp = GameObject.Find("WP" + curWaypoint);
            Debug.Log("DIESE SCHLEIFE WIRD" + wpIndex + "MAL DURCHLAUFEN!");
            WayPoints[curWaypoint] = wp.GetComponent<Transform>();
            Debug.Log(WayPoints[curWaypoint]);
            curWaypoint++;
        }
        curWaypoint = 0;
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        Target = WayPoints[curWaypoint];


        float distance = Vector3.Distance(transform.position, Target.position);


        nm.SetDestination(Target.position);
        if (distance < stopDistance)
        {
            curWaypoint++;
        }

        //Debug.Log(Target.position);
    }
}


