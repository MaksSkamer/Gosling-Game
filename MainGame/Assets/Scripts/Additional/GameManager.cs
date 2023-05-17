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
        InvokeRepeating("FistChoose", 5f, 5f);
        if (GameManager.instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        //SceneManager.sceneLoaded += LoadState;
        DontDestroyOnLoad(gameObject);
        
    }
  

    public void RenamePL()
    {
        plName = playerNamed.ReturnName();
    }

    // Ресурсы  
    public List<Sprite> playerSprites;
    public List<Sprite> weaponSprites;
    public List<int> weaponPrices;
    public List<int> artPrices;
    public List<int> poisionPrices;
    public List<int> goldTable;

    // Ссылки на объекты
    public PlayerNamed playerNamed;
    public PlayerController player;
    public SoundManager SoundManager;
    public FloatingTextManager floatingTextManager;
    public RectTransform hitpointBar;

    // Логические данные
    public string plName;
    public int gold;
    public int Score;
    public bool DeathSc = false;
    public int fch;
    // Апгрейд оружия
    //public bool TryUpgradeWeapon()
    //{
    //    // Максимального ли уровня оружие?
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

   
    public void OnHitpointChange()
    {
        float ratio = (float)player.hitpoint / (float)player.maxHitpoint;
        hitpointBar.localScale = new Vector3(ratio, 1, 1);
    }
    protected void FistChoose()
    {
        fch = UnityEngine.Random.Range(0, 100);
    }
    public void SaveState(Scene sc, LoadSceneMode mode)
    {
        string s = "";

        s += "0" + "|";
        s += gold.ToString() + "|";
        s += "0" + "|";

        PlayerPrefs.SetString("SaveState", s);
    }
    //public void LoadState(Scene sc, LoadSceneMode mode)
    //{
    //    SceneManager.sceneLoaded -= LoadState;
    //    if (!PlayerPrefs.HasKey("SaveState"))
    //        return;

    //    string[] data = PlayerPrefs.GetString("SaveState").Split('|');
    //    // "0|10|15|2" - вид сейвов

    //    gold = int.Parse(data[1]);
    //    weapon.weaponlvl = int.Parse(data[2]);
    //}
    public void ShowText(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        floatingTextManager.Show(msg, fontSize, color, position, motion, duration);
    }
    public void Sound(AudioSource a, AudioClip[] sound, int i)
    {
        SoundManager.PlaySound(a, sound, i);
    }

    public void SoundStop(AudioSource a)
    {
        SoundManager.StopSound(a);
    }
}
