using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSpikes : MonoBehaviour
{
    private MoveRoads moveMeneger = new MoveRoads();

    private void FixedUpdate() {
        gameObject.transform.Translate(Vector3.left * moveMeneger._speedMove * Time.deltaTime, Space.World);
    }
}
