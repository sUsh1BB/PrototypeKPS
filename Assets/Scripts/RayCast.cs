using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast: MonoBehaviour
{
    public float rayRange = 30;
    public float rayAngle = 0;
    public float walkSpeed = 0.1f;
    public int raysToShoot = 90;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        bool isRayHitting;
        
        Vector3 posiSpottetObject;
        Vector3 lookDirection;
        Vector3 rayDirection;


        //in jedem Frame werden die Rays im Kreis um das GameObject gecastet. Achtung: ressourcenhungrig!
        for (int i=0; i < raysToShoot; i++)
        {

            // Sin, Cos und Kreisfunktion zur Erstellung eines RayCircles um das GameObject
            float x = Mathf.Sin(rayAngle);
            float z = Mathf.Cos(rayAngle);        
            rayAngle += 2 * Mathf.PI / raysToShoot;
            rayDirection = new Vector3(x, 0, z);

            //bool-Übergabe, ob ein Ray etwas gehittet hat
            isRayHitting = Physics.Raycast(transform.position, rayDirection, rayRange);

            if (isRayHitting)
            {
                Physics.Raycast(transform.position, rayDirection, out RaycastHit raycastHit, rayRange);
                posiSpottetObject = raycastHit.point;
                Debug.Log("hit! bei Position" + posiSpottetObject);

                //LookRoutine
                lookDirection = raycastHit.point - transform.position;
                transform.rotation = Quaternion.LookRotation(lookDirection);

                //Bewegungsroutine - hier ist der mathematische fehler drin, auf dfen ich ned komme
                transform.position = raycastHit.point / walkSpeed;

            }


            //raycast sichtbar machen
            Debug.DrawRay(transform.position, rayDirection * rayRange, Color.red);

            //Debug
            /*if (isRayHitting)
            {
                Debug.Log(isRayHitting);
            }*/


        }
        rayAngle = 0;



    }
}
