using UnityEngine;

public class SmashItem : MonoBehaviour
{
    public enum ItemType {
        Arrow,
        Star,
        Robot,
        Wall,
        Bomb
    }
    public ItemType itemType = ItemType.Arrow;
    protected Color debrisColor;
    protected DebrisManager debrisManager;

    protected AudioManager audioManager;
    protected SceneManager sceneManager;

    protected bool isActive = true;

    void Awake()
    {
        audioManager = GameObject.Find("SceneManager").GetComponent<AudioManager>();
        sceneManager = GameObject.Find("SceneManager").GetComponent<SceneManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        if (itemType == ItemType.Arrow)
        {
            debrisColor = Color.yellow;
        }
        if (itemType == ItemType.Star)
        {
            debrisColor = new Color(0, 85f / 255f, 0);
        }
        else if (itemType == ItemType.Robot)
        {
            debrisColor = Color.gray;
        }
        else if (itemType == ItemType.Wall)
        {
            debrisColor = Color.red;
        }
        else if (itemType == ItemType.Bomb)
        {
            debrisColor = Color.black;
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
