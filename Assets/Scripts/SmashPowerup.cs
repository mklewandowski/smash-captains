using UnityEngine;

public class SmashPowerup : SmashItem
{
    void OnTriggerEnter(Collider collider)
    {
        Player player = collider.gameObject.GetComponent<Player>();
        if (player != null && Globals.CurrentGameState == Globals.GameState.Playing)
        {
            audioManager.PlayPowerupSound();

            int debrisAmount = 10;
            debrisManager.StartDebris (debrisAmount, this.transform.position, debrisColor);

            float newSpeed = Mathf.Min(Globals.maxSpeed, Globals.ScrollSpeed.x + 1f);
            Globals.ScrollSpeed = new Vector2(newSpeed, Globals.ScrollSpeed.y);

            Destroy(this.gameObject);
        }
    }
}
