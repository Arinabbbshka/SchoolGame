using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoScene : MonoBehaviour
{
    public void GoLevelSelections()
    {
        SceneManager.LoadScene(1);
    }
    public void GoLevelOne()
    {
        SceneManager.LoadScene(3);
    }
    public void Starts()
    {
        SceneManager.LoadScene(0);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
