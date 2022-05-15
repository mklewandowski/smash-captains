using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smoke : MonoBehaviour
{
    public bool InUse = false;
    float lifeTimer = 0f;
    float smokeSpeed = -3f;
    float rotation = 0f;

    void Update()
    {
        if (lifeTimer > 0)
        {
            lifeTimer -= Time.deltaTime;
            if (lifeTimer <= 0)
            {
                StopUse();
            }
        }
    }

    void FixedUpdate()
    {
        if (InUse)
        {
            float scrollSpeed = Globals.CurrentGameState == Globals.GameState.Playing
                ? Globals.ScrollSpeed.x * Globals.ScrollDirection.x
                : 0f;
            Vector2 movement = new Vector2 (scrollSpeed + smokeSpeed, 0);
            this.GetComponent<Rigidbody>().velocity = movement;
            transform.Rotate(new Vector3(rotation, 0, 0));
        }
    }

    public void Use(Vector3 position, Color color)
    {
        InUse = true;

        gameObject.GetComponent<Renderer>().material.color = color;

        this.transform.position = position;
        lifeTimer = Random.Range (2f, 2.5f);

        float newscale = Random.Range (.1f, .2f);
        transform.localScale =  new Vector3 (newscale, newscale, newscale);

        smokeSpeed = Random.Range (-2f, -2.5f);

        rotation = Random.Range (.1f, 2f);

        this.gameObject.SetActive (true);
    }

    public void StopUse()
    {
        InUse = false;
        this.gameObject.SetActive (false);
        this.transform.position = new Vector3 (100f, 100f, 100f);
    }
}
