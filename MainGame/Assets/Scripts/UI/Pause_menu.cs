using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pause_menu : MonoBehaviour
{
   
    public static bool GameIsPaused = false;

    public GameObject pauseMenu;

    public GameObject SQLdb;

    public Image osu;

    int count = 0;

    void Update()
    {
       if(Input.GetKeyDown(KeyCode.Escape) && GameManager.instance.DeathSc == false)
        {
            if(GameIsPaused) 
                Resume();
            else
                Pause();
        }      
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused= true;
    }

    public void LoadMenu()
    {
        Time.timeScale= 1f;
        Invoke("menu", 2f);
    }

    public void QuitGame()
    {
        Invoke("quit", 2f);
    }

    public void OsuFuck()
    {
        count++;
        if (count >= 10)
        {
            osu.color = Color.white;
            Application.OpenURL("https://osu.ppy.sh/home");
        }
        else
            osu.color = Color.clear;
    }

    void menu()
    {
        SceneManager.LoadScene("_Menu");
    }

    void qiut()
    {
        Application.Quit();
    }
}
