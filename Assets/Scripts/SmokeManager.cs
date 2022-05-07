using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeManager : MonoBehaviour
{
    [SerializeField]
    GameObject SmokeContainer;
    [SerializeField]
    GameObject SmokePrefab;
    GameObject[] smokePool = new GameObject[200];
    Smoke[] smokeScripts = new Smoke[200];

    float smokeTimer = 0f;
    float smokeTimerMax = .05f;

    // Start is called before the first frame update
    void Start()
    {
        for (int x = 0; x < smokePool.Length; x++) {
            smokePool[x] = (GameObject)Instantiate (SmokePrefab, new Vector3 (100f, 100f, 100f), Quaternion.identity, SmokeContainer.transform);
            smokeScripts[x] = smokePool[x].GetComponent<Smoke>();
        }
    }

    void Update()
    {
        smokeTimer -= Time.deltaTime;
        if (smokeTimer <= 0)
        {
            StartSmoke(Random.Range(4, 6), Color.white);
            smokeTimer = smokeTimerMax;
        }
    }

    public void StartSmoke(int amount, Color color)
    {
        int count = 0;
        for (int x = 0; x < smokePool.Length; x++)
        {
            Vector3 position = this.transform.position;
            position.x = position.x + Random.Range(0, -.4f);
            position.y = position.y + Random.Range(-.18f, .18f);
            position.z = position.z + Random.Range(-.18f, .18f);
            if (!smokeScripts[x].InUse)
            {
                count++;
                smokeScripts[x].Use(position, color);
            }
            if (count >= amount)
                break;
        }
    }
}
