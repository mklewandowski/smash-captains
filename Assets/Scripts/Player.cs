using UnityEngine;

public class Player : MonoBehaviour
{
    AudioManager audioManager;

    Vector3 movement = new Vector3(0, 0, 0);
    float gravity = -10f;
    bool thrust = false;
    bool isGrounded = false;
    float speedRange = 6f;
    float maxAngle = 35f;

    void Awake()
    {
        audioManager = this.GetComponent<AudioManager>();
    }

    void Update() {
        thrust = Input.GetKey ("space") | Input.GetButton ("Fire1") | Input.GetButton ("Fire2");

        movement.y += gravity * Time.deltaTime;
        //user "thrust", give plane some upward movement
        if (thrust && Globals.CurrentGameState == Globals.GameState.Playing)
        {
            movement.y += 25f * Time.deltaTime;
            isGrounded = false;
        }
        movement.y = Mathf.Max(movement.y, -6.0f);
        movement.y = Mathf.Min(movement.y, 6.0f);
        this.gameObject.GetComponent<Rigidbody> ().velocity = movement;

        //what is the min position based on the current angle?
        float minYPos = -3.3f;
        float adjustAmount = .45f;
        float anglePercent = (movement.y / speedRange);
        minYPos = minYPos - adjustAmount * anglePercent;

        //did we hit the ground?, stop it if we did
        if(transform.localPosition.y <= minYPos)
        {
            isGrounded = true;
            transform.localPosition = new Vector3 (transform.localPosition.x, minYPos, transform.localPosition.z);
            movement.y = 0f;
            this.gameObject.GetComponent<Rigidbody> ().velocity = movement;
        }

        //don't let the ship go offscreen to the top
        else if (transform.localPosition.y >= 3f)
        {
            transform.localPosition = new Vector3 (transform.localPosition.x, 3f, transform.localPosition.z);
            if (movement.y > 0)
                movement.y -= 30f * Time.deltaTime;
            else
                movement.y -= 10f * Time.deltaTime;
            this.gameObject.GetComponent<Rigidbody> ().velocity = movement;
        }

        //set the rotation of plane
        float newRotation = 0f;
        newRotation = maxAngle * (movement.y / speedRange);
        this.transform.eulerAngles = new Vector3 (0, 0, newRotation);
    }
}
