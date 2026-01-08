using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class StartScreen : MonoBehaviour
{
    public GameObject Screen; 
    public TextMeshProUGUI StartScreenUI;

    private Collider2D[] cl;
    private Rigidbody2D[] rb;
    void Start()
    {
        cl = GetComponentsInChildren<Collider2D>();
        rb = GetComponentsInChildren<Rigidbody2D>();

        StartScreenUI.enabled = true;

        StartCoroutine(ScreenStart());
    }

    void Update()
    {
        
    }
    private IEnumerator ScreenStart()
    {
        RigidbodyDisable();

        yield return new WaitForSeconds(5f);
        StartScreenUI.enabled = false;
        RigidbodyEnable();

        yield return new WaitForSeconds(2f);
        DisableCollidersOnText();
    }

    void DisableCollidersOnText()
    {
        foreach (Collider2D collider in cl)
        {
            collider.enabled = false;
        }
    }
    void RigidbodyEnable() 
    { 
        foreach (Rigidbody2D rigidbody in rb)
        {
            rigidbody.bodyType = RigidbodyType2D.Dynamic;
        }
    }
    void RigidbodyDisable()
    {
        foreach (Rigidbody2D rigidbody in rb)
        {
            rigidbody.bodyType = RigidbodyType2D.Kinematic;
        }
    }
}
