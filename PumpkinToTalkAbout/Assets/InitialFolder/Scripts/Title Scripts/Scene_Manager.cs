using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Manager : MonoBehaviour
{
    public string gameScene;
    //public float Option;
    public void StartButton()
    {
        SceneManager.LoadScene(gameScene);
    }
    public void QuitButton()
    {
        Application.Quit();
    }

    public void BackButton()
    {
        SceneManager.LoadScene("Tittle_Screen");
    }

    public void ControlsButton()
    {

        SceneManager.LoadScene("Controls");
    }

}
