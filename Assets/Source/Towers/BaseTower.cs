using Melanchall.DryWetMidi.MusicTheory;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class BaseTower : Tower
{
    [SerializeField] private GameObject projectile;
    [SerializeField] private float offset = 1f;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public override void Attack()
    {
        GameObject projectileInstance = Instantiate(projectile);
        animator.SetTrigger("Attack");
        projectileInstance.transform.position = transform.position + Vector3.right * offset;
    }
}
