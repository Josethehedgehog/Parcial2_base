using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class APBullet : Bullet {

    // Use this for initialization

    protected override void Start()
    {
        force = 5f;
        myCollider = GetComponent<Collider2D>();
        myRigidbody = GetComponent<Rigidbody2D>();

        myRigidbody.AddForce(transform.up * force, ForceMode2D.Impulse);

        Invoke("AutoDestroy", autoDestroyTime);
    }

    // Update is called once per frame
    void Update () {
		
	}

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Hazard>() != null)
        {
            //Lo atraviesa y no se destruye

            /* -Ay que lindo perro, como se llama?
               -Colision de APBullet con hazard 
               -Puedo acariciarlo?
               -Claro, No hace nada 
            */
        }
        else
        {
            base.OnCollisionEnter2D(collision);
        }
        
    }
}
