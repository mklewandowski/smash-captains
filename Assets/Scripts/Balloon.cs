using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{
    enum BalloonType {
        Pink,
        Blue,
        Purple
    }
    BalloonType type;

    [SerializeField]
    GameObject PinkBallon;
    [SerializeField]
    GameObject BlueBallon;
    [SerializeField]
    GameObject PurpleBallon;

    float movingUpVelocity = 2f;

    float startY = -7f;
    float endY = 10f;
    bool isMoving;

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            float newY = transform.localPosition.y + movingUpVelocity * Time.deltaTime;
            Vector3 newPos = new Vector3(transform.localPosition.x, newY, transform.localPosition.z);
            transform.localPosition = newPos;
            if (transform.localPosition.y > endY)
            {
                isMoving = false;
            }
        }
    }

    public void InitBalloon()
    {
        int rand = Random.Range(0, 3);
        type = (BalloonType)rand;
        PinkBallon.SetActive(type == BalloonType.Pink);
        BlueBallon.SetActive(type == BalloonType.Blue);
        PurpleBallon.SetActive(type == BalloonType.Purple);

        float size = Random.Range(.5f, 1.5f);
        transform.localScale = new Vector3(size, size, size);

        transform.localPosition = new Vector3(transform.localPosition.x, startY - Random.Range(0, 2f), transform.localPosition.z);

        movingUpVelocity = Random.Range(3f, 6f);
    }

    public void ReleaseBalloon()
    {
        isMoving = true;
    }
}
