using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerNamed : MonoBehaviour
{
    [SerializeField] private Text PlName;
    [SerializeField] public string Text;
    public static PlayerNamed instance;
    public string PlNamed;
    public void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    public void Start()
    {
        GameManager.instance.RenamePL();
    }
    public void SaveInputText()
    {
        Text = PlName.text;
    }
    public string ReturnName()
    {
        return Text;
    }
}
