using UnityEngine;
public class PlayerHeadController : MonoBehaviour
{  
    private void OnCollisionEnter2D(Collision2D collision)
    {        
        if (collision.gameObject.GetComponentInParent<PlatformScript>() == true)
        {
            PlatformScript platform = collision.gameObject.GetComponentInParent<PlatformScript>();
            platform.PlatformActivation();
            platform.RespawnBonus();
        }
    }
}