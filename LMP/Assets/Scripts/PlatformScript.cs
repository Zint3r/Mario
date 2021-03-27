using UnityEngine;
public class PlatformScript : MonoBehaviour
{
    [SerializeField] private Transform respPoint;
    [SerializeField] private GameObject bonus;
    //private SpriteRenderer spriteRenderer;
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }    
    public void PlatformActivation()
    {
        anim.SetTrigger("Touch");
    }
    public void RespawnBonus()
    {
        if (CheckBonus())
        {
            Instantiate(bonus, respPoint);
        }        
    }
    private bool CheckBonus()
    {
        if (bonus == null)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}