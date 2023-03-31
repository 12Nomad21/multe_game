using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform target;
    static public float CameraSpeed = 1f;
    void Update()
    {
        Vector3 targetposition = new Vector3(target.position.x,target.position.y,-10f);
        transform.position = Vector3.Slerp(transform.position,targetposition,CameraSpeed*Time.deltaTime);
    }
}
