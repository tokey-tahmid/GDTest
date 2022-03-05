using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void MainMenu()
    {
        SceneManager.LoadScene("GDTest");
    }
    
    public void HomeMenu()
    {
        GemUI.pointCount = 0;
        GemUI.gemCount = 0;
        Time.timeScale = 1f;
        SceneManager.LoadScene("MenuHome");
    }
}
