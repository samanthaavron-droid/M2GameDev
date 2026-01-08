using UnityEngine;

public class WallStick : MonoBehaviour
{/*
    private Rigidbody2D playerRb;
    public Rzaba player;

    public bool stick;

    void Start()
    {
        player = GameObject.Find("Rzaba").GetComponent<Rzaba>();
        playerRb = player.GetComponent<Rigidbody2D>();
        stick = false;
    }

    void Update()
    {
        if (player.NogiCheck() == true) 
            stick = true;
        if (Input.GetKey(KeyCode.Space))
        {
            stick = false; 
            
            playerRb.angularDamping = 0.1f;
            playerRb.linearDamping = 0f;
        }
    }
    public void OnTriggerStay2D(Collider2D player)
    {
        if (stick)
        {
            playerRb.AddForce(-transform.up * 10);
            playerRb.angularDamping = 10f;
            playerRb.linearDamping = 10f;
        }
    }
    */
}
