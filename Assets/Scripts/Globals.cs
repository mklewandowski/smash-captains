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
        Christmas,
        Tiger,
        ApplePie,
        CherryPie,
        Zebra,
        PumpkinPie,
        CandyCane,
        CheeseBroc,
        StrawberryBanana,
        Pretzel,
        Sherbet,
        Rainbow,
        Latte,
        RootBeer,
        Twinkie,
        Neo,
        Cocoa,
        Grape,
        Pickle,
        GreenTank
    }

    // audio and music
    public static bool AudioOn;
    public static bool MusicOn;

    // day night mode
    public enum GameMood {
        Day,
        Night,
        Fire,
    }
    public static GameMood Mood = GameMood.Day;

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
    public const string PlaneFlavorPlayerPrefsKey = "PlaneFlavor";
    public const string GameMoodPlayerPrefsKey = "GameMood";

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

    public static string GetPlaneNameFromColor(PlaneColor planeColor)
    {
        string planeName = "";
        if (planeColor == Globals.PlaneColor.Yellow)
            planeName = "Smash Captain";
       else if (planeColor == Globals.PlaneColor.Red)
            planeName = "Cherry Berry";
        else if (planeColor == Globals.PlaneColor.Orange)
            planeName = "Marmalade";
        else if (planeColor == Globals.PlaneColor.Blue)
            planeName = "Blue Blast";
        else if (planeColor == Globals.PlaneColor.Pink)
            planeName = "Pitaya";
        else if (planeColor == Globals.PlaneColor.Berkeley)
            planeName = "Berkeley";
        else if (planeColor == Globals.PlaneColor.BombPop)
            planeName = "Bomb Pop";
        else if (planeColor == Globals.PlaneColor.Burger)
            planeName = "Pig Burger";
        else if (planeColor == Globals.PlaneColor.CandyCorn)
            planeName = "Candy Corn";
        else if (planeColor == Globals.PlaneColor.CheeseBurger)
            planeName = "Cheeseburger";
        else if (planeColor == Globals.PlaneColor.CottonCandy)
            planeName = "Cotton Candy";
        else if (planeColor == Globals.PlaneColor.Creamsicle)
            planeName = "Creamsicle";
        else if (planeColor == Globals.PlaneColor.IceCreamSandwich)
            planeName = "Ice Cream Sandwich";
        else if (planeColor == Globals.PlaneColor.Lime)
            planeName = "Always Boring Lime";
        else if (planeColor == Globals.PlaneColor.Pizza)
            planeName = "Big Slice";
        else if (planeColor == Globals.PlaneColor.Pack)
            planeName = "Curly";
        else if (planeColor == Globals.PlaneColor.Shadow)
            planeName = "Shadow";
        else if (planeColor == Globals.PlaneColor.Smores)
            planeName = "Smores";
        else if (planeColor == Globals.PlaneColor.Snow)
            planeName = "Snow Day";
        else if (planeColor == Globals.PlaneColor.Teal)
            planeName = "Concord";
        else if (planeColor == Globals.PlaneColor.Watermelon)
            planeName = "Sandia";
        else if (planeColor == Globals.PlaneColor.Christmas)
            planeName = "Stocking Stuffer";
        else if (planeColor == Globals.PlaneColor.Tiger)
            planeName = "Tiger";
        else if (planeColor == Globals.PlaneColor.ApplePie)
            planeName = "Apple Pie";
        else if (planeColor == Globals.PlaneColor.CherryPie)
            planeName = "Cherry Pie";
        else if (planeColor == Globals.PlaneColor.Zebra)
            planeName = "Zebra";
        else if (planeColor == Globals.PlaneColor.PumpkinPie)
            planeName = "Pumpkin Pie";
        else if (planeColor == Globals.PlaneColor.CandyCane)
            planeName = "Candy Cane";
        else if (planeColor == Globals.PlaneColor.CheeseBroc)
            planeName = "The Anna";
        else if (planeColor == Globals.PlaneColor.StrawberryBanana)
            planeName = "Strawberry Banana";
        else if (planeColor == Globals.PlaneColor.Pretzel)
            planeName = "Chocolate Covered Pretzel";
        else if (planeColor == Globals.PlaneColor.Sherbet)
            planeName = "Sherbet";
        else if (planeColor == Globals.PlaneColor.Rainbow)
            planeName = "Rainbow Taffy";
        else if (planeColor == Globals.PlaneColor.Latte)
            planeName = "Latte";
        else if (planeColor == Globals.PlaneColor.RootBeer)
            planeName = "Root Beer Float";
        else if (planeColor == Globals.PlaneColor.Twinkie)
            planeName = "Twinkie";
        else if (planeColor == Globals.PlaneColor.Neo)
            planeName = "Neopolitan";
        else if (planeColor == Globals.PlaneColor.Cocoa)
            planeName = "Cocoa";
        else if (planeColor == Globals.PlaneColor.Grape)
            planeName = "Always Awesome Grape";
        else if (planeColor == Globals.PlaneColor.Pickle)
            planeName = "Dill Pickle";
        return planeName;
    }
}
