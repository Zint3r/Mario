using UnityEngine;
public class CoinScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerControlScript>() == true)
        {
            Destroy(gameObject);
        }
    }    
}