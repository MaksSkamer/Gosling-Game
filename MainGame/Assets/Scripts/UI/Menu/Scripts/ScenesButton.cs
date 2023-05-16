using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesButton : MonoBehaviour
{
    public void ChangeScenes(int numberScene)
    {
        SceneManager.LoadScene(numberScene);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
