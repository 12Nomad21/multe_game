using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMeneger : MonoBehaviour
{
    [SerializeField] private float _speedMove = 5f;
    [SerializeField] private List<GameObject> _roadsList;
    public List<GameObject> _obstaclesList;

    private void FixedUpdate()
    {
        MoveObjects(_speedMove, _roadsList, _obstaclesList);
    }

    private void MoveObjects(float speed, List<GameObject> roads, List<GameObject> obstacles)
    {
        foreach(GameObject road in roads)
        {
            road.transform.Translate(Vector3.left * speed * Time.deltaTime);
        }

        foreach (GameObject obstacle in obstacles)
        {
            obstacle.transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
    }

    private void ReplaceRoad(List<GameObject> roads)
    {
        if (roads[])
    }
}
