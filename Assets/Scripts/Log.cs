using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Log : Enemy
{
    private Rigidbody2D myRigidBody;
    public Transform target;
    public float chaseRadius;
    public float attackRadius;
    public Transform homePosition;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        currentState = enemystate.iddle;
        myRigidBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        target = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        checkDistance();
    }

    void checkDistance()
    {
        if (Vector3.Distance(target.position, transform.position) <= chaseRadius && Vector3.Distance(target.position, transform.position) > attackRadius)
        {
            if ((currentState == enemystate.iddle || currentState == enemystate.walk) && currentState != enemystate.stagger)
            {
                Vector3 temp = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
                myRigidBody.MovePosition(temp);
                changeAnim(temp - transform.position);
                ChangeState(enemystate.walk);
                anim.SetBool("wakeup", true);
            }
        }
        else
        {
            anim.SetBool("wakeup", false);
        }
    }
    private void setAnimFloat(Vector2 setVector)
    {
        anim.SetFloat("movex", setVector.x);
        anim.SetFloat("movey", setVector.y);
    }
    private void changeAnim(Vector2 direction)

    {
        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            if(direction.x > 0)
            {
                setAnimFloat(Vector2.right);
            }
            else if (direction.x < 0){
                setAnimFloat(Vector2.left);
            }
        }
        else if ((Mathf.Abs(direction.x) < Mathf.Abs(direction.y)))
        {
            if (direction.y > 0)
            {
                setAnimFloat(Vector2.up);
            }
            else if (direction.y < 0){
                setAnimFloat(Vector2.down);
            }
        }

    }
    private void ChangeState(enemystate newState)
    {
        if (currentState != newState)
        {
            currentState = newState;
        }
    }
}
