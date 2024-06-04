using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterLocomotion : MonoBehaviour
{
    Animator animator;
    Vector2 input;
    public Transform attackPoint;
    public CompanionFollow companion;
    public LayerMask enemyMask;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        input.x = Input.GetAxis("Horizontal");
        input.y = Input.GetAxis("Vertical");

        animator.SetFloat("inputX", input.x);
        animator.SetFloat("inputY", input.y);
        if (Input.GetMouseButtonDown(0))
        {
            attack();
        }

    }
    private void attack()
    {
        animator.SetTrigger("punch");
    }
    public void Punch()
    {
        RaycastHit hit;
        if (Physics.Raycast(attackPoint.position,attackPoint.forward,out hit,2.5f,enemyMask))
        {
            hit.collider.GetComponent<gaurd>().TakeDamage(10);
            companion.SetTarget(hit.collider.GetComponent<gaurd>());
            //enemy HP--
            Debug.Log("hit");
        }
        

    }

}
