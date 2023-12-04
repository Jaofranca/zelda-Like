using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    public float thrust;
    public float knockTime;
    public float damage;

  

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!this.gameObject.CompareTag("enemy") && other.gameObject.CompareTag("enemy") && other.isTrigger ) {
            
            other.GetComponent<KnockbackFeedback>().PlayFeedback(this.gameObject.transform.parent.gameObject);
        }
        if(other.gameObject.CompareTag("Player") && other.isTrigger)
        {
            other.GetComponent<KnockbackFeedback>().PlayFeedback(this.gameObject);
        }
        
        


       
        //if (other.gameObject.CompareTag("breakable") && this.gameObject.CompareTag("Player"))
        //{
        //    other.GetComponent<pot>().Smash();
        //}
        //if ((other.gameObject.CompareTag("enemy") || other.gameObject.CompareTag("Player")) && other.isTrigger)
        //{

        //    Rigidbody2D hit = other.GetComponent<Rigidbody2D>();

        //    if (hit != null)
        //    {
        //        Vector2 direction = (transform.position - transform.position).normalized;
        //        //hit.AddForce(difference, ForceMode2D.Impulse);
        //        if (other.gameObject.CompareTag("enemy") && !(this.GetComponent<Enemy>() != null))
        //        {
        //            hit.AddForce(direction * thrust, ForceMode2D.Impulse);
        //            hit.GetComponent<Enemy>().currentState = EnemyState.stagger;
        //            other.GetComponent<Enemy>().Knock(hit, knockTime, damage);
        //        }
        //        if (other.gameObject.CompareTag("Player"))
        //        {
        //            if (other.GetComponent<Player>().currentState != PlayerState.stagger)
        //            {
        //                hit.AddForce(direction * thrust, ForceMode2D.Impulse);
        //                this.GetComponent<Enemy>().currentState = EnemyState.stagger;
        //                this.GetComponent<Enemy>().Knock(hit, knockTime, damage);
        //                hit.GetComponent<Player>().currentState = PlayerState.stagger;
        //                other.GetComponent<Player>().Knock(knockTime, damage);
        //            }


        //        }


        //    }


        //    }
        //} 
    }
}
