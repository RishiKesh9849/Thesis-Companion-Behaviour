using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class gaurd : MonoBehaviour
{
    public int HP = 100;
    public Animator animator;
    
    public void TakeDamage(int damageAmount)
    {
        HP -= damageAmount;
        if(HP <= 0)
        {
            animator.SetTrigger("die"); 
            GetComponent<Collider>().enabled = false;
            Destroy (gameObject,4.6f);
        }
        else
        {
            animator.SetTrigger("getHit");
            
        }
    }
    
}
