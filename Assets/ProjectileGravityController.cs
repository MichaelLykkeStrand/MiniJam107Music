using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ProjectileGravityController : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    private GameObject[] gravityObjects;
    // Start is called before the first frame update
    void Start()
    {

        this.rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        gravityObjects = GameObject.FindGameObjectsWithTag("GravityObject");
        foreach (GameObject gravityObject in gravityObjects)
        {
            LocalGravity localGravityComponent = gravityObject.GetComponent<LocalGravity>();
            var dist = Vector3.Distance(gravityObject.transform.position, transform.position);
            double localGravity = localGravityComponent.gravity;
            double gravityDistance = localGravity / 2;
            if (dist <= gravityDistance)
            {
                var v = gravityObject.transform.position - transform.position;
                double gravityPull = (1.0 - dist / gravityDistance) * localGravity;
                Vector2 forceDir = v.normalized * (float)gravityPull;
                this.rigidbody2D.AddForce(forceDir);
            }
        }
    }
}
