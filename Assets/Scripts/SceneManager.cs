using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SceneManager : MonoBehaviour
{
    AudioManager audioManager;

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
    GameObject SpeedUpMessage;
    float SpeedUpTimer = 0f;

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
	GameObject SpeedPowerupPrefab;
    [SerializeField]
    GameObject WallPrefab;

    float finishLineXPos = 800f;

    void Awake()
    {
        Application.targetFrameRate = 60;

        Globals.BestTime = Globals.LoadFloatFromPlayerPrefs(Globals.BestTimePlayerPrefsKey);

        HUDTitle.GetComponent<MoveNormal>().MoveRight();
        HUDButtons.GetComponent<MoveNormal>().MoveUp();

        audioManager = this.GetComponent<AudioManager>();
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
            audioManager.PlayRaceGoSound();
        }
    }

    void UpdatePlaying()
    {
        Globals.CurrentTime += Time.deltaTime;
        HUDTimeInt.text = ((int)Mathf.Floor(Globals.CurrentTime)).ToString();
        float decTimePart = (int)(Globals.CurrentTime * 100f % 100);
        HUDTimeDec.text = (decTimePart < 10 ? "0" : "") + decTimePart.ToString();

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

    public void SpeedUp()
    {
        float newSpeed = Mathf.Min(Globals.maxSpeed, Globals.ScrollSpeed.x + 1f);
        Globals.ScrollSpeed = new Vector2(newSpeed, Globals.ScrollSpeed.y);

        SpeedUpTimer = 2.5f;
        SpeedUpMessage.transform.localScale = new Vector3(.1f, .1f, .1f);
        SpeedUpMessage.SetActive(true);
        SpeedUpMessage.GetComponent<GrowAndShrink>().StartEffect();
        SpeedUpMessage.GetComponent<WaitAndHide>().StartEffect();
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

        CreateCourse();

        HUDRaceReady.SetActive(true);
        HUDRaceReady.GetComponent<GrowAndShrink>().StartEffect();

        Globals.CurrentGameState = Globals.GameState.Ready;
    }

    public void CreateCourse()
    {
        FinishLine.transform.localPosition = new Vector3(finishLineXPos, FinishLine.transform.localPosition.y, FinishLine.transform.localPosition.z);

        int startOffset = 14;
        int endOffset = 8;
        int wallToAdd = 0;
        float wallYPos = 0f;
        for (int x = 0; x < finishLineXPos; x++)
        {
            if (x > startOffset && x < (finishLineXPos - endOffset))
            {
                if (x % 2 == 0 && wallToAdd > 0)
                {
                    // add a wall
                    GameObject wall = (GameObject)Instantiate(WallPrefab, new Vector3(x, wallYPos, 3f), Quaternion.identity);
                    wall.transform.localEulerAngles = new Vector3(0f, 240f, 0f);
                    wallToAdd--;
                }
                else if (x % 4 == 0)
                {
                    // add nothing, a wall, an enemy, a powerup, or a robot
                    float randomVal = Random.Range(0f, 100.0f);
                    if (randomVal < 30f)
                    {
                        // powerup
                        GameObject powerup = (GameObject)Instantiate(SpeedPowerupPrefab, new Vector3(x, Random.Range(-3.5f, 3f), 3f), Quaternion.identity);
                    }
                    else if (randomVal < 55f)
                    {
                        // robot
                        GameObject enemy = (GameObject)Instantiate(EnemyPrefab, new Vector3(x, Random.Range(-2.4f, 2.6f), 3f), Quaternion.identity);
                    }
                   else if (randomVal < 80f)
                    {
                        // wall
                        wallYPos = Random.Range(0f, 100.0f) > 50f ? -2.8f : 4f;
                        wallToAdd = Random.Range(0, 4);
                        GameObject wall = (GameObject)Instantiate(WallPrefab, new Vector3(x, wallYPos, 3f), Quaternion.identity);
                        wall.transform.localEulerAngles = new Vector3(0f, 240f, 0f);
                    }
                }
            }
        }
    }

    public void EndGame()
    {
        Globals.ScrollSpeed = new Vector2(0, 0);
        HUDRaceComplete.SetActive(true);
        HUDRaceComplete.GetComponent<GrowAndShrink>().StartEffect();
        if (Globals.CurrentTime < Globals.BestTime || Globals.BestTime == 0f)
        {
            Globals.BestTime = Globals.CurrentTime;
            Globals.SaveFloatToPlayerPrefs(Globals.BestTimePlayerPrefsKey, Globals.BestTime);
        }
        HUDFinalTime.text = Globals.CurrentTime.ToString("F2");
        HUDBestTime.text = Globals.BestTime.ToString("F2");
        showScoreTimer = 3f;
        Globals.CurrentGameState = Globals.GameState.ShowScore;

        audioManager.PlayFanfareSound();
        ReleaseBalloons();
    }

    public void ReleaseBalloons()
    {
        Balloon[] balloons = GameObject.FindObjectsOfType<Balloon>(true);
        for (int i = 0; i < balloons.Length; i++)
        {
            balloons[i].InitBalloon();
            balloons[i].ReleaseBalloon();
        }
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
