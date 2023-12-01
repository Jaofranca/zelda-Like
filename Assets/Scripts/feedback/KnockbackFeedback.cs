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
    private float strength = 16, delay = 0.15f;

    public UnityEvent OnBegin, OnDone;

    

    public void PlayFeedback(GameObject sender)
    {

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
        rb2d.AddForce(direction * strength,ForceMode2D.Impulse);
        StartCoroutine(Reset());
    }

    private IEnumerator Reset()
    {
        yield return new WaitForSeconds(delay);
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
