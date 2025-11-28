using System.Collections;
using System.Drawing;
using UnityEngine;

public class MosqitoeANIM : MonoBehaviour
{
    public GameObject centerOfRotation;
    Vector3 axis = new Vector3(0, 0, 1);

    public Collider2D colidr;
    public SpriteRenderer renderr;

    public GameObject Parent;
    void Start()
    {
        
    }
    void Update()
    {
        transform.RotateAround(centerOfRotation.transform.position, axis, 180 * Time.deltaTime);
        transform.rotation = new Quaternion(0, 0, 0, 0);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            MosqManager.instance.MosqMan();
            Destroy(Parent);
        }
    }

}
