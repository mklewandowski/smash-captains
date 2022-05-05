using UnityEngine;

public class SmashEnemy : SmashItem
{
    void OnTriggerEnter(Collider collider)
    {
        Player player = collider.gameObject.GetComponent<Player>();
        if (player != null && Globals.CurrentGameState == Globals.GameState.Playing)
        {
            audioManager.PlaySmashSound();

            int debrisMax = itemType == ItemTypes.Wall ? 20 : 15;
            int debrisAmount = Random.Range(10, debrisMax);
            debrisManager.StartDebris (debrisAmount, this.transform.position, debrisColor);

            Camera.main.GetComponent<CameraShake>().StartShake();

            float newSpeed = Mathf.Max(Globals.minSpeed, Globals.ScrollSpeed.x - 1f);
            Globals.ScrollSpeed = new Vector2(newSpeed, Globals.ScrollSpeed.y);

            Destroy(this.gameObject);
        }
    }
}
