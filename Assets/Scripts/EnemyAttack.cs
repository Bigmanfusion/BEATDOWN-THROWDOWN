using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour


{

    public int attackDamage = 20;
    public Vector3 attackOffset;
    public float attackRange = 1f;
    public LayerMask attackMask;


    public void Attack()

    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        Collider2D co1Info = Physics2D.OverlapCircle(pos, attackRange, attackMask);
        if (co1Info != null)
        {

           co1Info.GetComponent<PlayerHealth>().TakeDamage(attackDamage);
        }



    }
}
