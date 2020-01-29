using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerKeyMovement : MonoBehaviour
{
    Rigidbody2D rb2d;

    float horizDir;
    float vertDir;
    float diagonalLimiter = 0.7f;

    public float runSpeed = 20.0f;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        getInput();
    }

    void FixedUpdate()
    {
        calcSpeed();
    }

    void getInput()
    {
        horizDir = Input.GetAxisRaw("Horizontal");
        vertDir = Input.GetAxisRaw("Vertical");
    }

    void calcSpeed()
    {
        if (horizDir != 0 && vertDir != 0) // Diagonal movement
        {
            horizDir *= diagonalLimiter;
            vertDir *= diagonalLimiter;
        }

        rb2d.velocity = new Vector2(horizDir * runSpeed, vertDir * runSpeed);
    }
}
