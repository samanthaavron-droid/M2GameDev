using Unity.VisualScripting;
using UnityEngine;
public class WetGround : MonoBehaviour
{
    [Range(0, 10)]
    public int dampFactor;
    void Start()
    {

    }
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Rigidbody2D>() != null)
        {
            collision.attachedRigidbody.angularDamping = dampFactor;
            collision.attachedRigidbody.linearDamping = dampFactor;
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Rigidbody2D>() != null)
        {
            collision.attachedRigidbody.angularDamping = 0.1f;
            collision.attachedRigidbody.linearDamping = 0f;
        }
        
    }
}
