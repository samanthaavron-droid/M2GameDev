using UnityEngine;

public class Nogi : MonoBehaviour
{
    private Rzaba GroundM;
    public bool isTouchGround;

    void Start()
    {
        GroundM = GetComponentInParent<Rzaba>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isTouchGround = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isTouchGround = false;
        }
    }
}
