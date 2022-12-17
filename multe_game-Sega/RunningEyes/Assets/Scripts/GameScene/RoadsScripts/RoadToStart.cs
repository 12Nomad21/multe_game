using System.Collections.Generic;
using UnityEngine;

public class RoadToStart : MonoBehaviour
{
    [Header("Settings")]
    public float _edge = -23f;
    public float _roadSize = 18f;
    [Header("Roads")]
    public List<GameObject> _roadsList;

    private void Update()
    {
        MoveRoadToStart();
    }

    private void MoveRoadToStart()
    {
        if(_roadsList[0].transform.position.x <= _edge){
            _roadsList[0].transform.position = new Vector3(_roadsList[_roadsList.Count - 1].transform.position.x + _roadSize, 0, 0);

            GameObject _firstRoad = _roadsList[0];
            
            for(int i = 0; i < _roadsList.Count-1; i++){
                _roadsList[i] = _roadsList[i+1];
            }

            _roadsList[_roadsList.Count - 1] = _firstRoad;
        }
    }
}
