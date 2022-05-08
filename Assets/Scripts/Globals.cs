using UnityEngine;

public class Globals
{
    // game scroll speed
    public static Vector2 ScrollSpeed = new Vector2(6f, 0);
    public static float minSpeed = 4f;
    public static float maxSpeed = 16f;
    public static float finishLineXPos = 800f;

    // moving direction
    public static Vector2 ScrollDirection = new Vector2(-1f, 0);

    public enum GameState {
        TitleScreen,
        Ready,
        Playing,
        ShowScore,
        Restart
    }
    public static GameState CurrentGameState = GameState.TitleScreen;

    public enum PlaneColor {
        Yellow,
        Red,
        Orange,
        Blue,
        Pink,
        Berkeley,
        BombPop,
        Burger,
        CandyCorn,
        CheeseBurger,
        CottonCandy,
        Creamsicle,
        IceCreamSandwich,
        Lime,
        Pizza,
        Pack,
        Shadow,
        Smores,
        Snow,
        Teal,
        Watermelon,
        GreenTank
    }

    // audio and music
    public static bool AudioOn;
    public static bool MusicOn;

    // keep track of scoring
    public static float BestTime = 0;
    public static float CurrentTime = 0;

    // keep track of in-game metrics
    public static int NumEnemiesSmashed;
    public static int NumPowerups;
    public static int NumHits;

    public const string AudioPlayerPrefsKey = "Audio";
    public const string MusicPlayerPrefsKey = "Music";
    public const string BestTimePlayerPrefsKey = "BestTime";

    public static void SaveIntToPlayerPrefs(string key, int val)
    {
        PlayerPrefs.SetInt(key, val);
    }
    public static int LoadIntFromPlayerPrefs(string key, int defaultVal = 0)
    {
        int val = PlayerPrefs.GetInt(key, defaultVal);
        return val;
    }

    public static void SaveFloatToPlayerPrefs(string key, float val)
    {
        PlayerPrefs.SetFloat(key, val);
    }
    public static float LoadFloatFromPlayerPrefs(string key)
    {
        float val = PlayerPrefs.GetFloat(key, 0f);
        return val;
    }
}
