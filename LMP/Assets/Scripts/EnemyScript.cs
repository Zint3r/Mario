using UnityEngine;
public class EnemyScript : MonoBehaviour
{
    [SerializeField] private float enemySpeed = 10f;
    private int moveDirection = -1;
    private Rigidbody2D rBody;
    private bool onGround = false;
    private void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        EnemyMove(moveDirection);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {            
            if (moveDirection == 1)
            {
                moveDirection = -1;
            }
            else
            {
                moveDirection = 1;
            }
        }
        if (collision.gameObject.CompareTag("Ground") && onGround == false)
        {
            onGround = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") && onGround == true)
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
    //private int EnvironmentCheck()
    //{        
    //    RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x - 1, transform.position.y), rayTarget.position);        
    //    if (hit.collider != null)
    //    {            
    //        Debug.Log(hit.collider.gameObject.name);
    //        float distance = Mathf.Abs(hit.point.x - transform.position.x);
    //        Debug.Log(distance);
    //        if (distance <= 1)
    //        {
    //            gameObject.transform.Rotate(new Vector3(0, 180, 0));
    //            return 1;                
    //        }
    //        else
    //        {
    //            return -1;
    //        }
    //    }
    //    else
    //    {
    //        return -1;
    //    }
    //}
    private void EnemyMove(int direction)
    {
        if (onGround)
        {
            Vector2 enemyPos = new Vector2(direction, 0);
            rBody.velocity = enemyPos * enemySpeed;
        }        
    }
    public void EnemyDead()
    {
        Debug.Log("Enemy dead!");
        Destroy(gameObject);
    }
}