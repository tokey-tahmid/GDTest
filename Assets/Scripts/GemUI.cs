using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GemUI : MonoBehaviour
{
    public static int gemCount;
    public static int pointCount;
    public GameObject gemCountDisplay;
    public GameObject pointCountDisplay;

    // Update is called once per frame
    void Update()
    {
        gemCountDisplay.GetComponent<Text>().text = "" + gemCount;
        pointCountDisplay.GetComponent<Text>().text = "" + pointCount;
    }
}
