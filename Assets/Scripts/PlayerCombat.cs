using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

    public Animator animator;

    public Transform Attackpoint;
    public float attackRange = 0.5f;
    public LayerMask enemylayers;

    public float attackRate = 1f;
    float nextAttackTime = 0f;

    public int attackDamage = 40;
    // Update is called once per frame
    void Update()
    {
        if(Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.H))
            {
                Punch();
                nextAttackTime = Time.time + 1 / attackRate; 
            }
        }
    
    }


    void Punch()   
    {
        animator.SetTrigger("Punch");

        Collider2D[] hitEnemies  = Physics2D.OverlapCircleAll(Attackpoint.position, attackRange, enemylayers);

        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(20);
            //Debug.Log("We hit" + enemy.name);
        }

    }


    void OnDrawGizmosSelected()
    {
        if (Attackpoint == null)
            return;

        Gizmos.DrawWireSphere(Attackpoint.position, attackRange);





    }

}
