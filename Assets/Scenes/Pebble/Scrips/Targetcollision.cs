using UnityEngine;

public class Targetcollision : MonoBehaviour
{
    public int hitMax;
    public int ScoreWorth;
    void Start()
    {
        
    }

    void Update()
    {
        if (hitMax == 0)
        {
            gameObject.SetActive(false);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Hit!");
        hitMax += -1;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Finish"))
        {
            Destroy(gameObject);
        }
    }
}
