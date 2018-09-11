using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invader : Hazard {

    // Use this for initialization

    int movementRadius;
    int r = 1;
    float speed = 2;
    float deathAnimTime = 3f;
    

    protected override void Start()
    {
        base.Start();
        r = Random.Range(0, 2);

        if (r == 0)
            movementRadius = 1;

        if (r == 1)
            movementRadius = -1;

        

    }

    //protected bool InsideCamera(bool positive)
    //{
        
    //    float direction = positive ? 1F : -1F;
    //    Vector3 cameraPoint = Camera.main.WorldToViewportPoint(new Vector3(myCollider.bounds.center.x + myCollider.bounds.extents.x * direction,0F,0F));
    //    return cameraPoint.x >= 0F && cameraPoint.x <= 1F;
    //}

    // Update is called once per frame
    void Update () {


        transform.position += new Vector3(movementRadius * speed * Time.deltaTime, 0F, 0F);

        t += Time.deltaTime;

        if(resistance == 0)
        {
            transform.eulerAngles += new Vector3(0, 0, spinSpeed);
           
            OnHazardDestroyed();

            StartCoroutine("DeathTimer");
        }
            
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Invader Left Limit")
        {
            movementRadius = 1;
        }
        if (collision.gameObject.name == "Invader Right Limit")
        {
            movementRadius = -1;
        }
    }

    protected override void OnHazardDestroyed()
    {
        movementRadius = 0;
        myRigidbody.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;

        myCollider.enabled = false;            
  
    }

    IEnumerator DeathTimer()
    {
        yield return new WaitForSeconds(deathAnimTime);
        Destroy(gameObject);
        
    }

}
