using UnityEngine;

public class PositionClamper : MonoBehaviour
{
    public float offset;
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (transform.position.x > 0)
            {
                Vector3 teleport = new Vector3(-collision.gameObject.transform.position.x + offset, collision.gameObject.transform.position.y, 0);
                collision.gameObject.transform.position = teleport;
            }
            if (transform.position.x < 0)
            {
                Vector3 teleport = new Vector3(-collision.gameObject.transform.position.x - offset, collision.gameObject.transform.position.y, 0);
                collision.gameObject.transform.position = teleport;
            }
        }
    }
}
