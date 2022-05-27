using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private int speed = 10;
    [SerializeField] private int minSpeed = 5;
    private Rigidbody2D rigidbody2D;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 flyDir = ((Vector2)transform.position + rigidbody2D.velocity) - (Vector2)transform.position;
        transform.right = flyDir;
        if (rigidbody2D.velocity.magnitude > speed)
        {
            rigidbody2D.velocity = rigidbody2D.velocity * 0.95f;
        }
        else if (rigidbody2D.velocity.magnitude < minSpeed)
        {
            rigidbody2D.velocity = rigidbody2D.velocity * 1.05f;
        }
    }
}
