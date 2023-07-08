using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Vector3 input;
    [SerializeField] float speed;
    
    private void FixedUpdate() 
    {
        Move();
    }
    private void Move()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");
        if(input.x!=0||input.y!=0)
        {
            transform.position += speed * input * Time.deltaTime;
        }
    }
    
}
