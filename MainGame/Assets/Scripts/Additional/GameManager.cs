using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake()
    {
        if (GameManager.instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        SceneManager.sceneLoaded += LoadState;
        DontDestroyOnLoad(gameObject);
    }

    // �������  
    public List<Sprite> playerSprites;
    public List<Sprite> weaponSprites;
    public List<int> weaponPrices;
    public List<int> artPrices;
    public List<int> poisionPrices;
    public List<int> goldTable;

    // ������ �� �������
    public PlayerController player;
    public Image hpBAR;
    // public FloatinTextManager floatingTextManager;
    // public Weapon weapon;

    // ���������� ������
    public int gold;
    public int souls;

    // ������� ������
    //public bool TryUpgradeWeapon()
    //{
    //    // ������������� �� ������ ������?
    //    if (weaponPrices.Count <= weapon.weaponlvl)
    //        return false;

    //    if (gold >= weaponPrices[weapon.weaponlvl])
    //    {
    //        gold -= weaponPrices[weapon.weaponlvl];
    //        weapon.UpgradeWeapon();
    //        return true;
    //    }

    //    return false;
    //}

    public void SaveState(Scene sc, LoadSceneMode mode)
    {
        string s = "";

        s += "0" + "|";
        s += gold.ToString() + "|";
        s += souls.ToString() + "|";
        s += "0" + "|";

        PlayerPrefs.SetString("SaveState", s);
    }
    public void LoadState(Scene sc, LoadSceneMode mode)
    {
        SceneManager.sceneLoaded -= LoadState;
        if (!PlayerPrefs.HasKey("SaveState"))
            return;

        string[] data = PlayerPrefs.GetString("SaveState").Split('|');
        // "0|10|15|2" - ��� ������

        gold = int.Parse(data[1]);
        souls = int.Parse(data[2]);
        // weapon.weaponlvl = int.Parse(data[3]);
    }
    public void ShowText(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        // floatingTextManager.Show(msg, fontSize, color, position, motion, duration);
    }
}
