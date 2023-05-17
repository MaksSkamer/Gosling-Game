using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerNamed : MonoBehaviour
{
    [SerializeField] private Text PlName;
    [SerializeField] public string Text;
    public static PlayerNamed instance;
    public void Awake()
    {
        DontDestroyOnLoad(gameObject);
        Text = "pussy";
    }
    
    public void SaveInputText()
    {
        Text = PlName.text;
        GameManager.instance.RenamePL();
    }
    public string ReturnName()
    {
        return Text;
    }
}
