using UnityEngine;
public class GameData
{
    public static string GALLERY_SAVE_PATH = Application.persistentDataPath + "/Backgrounds/";

    public const string IMAGE_COUNTER_SAVE_NAME = "ImageCounter";

    public static void SaveInt(string name, int value)
    { 
        PlayerPrefs.SetInt(name, value);
    }

    public static int GetInt(string name)
    {
        return PlayerPrefs.GetInt(name, 0);
    }
}
