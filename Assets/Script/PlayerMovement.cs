using System.Numerics;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 1f;
    private SpriteRenderer sprite;
    private Animator anim;
    private enum MovementState { idle, running}
    void Update()
    {
        anim = GetComponent<Animator>();

        if (Input.GetMouseButton(0))
        {
            UnityEngine.Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            UnityEngine.Vector3 target = transform.position;
            target.x = worldPoint.x;
            transform.position = UnityEngine.Vector2.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);

            /*MovementState state;
            if (target.x > 0f)
            {
                state = MovementState.running;
                sprite.flipX = true;
            }
            else if(target.x < 0f)
            {
                state = MovementState.running;
                sprite.flipX = true;
            }
            else
            {
                state = MovementState.idle;
            }

            anim.SetInteger("state", (int)state)*/
        }
    }
}
