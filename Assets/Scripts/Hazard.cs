using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Hazard : MonoBehaviour
{
    protected Collider2D myCollider;
    protected Rigidbody2D myRigidbody;

    [SerializeField]
    protected float resistance = 1F;

    protected float spinSpeed = 50F;

    protected float t;

    

   


    // Use this for initialization
    protected virtual void Start()
    {
        myCollider = GetComponent<Collider2D>();
        myRigidbody = GetComponent<Rigidbody2D>();
        
        
        spinSpeed = Random.Range(50, 100);

    }
    

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Bullet>() != null)
        {
            //TODO: Make this to reduce damage using Bullet.damage attribute
            resistance -= collision.gameObject.GetComponent<Bullet>().Damage;

            if (resistance == 0)
            {
                
                OnHazardDestroyed();
            }

            if (resistance < 0)
                resistance = 0;
        }
        
        

        if (collision.gameObject.GetComponent<Shelter>() != null)
        {
           Shelter res = collision.gameObject.GetComponent<Shelter>();
            res.MaxResistance -= 1;
            res.IsDamaged = true;
            res.TimeSinceDamage = 0;
            print("Collided");
            Destroy(gameObject);

        }

        
    }

    protected virtual void OnHazardDestroyed()
    {
        //TODO: GameObject should spin for 'spinTime' secs. then disappear
        
        Destroy(gameObject);
    }
}