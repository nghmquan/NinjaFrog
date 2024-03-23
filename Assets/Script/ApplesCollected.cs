using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ApplesCollected : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private int applesCount = 0;

    [SerializeField] private Text applesText;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Apple"))
        {
            Destroy(collision.gameObject);
            applesCount++;
            applesText.text = "x" + applesCount;
        }
    }

    /*private void Collected()
    {
        anim.SetTrigger("collected");
        Destroy(rb.gameObject, 0f);
    }*/
}
