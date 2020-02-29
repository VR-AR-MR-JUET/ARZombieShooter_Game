using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneHandler : MonoBehaviour
{
    public void LoadGame()
    {
        SceneManager.LoadScene("MainGame");
    }public void start()
    {
        SceneManager.LoadScene("Start");
    }
    public void About()
    {
        SceneManager.LoadScene("AboutMe");
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void AboutToMain()
    {
        SceneManager.LoadScene("Start");
    }

    
}
