﻿using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class Bullet : MonoBehaviour
{
    [SerializeField]
    private int damage = 1;

    protected Collider2D myCollider;
    protected Rigidbody2D myRigidbody;

    [SerializeField]
    protected float force = 10F;

    [SerializeField]
    protected float autoDestroyTime = 5F;

    public int Damage
    {
        get
        {
            return damage;
        }

        set
        {
            damage = value;
        }
    }



    // Use this for initialization
    protected virtual void Start()
    {
        myCollider = GetComponent<Collider2D>();
        myRigidbody = GetComponent<Rigidbody2D>();

        myRigidbody.AddForce(transform.up * force, ForceMode2D.Impulse);

        Invoke("AutoDestroy", autoDestroyTime);
    }

    private void AutoDestroy()
    {
        Destroy(gameObject);
        
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }


}