using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SceneManager : MonoBehaviour
{
    AudioManager audioManager;
    SettingsManager settingsManager;

    [SerializeField]
    GameObject Player;

    [SerializeField]
    GameObject Level;
    [SerializeField]
    GameObject[] Clouds;
    [SerializeField]
    GameObject[] Stumps;
    [SerializeField]
    GameObject[] Tracks;

    // titles and messages
    [SerializeField]
    GameObject HUDPlayer;
    [SerializeField]
    GameObject HUDAbout;
    [SerializeField]
    GameObject HUDSettings;
    [SerializeField]
    GameObject HUDTitle;
    [SerializeField]
    GameObject HUDButtons;
    [SerializeField]
    GameObject HUDPlanes;

    [SerializeField]
    GameObject HUDRaceReady;
    [SerializeField]
    GameObject HUDTime;
    [SerializeField]
    TextMeshProUGUI HUDTimeInt;
    [SerializeField]
    TextMeshProUGUI HUDTimeDec;
    [SerializeField]
    GameObject HUDSpeed;
    [SerializeField]
    GameObject FinishLine;

    [SerializeField]
    GameObject HUDRaceComplete;
    [SerializeField]
    GameObject HUDGameOver;
    [SerializeField]
    GameObject HUDFinalTimeContainer;
    [SerializeField]
    TextMeshProUGUI HUDFinalTime;
    [SerializeField]
    TextMeshProUGUI HUDBestTime;
    float showScoreTimer = 3f;

    // smash items
    [SerializeField]
	GameObject EnemyPrefab;
    [SerializeField]
	GameObject PowerupPrefab;

    float finishLineXPos = 100f;
    float powerupTimer = 3f;
    float enemyTimer = 5;

    void Awake()
    {
        Application.targetFrameRate = 60;

        Globals.BestTime = Globals.LoadFloatFromPlayerPrefs(Globals.BestTimePlayerPrefsKey);
        int audioOn = Globals.LoadIntFromPlayerPrefs(Globals.AudioPlayerPrefsKey, 1);
        int musicOn = Globals.LoadIntFromPlayerPrefs(Globals.MusicPlayerPrefsKey, 1);
        Globals.AudioOn = audioOn == 1 ? true : false;
        Globals.MusicOn = musicOn == 1 ? true : false;

        HUDTitle.GetComponent<MoveNormal>().MoveRight();
        HUDButtons.GetComponent<MoveNormal>().MoveUp();

        audioManager = this.GetComponent<AudioManager>();
        settingsManager = this.GetComponent<SettingsManager>();
        settingsManager.Init();
    }

    // Update is called once per frame
    void Update()
    {
        if (Globals.CurrentGameState == Globals.GameState.Ready)
        {
            UpdateReady();
        }
        else if (Globals.CurrentGameState == Globals.GameState.Playing)
        {
            UpdatePlaying();
        }
        else if (Globals.CurrentGameState == Globals.GameState.ShowScore)
        {
            UpdateShowScore();
        }
    }

    void FixedUpdate()
    {
        if (Globals.CurrentGameState == Globals.GameState.Playing || Globals.CurrentGameState == Globals.GameState.ShowScore)
        {
            Vector2 cloudMovement = new Vector2 (Globals.ScrollSpeed.x * Globals.ScrollDirection.x * .45f, 0);
            for (int i = 0; i < Clouds.Length; i++)
            {
                Clouds[i].GetComponent<Rigidbody>().velocity = cloudMovement;
            }
            Vector2 stumpMovement = new Vector2 (Globals.ScrollSpeed.x * Globals.ScrollDirection.x, 0);
            for (int i = 0; i < Stumps.Length; i++)
            {
                Stumps[i].GetComponent<Rigidbody>().velocity = stumpMovement;
            }
            Vector2 trackMovement = new Vector2 (Globals.ScrollSpeed.x * Globals.ScrollDirection.x, 0);
            for (int i = 0; i < Tracks.Length; i++)
            {
                Tracks[i].GetComponent<Rigidbody>().velocity = stumpMovement;
            }
        }
    }

    void UpdateReady()
    {
        if (Input.GetKey ("space") | Input.GetButton ("Fire1") | Input.GetButton ("Fire2"))
        {
            HUDRaceReady.SetActive(false);
            HUDRaceReady.transform.localScale = new Vector3(.1f, .1f, .1f);
            Globals.ScrollSpeed = new Vector2(6f, 0);
            Globals.CurrentGameState = Globals.GameState.Playing;
        }
    }

    void UpdatePlaying()
    {
        Globals.CurrentTime += Time.deltaTime;
        HUDTimeInt.text = ((int)Mathf.Floor(Globals.CurrentTime)).ToString();
        float decTimePart = (int)(Globals.CurrentTime * 100f % 100);
        HUDTimeDec.text = (decTimePart < 10 ? "0" : "") + decTimePart.ToString();

        enemyTimer -= Time.deltaTime;
        if (enemyTimer <= 0)
        {
            GameObject enemy = (GameObject)Instantiate(EnemyPrefab, new Vector3(15f, Random.Range(-3.5f, 2.5f), 3f), Quaternion.identity);
            enemyTimer = Random.Range(3f, 5f);
        }
        powerupTimer -= Time.deltaTime;
        if (powerupTimer <= 0)
        {
            GameObject powerup = (GameObject)Instantiate(PowerupPrefab, new Vector3(15f, Random.Range(-3.5f, 3f), 3f), Quaternion.identity);
            powerupTimer = Random.Range(2f, 4f);
        }

        float cloudMinX = -15f;
        for (int i = 0; i < Clouds.Length; i++)
        {
            if (Clouds[i].transform.localPosition.x < cloudMinX)
            {
                Clouds[i].transform.localPosition = new Vector3(15f, Clouds[i].transform.localPosition.y, Clouds[i].transform.localPosition.z);
            }
        }
        float stumpMinX = -15f;
        for (int i = 0; i < Stumps.Length; i++)
        {
            if (Stumps[i].transform.localPosition.x < stumpMinX)
            {
                int abutIndex = i == 0 ? Stumps.Length - 1 : i - 1;
                Renderer renderer = Stumps[abutIndex].GetComponentInChildren(typeof(Renderer)) as Renderer;
                Stumps[i].transform.localPosition = new Vector3(
                        Stumps[abutIndex].transform.localPosition.x + renderer.bounds.size.x + .1f,
                        Stumps[i].transform.localPosition.y,
                        Stumps[i].transform.localPosition.z
                    );
            }
        }
        float trackMinX = -20f;
        for (int i = 0; i < Tracks.Length; i++)
        {
            if (Tracks[i].transform.localPosition.x < trackMinX)
            {
                int abutIndex = i == 0 ? Tracks.Length - 1 : i - 1;
                Renderer renderer = Tracks[abutIndex].GetComponentInChildren(typeof(Renderer)) as Renderer;
                Tracks[i].transform.localPosition = new Vector3(
                        Tracks[abutIndex].transform.localPosition.x + renderer.bounds.size.x,
                        Tracks[i].transform.localPosition.y,
                        Tracks[i].transform.localPosition.z
                    );
            }
        }
    }

    void UpdateShowScore()
    {
        showScoreTimer -= Time.deltaTime;
        if (showScoreTimer <= 0)
        {
            HUDRaceComplete.SetActive(false);
            HUDRaceComplete.transform.localScale = new Vector3(.1f, .1f, .1f);
            HUDFinalTimeContainer.transform.localPosition = new Vector3(0, 0, 0);
            HUDButtons.GetComponent<MoveNormal>().MoveUp();
            HUDGameOver.GetComponent<MoveNormal>().MoveDown();
            Globals.CurrentGameState = Globals.GameState.Restart;
        }
    }

    public void StartGame()
    {
        if (Globals.CurrentGameState != Globals.GameState.TitleScreen && Globals.CurrentGameState != Globals.GameState.Restart)
            return;

        audioManager.PlayStartSound();

        HUDGameOver.GetComponent<MoveNormal>().MoveUp();
        HUDPlayer.SetActive(false);
        HUDAbout.GetComponent<MoveNormal>().MoveRight();
        HUDSettings.GetComponent<MoveNormal>().MoveRight();
        HUDTitle.GetComponent<MoveNormal>().MoveLeft();
        HUDButtons.GetComponent<MoveNormal>().MoveDown();
        Level.SetActive(true);
        Player.SetActive(true);

        Globals.CurrentTime = 0;
        HUDTimeInt.text = "0";
        HUDTimeDec.text = "0";
        HUDTime.SetActive(true);
        HUDSpeed.SetActive(true);

        powerupTimer = 3f;
        enemyTimer = 5;

        FinishLine.transform.localPosition = new Vector3(finishLineXPos, FinishLine.transform.localPosition.y, FinishLine.transform.localPosition.z);

        HUDRaceReady.SetActive(true);
        HUDRaceReady.GetComponent<GrowAndShrink>().StartEffect();

        Globals.CurrentGameState = Globals.GameState.Ready;
    }

    public void EndGame()
    {
        Globals.ScrollSpeed = new Vector2(0, 0);
        HUDRaceComplete.SetActive(true);
        HUDRaceComplete.GetComponent<GrowAndShrink>().StartEffect();
        if (Globals.CurrentTime < Globals.BestTime)
        {
            Globals.BestTime = Globals.CurrentTime;
            Globals.SaveFloatToPlayerPrefs(Globals.BestTimePlayerPrefsKey, Globals.BestTime);
        }
        HUDFinalTime.text = Globals.CurrentTime.ToString("F2");
        HUDBestTime.text = Globals.BestTime.ToString("F2");
        showScoreTimer = 3f;
        Globals.CurrentGameState = Globals.GameState.ShowScore;
    }

    public void SelectPlanesButton()
    {
        audioManager.PlayMenuSound();

        HUDButtons.GetComponent<MoveNormal>().MoveDown();
        HUDPlanes.GetComponent<MoveNormal>().MoveUp();

        HUDPlayer.GetComponent<MoveNormal>().MoveLeft();
        HUDAbout.GetComponent<MoveNormal>().MoveRight();
        HUDSettings.GetComponent<MoveNormal>().MoveRight();
        HUDFinalTimeContainer.GetComponent<MoveNormal>().MoveRight();
    }
    public void SelectPlanesBackButton()
    {
        audioManager.PlayMenuSound();

        HUDButtons.GetComponent<MoveNormal>().MoveUp();
        HUDPlanes.GetComponent<MoveNormal>().MoveDown();
    }
    public void SelectAboutButton()
    {
        audioManager.PlayMenuSound();

        HUDAbout.GetComponent<MoveNormal>().MoveLeft();
        HUDSettings.GetComponent<MoveNormal>().MoveRight();
        HUDPlayer.GetComponent<MoveNormal>().MoveRight();
        HUDFinalTimeContainer.GetComponent<MoveNormal>().MoveRight();
    }
    public void SelectSettingsButton()
    {
        audioManager.PlayMenuSound();

        HUDSettings.GetComponent<MoveNormal>().MoveLeft();
        HUDAbout.GetComponent<MoveNormal>().MoveRight();
        HUDPlayer.GetComponent<MoveNormal>().MoveRight();
        HUDFinalTimeContainer.GetComponent<MoveNormal>().MoveRight();
    }

}
