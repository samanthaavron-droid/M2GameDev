using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private List<GameObject> Inventory = new List<GameObject>();
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (Inventory.Count > 1)
                ReplaceItem();
            else
                Debug.Log("Inventory is empty");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Item"))
        {
            collision.gameObject.SetActive(false);

            Inventory.Add(collision.gameObject);
            Debug.Log("Item Collected: " + collision.gameObject);
        }
    }

    void ReplaceItem()
    {
        Inventory.Last().SetActive(true);
        Inventory.Last().transform.position = gameObject.transform.position + new Vector3(0, 1, 0);


        Inventory.RemoveAt(Inventory.Count - 1);
        Debug.Log("Item thrown out");
    }
}
