using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharContrMovement : MonoBehaviour
{
    public float speed;
    private CharacterController charContr;
    // Start is called before the first frame update
    void Start()
    {
        charContr = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        charContr.SimpleMove(Vector3.forward * speed);
    }
}
