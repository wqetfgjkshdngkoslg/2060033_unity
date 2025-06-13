using System.Collections;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    public GameObject applePrefab;
    public GameObject bombPrefab;

    float fSpawnInterval = 1.0f;
    float fTimeSinceLastSpawn = 0.0f;
    int nBombRatio = 2;
    float fDropSpeed = -0.03f;

    void Update()
    {
        fTimeSinceLastSpawn += Time.deltaTime;
        if (fTimeSinceLastSpawn > fSpawnInterval)
        {
            fTimeSinceLastSpawn = 0;
            GameObject item;
            int nDiceRoll = Random.Range(1, 11);
            if (nDiceRoll <= nBombRatio)
            {
                item = Instantiate(bombPrefab);
            }
            else
            {
                item = Instantiate(applePrefab);
            }

            float fxoff = Random.Range(-1, 2);
            float fzoff = Random.Range(-1, 2);
            item.transform.position = new Vector3(fxoff, 4, fzoff);
            item.GetComponent<ItemController>().fDropSpeed = fDropSpeed;
        }
    }

    public void SetParameters(float fInterval, float fSpeed, int nRatio)
    {
        fSpawnInterval = fInterval;
        fDropSpeed = fSpeed;
        nBombRatio = nRatio;
    }
}

