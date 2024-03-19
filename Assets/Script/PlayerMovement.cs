using System.Numerics;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private float moveSpeed = 1f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            rb.transform.position = new UnityEngine.Vector2(moveSpeed * Time.deltaTime, rb.position.y);
        }

        Debug.Log("rb: " + rb);
    }

}
