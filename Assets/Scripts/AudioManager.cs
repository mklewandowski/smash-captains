using UnityEngine;

public class AudioManager : MonoBehaviour
{
    AudioSource audioSource;

    [SerializeField]
    AudioClip MenuSound;
    [SerializeField]
    AudioClip StartSound;
    [SerializeField]
    AudioClip PowerupSound;
    [SerializeField]
    AudioClip SmashSound;

    void Awake()
    {
        audioSource = this.GetComponent<AudioSource>();
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

    public void PlayPowerupSound()
    {
        if (Globals.AudioOn)
            audioSource.PlayOneShot(PowerupSound, 1f);
    }

    public void PlaySmashSound()
    {
        if (Globals.AudioOn)
            audioSource.PlayOneShot(SmashSound, 1f);
    }

}
