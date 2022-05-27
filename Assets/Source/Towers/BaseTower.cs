using Melanchall.DryWetMidi.MusicTheory;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTower : Tower
{
    [SerializeField] private GameObject projectile;

    public override void Attack()
    {
        GameObject projectileInstance = Instantiate(projectile);
        projectileInstance.transform.position = transform.position;
    }
}
