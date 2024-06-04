using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class CompanionFollow : MonoBehaviour
{
    public NavMeshAgent ai;
    public Transform player;
    public Animator aiAnim;
    Vector3 dest;
    private gaurd currentTarget;
    public Transform attackPoint;
    public LayerMask enemyMask;
    private bool punch = true;
    private bool agPunch = false;
    // Start is called before the first frame update
    void Start()
    {
        aiAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Q))
        {
            punch = false;
            agPunch = false ;
            aiAnim.SetBool("agPunch",false);
            aiAnim.SetBool("punch", false);
        }

        if(Input.GetKeyDown(KeyCode.E) && currentTarget != null)
        {
            punch = false ;
            agPunch = true ;
        }

        if ((currentTarget == null|| ( !punch && !agPunch)))
        {
            dest = player.position;
            ai.destination = dest;
            ai.stoppingDistance = 3;   
        }
        else
        {
            dest = currentTarget.transform.position;
            ai.destination = dest;
            ai.stoppingDistance = 1;

            float enemydistance = Vector3.Distance(transform.position, dest);
            
            if (punch)
            {
                 aiAnim.SetBool("punch", enemydistance <= ai.stoppingDistance);
            }
            if (agPunch)
            {
                aiAnim.SetBool("agPunch", enemydistance <= ai.stoppingDistance);
            }
            transform.LookAt(new Vector3(currentTarget.transform.position.x, 0, currentTarget.transform.position.z));
        }

        
        float distance = Vector3.Distance(transform.position,dest);
        aiAnim.SetBool("Walking",distance>=ai.stoppingDistance);

       
       
    }
    public void SetTarget(gaurd target)
    {
        currentTarget = target;
        punch = true ;
    }
    public void Punch()
    {
        RaycastHit hit;
        if (Physics.Raycast(attackPoint.position, attackPoint.forward, out hit, 2.5f, enemyMask))
        {
            hit.collider.GetComponent<gaurd>().TakeDamage(10);
            //enemy HP--
            Debug.Log("Nhit");
        }
    }
    public void AgPunch()
    {
        RaycastHit hit;
        if (Physics.Raycast(attackPoint.position, attackPoint.forward, out hit, 2.5f, enemyMask))
        {
            hit.collider.GetComponent<gaurd>().TakeDamage(20);
            //enemy HP--
            Debug.Log("Aghit");
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Reward"))
        {
            dest = other.transform.position;
            ai.destination = dest;
            ai.stoppingDistance = 2;
            Debug.Log("Found a reward");
        }
    }
}
