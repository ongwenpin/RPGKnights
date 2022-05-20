using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawn : MonoBehaviour
{

    private int minCoin = 3;
    private int maxCoin = 6;
    private int count;

    void Start()
    {
        count = Random.Range(minCoin, maxCoin);
    }

    public GameObject prefab = null;

    public GameObject Prefab
    {
        get { return this.prefab; }
        set { this.prefab = value; }
    }

    public void Spawn()
    {
        for (int i = 0; i < count; i++)
        {
            Instantiate(this.prefab, new Vector2(this.transform.position.x - 0.1f * count,
                this.transform.position.y), Quaternion.identity);
        }
    }
}
