using Unity.VisualScripting;
using UnityEngine;

public class Nogi : MonoBehaviour
{
    public bool isTouchGround;
    void Start()
    {
        
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
