using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCameraController : MonoBehaviour
{
    private Transform player;

    public float xOffset = -2f;
    public float yOffset = 3f;
    public float zOffset = 5f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Hopper").transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = new Vector3( xOffset, yOffset, player.position.z - zOffset);
    }
}
