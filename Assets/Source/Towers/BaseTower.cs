using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTower : Tower
{
    [SerializeField] private GameObject projectile;
    public override void Attack()
    {
        Instantiate(projectile);
    }
}
