using UnityEngine;

public class NinjaFrogMovement : MonoBehaviour
{
    [SerializeField] private float basedMoveSpeed = 1f;
    private float moveSpeed;
    private bool cantInputPlayer = false;

    private Vector2 worldPoint;
    private Vector2 direction;
    private Vector3 targetPoint;

    private Rigidbody2D rigidbodyNinjaFrog;
    private BoxCollider2D collider2DNinjaFrog;
    private GameManager gameManager;
    private NinjaFrogAnimation ninjaFrog;

    // Start is called before the first frame update
    void Start(){
        gameManager = FindObjectOfType<GameManager>();
        ninjaFrog = GetComponent<NinjaFrogAnimation>();
        rigidbodyNinjaFrog = GetComponent<Rigidbody2D>();
        collider2DNinjaFrog = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update(){
        NinjaFrogRun();
    }

    public Vector2 GetDirection() { return direction = targetPoint - transform.position; }

    public float GetMoveSpeed() { return moveSpeed; }  

    public Rigidbody2D GetRigidbodyNinjaFrog(){ return rigidbodyNinjaFrog;}

    public BoxCollider2D GetCollider2DNinjaFrog(){ return collider2DNinjaFrog;}

    public void SetInput(bool inputPlayer) { cantInputPlayer = inputPlayer; }

    public bool CantInput(){ return cantInputPlayer; } 

    public void NinjaFrogRun(){
        if (CantInput()) { return; }

        if (Input.GetMouseButton(0)){
            worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPoint = new Vector3(worldPoint.x, transform.position.y, transform.position.z);
            GetDirection();
            direction.Normalize();
            moveSpeed = basedMoveSpeed * gameManager.GetGameSpeed();
            transform.position = Vector2.MoveTowards(transform.position, targetPoint, moveSpeed * Time.deltaTime);
            ninjaFrog.CheckIsRunning(true);
        }else{
            ninjaFrog.CheckIsRunning(false);
        }
    }
}