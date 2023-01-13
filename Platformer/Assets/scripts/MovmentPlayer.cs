using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovmentPlayer : MonoBehaviour
{
    [SerializeField] private float speed = 1;
    [SerializeField] private float ForceJump = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    { 
        transform.position += new Vector3(Input.GetAxis("Horizontal")*speed*Time.deltaTime,0,0);
        transform.position += new Vector3(0,Input.GetAxis("Vertical")*ForceJump*Time.deltaTime,0);
    }
}
