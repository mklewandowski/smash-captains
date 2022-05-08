using UnityEngine;

public class AudioManager : MonoBehaviour
{
    AudioSource audioSource;
    SettingsManager settingsManager;

    [SerializeField]
    AudioClip MenuSound;
    [SerializeField]
    AudioClip StartSound;
    [SerializeField]
    AudioClip SpeedUpSound;
    [SerializeField]
    AudioClip InvincibleSound;
    [SerializeField]
    AudioClip SmashSound;
    [SerializeField]
    AudioClip FanfareSound;
    [SerializeField]
    AudioClip RaceGoSound;
    [SerializeField]
    AudioClip BombSound;

    void Awake()
    {
        audioSource = this.GetComponent<AudioSource>();
        int audioOn = Globals.LoadIntFromPlayerPrefs(Globals.AudioPlayerPrefsKey, 1);
        int musicOn = Globals.LoadIntFromPlayerPrefs(Globals.MusicPlayerPrefsKey, 1);
        Globals.AudioOn = audioOn == 1 ? true : false;
        Globals.MusicOn = musicOn == 1 ? true : false;
        if (Globals.MusicOn)
            audioSource.Play();

        int dayMode = Globals.LoadIntFromPlayerPrefs(Globals.DayModePlayerPrefsKey, 1);
        Globals.DayMode = dayMode == 1 ? true : false;

        settingsManager = this.GetComponent<SettingsManager>();
        settingsManager.Init();
    }

    public void StartMusic()
    {
        audioSource.Play();
    }
    public void StopMusic()
    {
        audioSource.Stop();
    }

    public void PlayMenuSound()
    {
        if (Globals.AudioOn)
            audioSource.PlayOneShot(MenuSound, 1f);
    }

    public void PlayStartSound()
    {
        if (Globals.AudioOn)
            audioSource.PlayOneShot(StartSound, 1f);
    }

    public void PlayRaceGoSound()
    {
        if (Globals.AudioOn)
            audioSource.PlayOneShot(RaceGoSound, 1f);
    }

    public void PlaySpeedUpSound()
    {
        if (Globals.AudioOn)
            audioSource.PlayOneShot(SpeedUpSound, .7f);
    }

    public void PlayInvincibleSound()
    {
        if (Globals.AudioOn)
            audioSource.PlayOneShot(InvincibleSound, 1f);
    }

    public void PlaySmashSound()
    {
        if (Globals.AudioOn)
            audioSource.PlayOneShot(SmashSound, 1f);
    }

    public void PlayFanfareSound()
    {
        if (Globals.AudioOn)
            audioSource.PlayOneShot(FanfareSound, 1f);
    }

    public void PlayBombSound()
    {
        if (Globals.AudioOn)
            audioSource.PlayOneShot(BombSound, 1f);
    }

}
