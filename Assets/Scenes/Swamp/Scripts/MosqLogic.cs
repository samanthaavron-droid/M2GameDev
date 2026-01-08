using System.Collections;
using TMPro;
using UnityEngine;

public class MosqLogic : MonoBehaviour
{
    public Transform rotationPoint;
    public GameObject Parent;

    private Rzaba player;

    Rigidbody2D rb;
    Collider2D colidr;
    SpriteRenderer renderr;

    public float speed = 2.0f;
    public float flyingSpeed;
    public float delay = 3.0f;
    public MosqState currState = MosqState.Wander;

    public static int spawnCount = 0;

    Vector3 axis = new Vector3(0, 0, 1);

    public enum MosqState
    {
        Wander,
        Attack,
        Dead
    };
    private void Awake()
    {
        spawnCount++;
        print("spawnCount: " + spawnCount);
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        player = MosqManager.instance.Player;

        StartCoroutine(Waitspawn());

        flyingSpeed = Random.Range(-270, 270);
    }

    void Update()
    {
        switch (currState)
        {
            case (MosqState.Wander):
                Wander();
                break;
            case (MosqState.Attack):
                Attack();
                break;
            case (MosqState.Dead):
                Dead();
                break;
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (!player.noga.isTouchGround)
            {
                MosqManager.instance.MosqMan();
                Dead();
            } else if (player.noga.isTouchGround)
            {
                MosqManager.instance.GameOver();
            }

        }
    }
    void Wander()
    {
        transform.RotateAround(rotationPoint.position, axis, flyingSpeed * Time.deltaTime);
        transform.rotation = new Quaternion(0, 0, 0, 0);
    }
    void Attack()
    {
        transform.RotateAround(rotationPoint.position, axis, flyingSpeed * Time.deltaTime);
        transform.rotation = new Quaternion(0, 0, 0, 0);

        rotationPoint.position = Vector2.MoveTowards(rotationPoint.position, new Vector2(player.transform.position.x, player.transform.position.y), speed * Time.deltaTime);
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(rotationPoint.position.x, rotationPoint.position.y, 0), (speed  / 2) * Time.deltaTime);
    }
    void Dead()
    {
        Destroy(Parent);
    }
    private IEnumerator Waitspawn()
    {
        yield return new WaitForSeconds(delay);
        currState = MosqState.Attack;
    }
}