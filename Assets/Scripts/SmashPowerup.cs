using UnityEngine;

public class SmashPowerup : SmashItem
{
    void OnTriggerEnter(Collider collider)
    {
        Player player = collider.gameObject.GetComponent<Player>();
        if (player != null && Globals.CurrentGameState == Globals.GameState.Playing)
        {
            audioManager.PlayPowerupSound();

            int debrisAmount = Random.Range(10, 15);
            debrisManager.StartDebris (debrisAmount, this.transform.position, debrisColor);

            if (itemType == ItemTypes.Arrow)
                sceneManager.SpeedUp();

            Destroy(this.gameObject);
        }
    }
}
