using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum enemystate
{
    iddle,
    walk,
    attack,
    stagger
}
public class Enemy : MonoBehaviour
{
    public enemystate currentState;
    public FloatValue maxHealth;
    public float health;
    public string enemyName;
    public int baseAttack;
    public float moveSpeed;

    private void Awake()
    {
        health = maxHealth.initialValue;
    }
    // Start is called before the first frame update

    public void knock (Rigidbody2D myRigidbody, float knockTime, float damage)
    {
        StartCoroutine(KnockCo(myRigidbody, knockTime));
        TakeDamage(damage);
    }

    private void TakeDamage(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            this.gameObject.SetActive(false);
        }
    }
    private IEnumerator KnockCo(Rigidbody2D myRigidbody , float knockTime)
    {
        if (myRigidbody != null )
        {
            yield return new WaitForSeconds(knockTime);
            myRigidbody.velocity = Vector2.zero;
            currentState = enemystate.iddle;
            myRigidbody.velocity = Vector2.zero;
        }
    }
}
