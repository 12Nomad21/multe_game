using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRoads : MonoBehaviour
{
    [Header("Settings")]
    public float _speedMove = 5f;
    public float _edge = -23f;
    public float _roadSize = 18f;
    [Header("Roads")]
    public List<GameObject> _roadsList;

    private void FixedUpdate()
    {
        MoveRoadsMethod(_speedMove, _roadsList);
    }

    private void Update()
    {
        MoveRoadToStart(_edge, _roadSize, _roadsList);
    }

    private void MoveRoadsMethod(float speed, List<GameObject> roads)
    {
        foreach(GameObject road in roads){
            road.transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
    }

    private void MoveRoadToStart(float edge, float roadSize, List<GameObject> roads)
    {
        if(roads[0].transform.position.x <= edge){
            roads[0].transform.position = new Vector3(roads[roads.Count - 1].transform.position.x + roadSize, 0, 0);

            GameObject _firstRoad = roads[0];
            
            for(int i = 0; i < roads.Count-1; i++){
                roads[i] = roads[i+1];
            }

            roads[roads.Count - 1] = _firstRoad;
        }
    }
}
