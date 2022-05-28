using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D),typeof(CircleCollider2D))]
public class Projectile : MonoBehaviour
{
    public int speed = 10;
    public int damage = 1;

    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.position += (Vector3)Vector2.right*0.001f*speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Tower>() != null) return;
        collision.gameObject.GetComponent<HealthContainer>().Subtract(damage);
        Destroy(this.gameObject);
    }

}
