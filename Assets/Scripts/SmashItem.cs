using UnityEngine;

public class SmashItem : MonoBehaviour
{
    public enum ItemTypes {
        Arrow,
        Robot,
        Wall
    }
    public ItemTypes itemType = ItemTypes.Arrow;
    protected Color debrisColor;
    protected DebrisManager debrisManager;

    protected AudioManager audioManager;
    protected SceneManager sceneManager;

    void Awake()
    {
        audioManager = GameObject.Find("SceneManager").GetComponent<AudioManager>();
        sceneManager = GameObject.Find("SceneManager").GetComponent<SceneManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        if (itemType == ItemTypes.Arrow)
        {
            debrisColor = new Color(237f, 0, 203f);
        }
        else if (itemType == ItemTypes.Robot)
        {
            debrisColor = Color.gray;
        }
        else if (itemType == ItemTypes.Wall)
        {
            debrisColor = Color.red;
        }

        GameObject dm = GameObject.Find ("DebrisManager");
        debrisManager = dm.GetComponent<DebrisManager> ();
    }

    void Update()
    {
        if (Globals.CurrentGameState == Globals.GameState.ShowScore)
        {
            int debrisAmount = 10;
            debrisManager.StartDebris (debrisAmount, this.transform.position, debrisColor);
            Destroy(this.gameObject);
        }
    }

    void FixedUpdate()
    {
        if (Globals.CurrentGameState == Globals.GameState.Playing || Globals.CurrentGameState == Globals.GameState.ShowScore)
        {
            Vector2 movement = new Vector2 (Globals.ScrollSpeed.x * Globals.ScrollDirection.x, 0);
            this.GetComponent<Rigidbody>().velocity = movement;
        }
    }
}
