using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneSwipe : MonoBehaviour
{
    protected AudioSource a;
    public AudioClip[] sound;
    public GameObject LoadinScreen;

    public Slider scale;

    public void Loading()
    {
        //GameManager.instance.Sound(a, sound, 0);
        LoadinScreen.SetActive(true);
        StartCoroutine(LoadAsync());
    }

    IEnumerator LoadAsync()
    {

        Destroy(GameObject.Find("MenuTema(Clone)"));
        AsyncOperation loadAsync = SceneManager.LoadSceneAsync(1);
        loadAsync.allowSceneActivation = false;

        while(!loadAsync.isDone)
        {
            scale.value = loadAsync.progress / 0.9f;

            if(loadAsync.progress >= 0.9f && !loadAsync.allowSceneActivation)
            {
                yield return new WaitForSeconds(3.0f);
                loadAsync.allowSceneActivation = true;
            }
            yield return null;
        }
    }
}
