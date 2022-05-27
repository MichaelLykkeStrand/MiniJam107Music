using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int speed = 10;
    public int damage = 1;

    private void FixedUpdate()
    {
        this.transform.position -= (Vector3)Vector2.right * 0.001f * speed;
    }
}
