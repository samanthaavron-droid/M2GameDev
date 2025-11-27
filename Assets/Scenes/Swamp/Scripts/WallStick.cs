using UnityEngine;

public class WallStick : MonoBehaviour
{
    private Rigidbody2D rb;
    public Rzaba player;

    public bool grounded;

    public bool stick = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Rzaba").GetComponent<Rzaba>();
    }

    void Update()
    {
        grounded = GameObject.Find("Rzaba").GetComponent<Rzaba>().isGrounded;

        if (grounded == true && (Input.GetKey(KeyCode.S)))
            stick = true;
        else if ((Input.GetKey(KeyCode.S)) == false)
            stick = false;

    }
    public void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && stick == true)
        {
            Rigidbody2D playerRb = collision.gameObject.GetComponent<Rigidbody2D>();
            playerRb.AddRelativeForce(Vector2.down * 50, ForceMode2D.Force);
            playerRb.angularDamping = 2f;
            playerRb.linearDamping = 2f;
        }
        else if (stick == false)
        {
            Rigidbody2D playerRb = collision.gameObject.GetComponent<Rigidbody2D>();
            playerRb.angularDamping = 0.05f;
            playerRb.linearDamping = 0f;
        }
    }
}
