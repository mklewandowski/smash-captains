using UnityEngine;

public class FinishLine : MonoBehaviour
{
    [SerializeField]
    GameObject TrackProgressMarker;

    void Update()
    {
        if (Globals.CurrentGameState == Globals.GameState.Ready || Globals.CurrentGameState == Globals.GameState.Playing)
        {
            float percentComplete = (Globals.finishLineXPos - this.transform.localPosition.x) / Globals.finishLineXPos;
            TrackProgressMarker.transform.localPosition = new Vector3(-289f + 578f * percentComplete,
                TrackProgressMarker.transform.localPosition.y, TrackProgressMarker.transform.localPosition.z);
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

    void OnTriggerEnter(Collider collider)
    {
        Player player = collider.gameObject.GetComponent<Player>();
        if (player != null && Globals.CurrentGameState == Globals.GameState.Playing)
        {
            GameObject.Find("SceneManager").GetComponent<SceneManager>().EndGame();
        }
    }
}
