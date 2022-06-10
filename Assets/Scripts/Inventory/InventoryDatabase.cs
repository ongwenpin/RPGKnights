using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryDatabase : MonoBehaviour
{
    public static InventoryDatabase instance;
    public static List<GameObject> CurrentItems = new List<GameObject>();
    public static bool update;

    public static List<GameObject> currentEquip = new List<GameObject>();
    private void Start()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (update)
        {
            foreach (GameObject item in CurrentItems)
            {
                if (!FindObjectOfType<Inventory>().ContainsItem(item))
                    Debug.Log(item.name);
                    FindObjectOfType<Inventory>().AddItem(item);
            }

            foreach (GameObject equip in currentEquip)
            {
                FindObjectOfType<Inventory>().DirectEquip(equip);
            }
            

            update = false;
        }
       
    }
}