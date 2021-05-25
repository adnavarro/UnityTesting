using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.5f;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(horizontalInput, verticalInput) * _speed * Time.deltaTime);
        
        // Left and Right bounds
        if (transform.position.x >= 11.5f || transform.position.x <= -11.5f)
        {
            transform.position = new Vector3(-transform.position.x, transform.position.y, 0);
        }

        // Up and Down bounds
        if (transform.position.y >= 0)
        {
            transform.position = new Vector3(transform.position.x, 0, 0);
        }
        else if (transform.position.y <= -3.95f)
        {
            transform.position = new Vector3(transform.position.x, -3.95f, 0);
        }
    }
}
