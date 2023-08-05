using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    Health objectHealthScript;
    [SerializeField] int damageStrength;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("breakable"))
        {
            objectHealthScript = collision.gameObject.GetComponent<Health>();
            objectHealthScript.TakeDamage(damageStrength);
        }

    }
}
