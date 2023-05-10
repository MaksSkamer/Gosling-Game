using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesButton : MonoBehaviour
{
    protected AudioSource a;
    public AudioClip[] sound;
    public void ChangeScenes(int numberScene)
    {
        SceneManager.LoadScene(numberScene);
    }
    public void Exit()
    {
        GameManager.instance.Sound(a, sound, 0);
        Application.Quit();
    }
}
