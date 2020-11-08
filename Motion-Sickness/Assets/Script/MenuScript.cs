using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {

    //This Loads the Menu
    //public void LoadSceneSelect0()
    //{
    //    SceneManager.LoadScene(0);
    //}

    //This Loads the Bobbing Boat 1
    public void LoadSceneSelect1()
    {
        SceneManager.LoadScene(1);
    }

    //This Loads the Bobbing Boat 2
    public void LoadSceneSelect2()
    {
        SceneManager.LoadScene(2);
    }

    //This Loads the Buoyancy Boat 1
    public void LoadSceneSelect3()
    {
        SceneManager.LoadScene(3);
    }

    //This Loads the Buoyancy Boat 2
    public void LoadSceneSelect4()
    {
        SceneManager.LoadScene(4);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
