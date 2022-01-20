using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    //Ressources
    public List<Sprite> playerSprites;
    public List<Sprite> weaponSprites;
    public List<int> weaponPrices;
    public List<int> xpTable;

    //References
    public PlayerMain player;
    public FloatingTextManager floatingTextManager;

    //Logic
    public int money;
    public int experience;

    //Floating Text
    public void ShowText(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        floatingTextManager.Show(msg, fontSize, color, position, motion, duration);
    }

    public void SaveState()
    {
        string saveData = "";
        saveData += "0" + "|"; //Saving skin
        saveData += money.ToString() + "|";
        saveData += experience.ToString() + "|";
        saveData += "0"; // Saving weapon level

        PlayerPrefs.SetString("SavedData", saveData);
        Debug.Log("State Saved");
    }

    public void LoadState(Scene scene, LoadSceneMode mode)
    {
        SceneManager.sceneLoaded -= LoadState;
        if (PlayerPrefs.HasKey("SavedData"))
        {
            return;
        }
        else
        {
            string[] saveData = PlayerPrefs.GetString("SavedData").Split('|');
            money = int.Parse(saveData[1]);
            experience = int.Parse(saveData[2]);
        }
        Debug.Log("State Loaded");
    }
}
