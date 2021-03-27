using UnityEngine;
public class PlayerControlScript : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 4f;
    [SerializeField] private float jumpSpeed = 5f;
    private Rigidbody2D rBody;
    private bool onGround = false;
    private float moveDirection;
    private void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        Debug.Log(onGround);
        PlayerMove(moveDirection);
    }
    public void PressButton(float direction)
    {
        moveDirection = direction;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            onGround = true;
        }
        EnemyScript enemy = collision.collider.GetComponent<EnemyScript>();
        if (enemy != null)
        {
            foreach (ContactPoint2D point in collision.contacts)
            {
                if (point.normal.y >= 0.6f)
                {
                    enemy.EnemyDead();
                }
                else
                {
                    
                }
            }
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            onGround = false;
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            onGround = true;
        }
    }
    public void PlayerMove(float direction)
    {
        rBody.AddForce(Vector2.right * direction * moveSpeed);
    }
    public void PlayerJump()
    {
        if (onGround == true)
        {
            rBody.AddForce(Vector2.up * jumpSpeed);
            onGround = false;
        }
    }
}