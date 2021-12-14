using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_0 : MonoBehaviour
{
    [SerializeField]
    private float _speed = 1.5f;
    private Vector3 moveDelta;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();
    }
    void CalculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        moveDelta = new Vector3(horizontalInput, verticalInput);

        if (moveDelta.x > 0)
        {
            transform.localScale = Vector3.one;
        }
        else if (moveDelta.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 0);
        }

        transform.Translate(moveDelta * _speed * Time.deltaTime);
    }
}
