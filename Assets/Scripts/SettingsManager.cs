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

    void Awake()
    {
        audioManager = this.GetComponent<AudioManager>();
    }

    public void Init()
    {
        AudioButtonImage.sprite = Globals.AudioOn ? AudioOnSprite : AudioOffSprite;
        MusicButtonImage.sprite = Globals.MusicOn ? MusicOnSprite : MusicOffSprite;
        DayNightButtonImage.sprite = Globals.DayMode ? DaySprite : NightSprite;
        Camera.main.backgroundColor = Globals.DayMode ? new Color (114f/255f, 180f/255f, 246f/255f) : new Color (135f/255f, 67f/255f, 232f/255f);
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
        Globals.DayMode = !Globals.DayMode;
        audioManager.PlayMenuSound();
        DayNightButtonImage.sprite = Globals.DayMode ? DaySprite : NightSprite;
        Camera.main.backgroundColor = Globals.DayMode ? new Color (114f/255f, 180f/255f, 246f/255f) : new Color (135f/255f, 67f/255f, 232f/255f);
        Globals.SaveIntToPlayerPrefs(Globals.DayModePlayerPrefsKey, Globals.DayMode ? 1 : 0);
    }
}
