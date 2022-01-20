using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    walk,
    attack,
    interact,
    stagger,
    iddle
}

public class PlayerMovement : MonoBehaviour
{
    public PlayerState currentState;
    public float speed;
    private Rigidbody2D myRigidbody;
    private Vector3 change;
    private Animator animator;
    private bool moving;


    // Start is called before the first frame update
    void Start()
    {
        currentState = PlayerState.iddle;
        animator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
        animator.SetFloat("movex",0);
        animator.SetFloat("movey",-1);
    }

    // Update is called once per frame
    void Update()
    {
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        if (Input.GetButtonDown("Attack") && currentState != PlayerState.attack
            && currentState != PlayerState.stagger)
            StartCoroutine(AttackCo());
        else if (currentState == PlayerState.walk || currentState == PlayerState.iddle)
            moving = true; 
    }

    private void FixedUpdate()
    {
        if (moving)
        {
            UpdateAnimationAndMove();
            moving = false;
        }
    }

    private IEnumerator AttackCo()
    {
        animator.SetBool("attacking",true);
        currentState = PlayerState.attack;
        yield return null;
        animator.SetBool("attacking", false);
        yield return new WaitForSeconds(.33f);
        currentState = PlayerState.walk;
    }
    void UpdateAnimationAndMove()
    {
        if (change != Vector3.zero)
        {
            MoveCharacter();
            animator.SetFloat("movex", change.x);
            animator.SetFloat("movey", change.y);
            animator.SetBool("moving", true);
        }
        else
        {
            animator.SetBool("moving", false);
        }
    }
    void MoveCharacter()
    {
        change.Normalize();
        //myRigidbody.MovePosition(
        //    //transform.position + PixelPerfectClamp(change,16f) * speed * Time.deltaTime
        //    transform.position + change * speed * Time.deltaTime
        //    );
        Vector3 temp = Vector3.MoveTowards(transform.position, transform.position + change, speed * Time.deltaTime);
        myRigidbody.MovePosition(temp);
    }

    public void Knock(float knockTime)
    {
        StartCoroutine(KnockCo(knockTime));
    }

    //private Vector3 PixelPerfectClamp(Vector3 moveVector,float pixelsPerUnit)
    //{
    //    Vector2 vectorInPixels = new Vector2(
    //    Mathf.RoundToInt(moveVector.x * pixelsPerUnit),
    //    Mathf.RoundToInt(moveVector.y * pixelsPerUnit));
    //    return vectorInPixels / pixelsPerUnit;
    //}

    private IEnumerator KnockCo(float knockTime)
    {
        if (myRigidbody != null)
        {
            yield return new WaitForSeconds(knockTime);
            myRigidbody.velocity = Vector2.zero;
            currentState = PlayerState.iddle;
            myRigidbody.velocity = Vector2.zero;
        }
    }
}
