using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemCollector : MonoBehaviour
{
    public int rotSpeed = 1;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, rotSpeed, 0, Space.World);
    }
}
