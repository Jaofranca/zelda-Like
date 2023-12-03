using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class KnockbackFeedback : MonoBehaviour
{

    [SerializeField]
    private Rigidbody2D rb2d;

    [SerializeField]
    private float strength = 5, delay = 0.15f, damage = 5;

    public UnityEvent OnBegin, OnDone;

    private GameObject enemygameObject;
    private float enemyStrength;
    private float enemyDelay;
    private float enemyDamage;
    

    public void PlayFeedback(GameObject sender)
    {
        enemygameObject = sender;
        
        enemyStrength= sender.GetComponent<KnockbackFeedback>().strength;
        enemyDelay = sender.GetComponent<KnockbackFeedback>().delay;
        enemyDamage = sender.GetComponent<KnockbackFeedback>().damage;

        if (this.gameObject.CompareTag("enemy"))
        {
            rb2d.GetComponent<Enemy>().currentState = EnemyState.stagger;
        }
        else{
            rb2d.GetComponent<Player>().currentState = PlayerState.stagger;

        }
        StopAllCoroutines();
        OnBegin?.Invoke();
        Vector2 direction = (transform.position - sender.transform.position).normalized;
        rb2d.AddForce(direction * enemyStrength, ForceMode2D.Impulse);
        StartCoroutine(Reset());
        if (this.gameObject.CompareTag("enemy"))
        {
            this.GetComponent<Enemy>().Knock(this.GetComponent<Rigidbody2D>(), enemyDelay, enemyDamage);
        }
        else
        {
            this.GetComponent<Player>().Knock(enemyDelay, enemyDamage);
        }
        
    }

    private IEnumerator Reset()
    {
        yield return new WaitForSeconds(enemyDelay);
        rb2d.velocity = Vector3.zero;
        OnDone?.Invoke();
        if (this.gameObject.CompareTag("enemy"))
        {
            rb2d.GetComponent<Enemy>().currentState = EnemyState.idle;
        }
        else
        {
            rb2d.GetComponent<Player>().currentState = PlayerState.idle;
        }
        
    }
}
