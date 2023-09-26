using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState{
    idle,
    walk,
    attack,
    stagger
}

public class Enemy : MonoBehaviour
{
    public EnemyState currentState;
    public int health;
    public string enemyName;
    public int baseAttack;
    public float moveSpeed;
    
    public void Knock(Rigidbody2D myRigidbody, float knockTime)
    {
        StartCoroutine(KnockCo(myRigidbody, knockTime));
    }
    private IEnumerator KnockCo(Rigidbody2D myRigibody, float knockTime)
    {
        if (myRigibody != null)
        {
            yield return new WaitForSeconds(knockTime);
            myRigibody.velocity = Vector2.zero;
            currentState = EnemyState.idle;
            myRigibody.velocity = Vector2.zero;
        }
    }
}
