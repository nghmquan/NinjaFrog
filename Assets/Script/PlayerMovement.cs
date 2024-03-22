using System.Numerics;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 1f;
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            UnityEngine.Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            UnityEngine.Vector3 target = transform.position;
            target.x = worldPoint.x;
            transform.position = UnityEngine.Vector2.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);
        }
    }
}
