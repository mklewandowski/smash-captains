using UnityEngine;

public class SmashEnemy : SmashItem
{
    void OnTriggerEnter(Collider collider)
    {
        Player player = collider.gameObject.GetComponent<Player>();
        if (player != null && Globals.CurrentGameState == Globals.GameState.Playing && isActive)
        {
            isActive = false;

            audioManager.PlaySmashSound();

            int debrisMax = itemType == ItemType.Wall ? 20 : 15;
            int debrisAmount = Random.Range(10, debrisMax);
            debrisManager.StartDebris (debrisAmount, this.transform.position, debrisColor);

            Camera.main.GetComponent<CameraShake>().StartShake();

            if (!sceneManager.IsInvincible())
            {
                Globals.NumHits++;
                float newSpeed = Mathf.Max(Globals.minSpeed, Globals.ScrollSpeed.x - 1f);
                Globals.ScrollSpeed = new Vector2(newSpeed, Globals.ScrollSpeed.y);
            }
            Globals.NumEnemiesSmashed++;
            Destroy(this.gameObject);
        }
    }

    public void BombEnemy()
    {
        isActive = false;
        int debrisAmount = 10;
        debrisManager.StartDebris (debrisAmount, this.transform.position, debrisColor);
        Globals.NumEnemiesSmashed++;
        Destroy(this.gameObject);
    }
}
