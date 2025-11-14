using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float movSpeed = 2f;

    [Header("Base Damage Settings")]
    [SerializeField] private int damageToBase = 1;


    private Rigidbody2D rb;
    private Transform checkpoint;
    private int checkpointIndex = 0;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

    }


    void Start()
    {
        checkpoint = EnemyManager.main.checkPoints[checkpointIndex];
    }

    void Update()
    {
        checkpoint = EnemyManager.main.checkPoints[checkpointIndex];

        if (Vector2.Distance(transform.position, checkpoint.position) <= 0.1f)
        {
            checkpointIndex++;

            if (checkpointIndex >= EnemyManager.main.checkPoints.Length)
            {

                ReachedBase();
                     
            }


        }
    }

    void FixedUpdate()
    {
        Vector2 direction = (checkpoint.position - transform.position).normalized;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);

        rb.velocity = direction * movSpeed;
    }

    private void ReachedBase()
    {
        
        BaseHealth baseHealth = FindObjectOfType<BaseHealth>();
        if (baseHealth != null)
        {
            baseHealth.TakeDamage(damageToBase);
        }

        
        EnemySpawner.onEnemyDestroy.Invoke();
        
       
        Destroy(gameObject);
    }


}
