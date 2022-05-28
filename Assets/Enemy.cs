using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Enemy : MonoBehaviour
{
    public int dropMoney = 10;
    public int speed = 10;
    public int damage = 1;
    public float attackSpeed = 0.5f;
    private bool isOnCooldown;
    private GameObject target;
    private AudioSource audioSource;
    [SerializeField] private AudioClip deathSound;
    [SerializeField] private AudioClip attackSound;
    private GameObject player;
    private HealthContainer healthContainer;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player");
        healthContainer = GetComponent<HealthContainer>();
        healthContainer.OnEmpty += HealthContainer_OnEmpty;
    }

    private void HealthContainer_OnEmpty()
    {
        player.GetComponent<CurrencyContainer>().Add(dropMoney);
    }

    private void FixedUpdate()
    {
        this.transform.position -= (Vector3)Vector2.right * 0.001f * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        target = collision.gameObject;
    }

    private void Update()
    {
        Attack();
    }

    private void Attack()
    {
        if (!isOnCooldown && target != null)
        {
            audioSource.PlayOneShot(attackSound);
            target.GetComponent<HealthContainer>().Subtract(damage);
            StartCoroutine(CooldownCoroutine());
        }
    }

    IEnumerator CooldownCoroutine()
    {
        isOnCooldown = true;
        yield return new WaitForSeconds(attackSpeed);
        isOnCooldown = false;
    }
    //TODO MOVE
    private void OnDestroy()
    {
        healthContainer.OnEmpty -= HealthContainer_OnEmpty;
        MusicController.GlobalAudioSource.PlayOneShot(deathSound);
    }
}
