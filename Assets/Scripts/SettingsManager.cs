using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    AudioManager audioManager;

    [SerializeField]
    Image AudioButtonImage;
    [SerializeField]
    Image MusicButtonImage;
    [SerializeField]
    Image DayNightButtonImage;

    [SerializeField]
    Sprite AudioOnSprite;
    [SerializeField]
    Sprite AudioOffSprite;
    [SerializeField]
    Sprite MusicOnSprite;
    [SerializeField]
    Sprite MusicOffSprite;
    [SerializeField]
    Sprite DaySprite;
    [SerializeField]
    Sprite NightSprite;
    [SerializeField]
    Sprite FireSprite;

    void Awake()
    {
        audioManager = this.GetComponent<AudioManager>();
    }

    public void Init()
    {
        AudioButtonImage.sprite = Globals.AudioOn ? AudioOnSprite : AudioOffSprite;
        MusicButtonImage.sprite = Globals.MusicOn ? MusicOnSprite : MusicOffSprite;
        MoodColor[] moodObjects = GameObject.FindObjectsOfType<MoodColor>(true);
        for (int i = 0; i < moodObjects.Length; i++)
        {
            moodObjects[i].UpdateGameMood(Globals.Mood);
        }
        DayNightButtonImage.sprite = Globals.Mood == Globals.GameMood.Day
            ? DaySprite
            : Globals.Mood == Globals.GameMood.Night ? NightSprite : FireSprite;
        Camera.main.backgroundColor = Globals.Mood == Globals.GameMood.Day
            ? new Color (114f/255f, 180f/255f, 246f/255f)
            : Globals.Mood == Globals.GameMood.Night ? new Color (87f/255f, 44f/255f, 153f/255f) : new Color (255f/255f, 110f/255f, 20f/255f);
    }

    public void SelectAudioButton()
    {
        Globals.AudioOn = !Globals.AudioOn;
        audioManager.PlayMenuSound();
        AudioButtonImage.sprite = Globals.AudioOn ? AudioOnSprite : AudioOffSprite;
        Globals.SaveIntToPlayerPrefs(Globals.AudioPlayerPrefsKey, Globals.AudioOn ? 1 : 0);
    }
    public void SelectMusicButton()
    {
        Globals.MusicOn = !Globals.MusicOn;
        audioManager.PlayMenuSound();
        if (Globals.MusicOn)
            audioManager.StartMusic();
        else
            audioManager.StopMusic();
        MusicButtonImage.sprite = Globals.MusicOn ? MusicOnSprite : MusicOffSprite;
        Globals.SaveIntToPlayerPrefs(Globals.MusicPlayerPrefsKey, Globals.MusicOn ? 1 : 0);
    }
    public void SelectDayNightButton()
    {
        if (Globals.Mood == Globals.GameMood.Day)
            Globals.Mood = Globals.GameMood.Night;
        else if (Globals.Mood == Globals.GameMood.Night)
            Globals.Mood = Globals.GameMood.Fire;
        else if (Globals.Mood == Globals.GameMood.Fire)
            Globals.Mood = Globals.GameMood.Day;
        audioManager.PlayMenuSound();
        MoodColor[] moodObjects = GameObject.FindObjectsOfType<MoodColor>(true);
        for (int i = 0; i < moodObjects.Length; i++)
        {
            moodObjects[i].UpdateGameMood(Globals.Mood);
        }

        DayNightButtonImage.sprite = Globals.Mood == Globals.GameMood.Day
            ? DaySprite
            : Globals.Mood == Globals.GameMood.Night ? NightSprite : FireSprite;
        Camera.main.backgroundColor = Globals.Mood == Globals.GameMood.Day
            ? new Color (114f/255f, 180f/255f, 246f/255f)
            : Globals.Mood == Globals.GameMood.Night ? new Color (87f/255f, 44f/255f, 153f/255f) : new Color (255f/255f, 110f/255f, 20f/255f);
        Globals.SaveIntToPlayerPrefs(Globals.GameMoodPlayerPrefsKey, (int)Globals.Mood);
    }
}
