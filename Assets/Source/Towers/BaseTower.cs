using Melanchall.DryWetMidi.MusicTheory;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class BaseTower : Tower
{
    [SerializeField] private GameObject projectile;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private float offset = .75f;
    private Animator animator;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

    public override void Attack()
    {
        animator.Play("Attack");
        GameObject projectileInstance = Instantiate(projectile);
        projectileInstance.transform.position = transform.position + Vector3.right * offset;
    }
}
