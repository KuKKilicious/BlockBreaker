using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public void loadLevel(string name)
    {
        Brick.breakableCount = 0;
        Debug.Log("loading Level:" + name);
        SceneManager.LoadScene(name);
    }

    public void quitRequest()
    {
        Debug.Log("quitting");
        Application.Quit();
    }

    public void LoadNextLevel()
    {
        Brick.breakableCount = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void BrickDestroyed()
    {
        if (Brick.breakableCount <= 0) 
            {
            LoadNextLevel();
            }
    }
}
