using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.UI.Image;
public class Rzaba : MonoBehaviour
{
    private Rigidbody2D rb;
    public Nogi noga;

    public float jumpForce = 10f;
    public float rotationSpeed = 100f;

    public float moveInput;

    private Rigidbody2D curGround;
    private int LayerIgnoreRaycast;

    public bool debugMode;
    private void Awake()
    {
        LayerIgnoreRaycast = LayerMask.NameToLayer("IgnorePlayer");
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        noga = GetComponentInChildren<Nogi>();
    }
    void Update()
    {
        //Jumping
        if (Input.GetKeyDown(KeyCode.Space) && noga.isTouchGround == true)
        {
            Jump();
        }
        //Sticking to the current ground
        if (noga.isTouchGround)
        {
            Stick();
        }
    }
    private void FixedUpdate()
    {
        //Rolling movement system
        Rolling();
    }
    private void Rolling()
    {
        //Getting input
        moveInput = Input.GetAxisRaw("Horizontal");
        float targetTorque = moveInput * -rotationSpeed;

        //applying rotations
        rb.AddTorque(targetTorque * Time.fixedDeltaTime);

        //checking the change and stopping the rotation
        if (targetTorque * rb.angularVelocity < 0)
        {
            rb.angularVelocity = 0;
            //checking the ground
            if (noga.isTouchGround == true)
            {
                rb.linearVelocity = Vector2.zero;
            }
        }
    }
    private void Jump()
    {
        rb.AddRelativeForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
    
    private void Stick()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -transform.up);

        if (hit.collider != null && hit.collider.gameObject.layer != LayerIgnoreRaycast)
        {
            if (hit.distance <= 1)
            {
                hit.collider.gameObject.TryGetComponent<Rigidbody2D>(out curGround);

                rb.AddForce(curGround.GetPoint(hit.point) * 10, ForceMode2D.Force);

                if (debugMode)
                {
                    Debug.Log("Sticking to ground velocity: " + curGround.GetPointVelocity(hit.point));
                    Debug.DrawRay(transform.position, -transform.up, Color.green);
                }
                    
            }
        }
        else
        {
            curGround = null;
        }
    }
}