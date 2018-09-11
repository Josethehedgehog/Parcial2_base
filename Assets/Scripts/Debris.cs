using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Debris : Hazard
{
    
    Vector3 rotacion;

    protected override void Start()
    {
        base.Start();
        

        rotacion = new Vector3(0, 0, spinSpeed);
        
        
    }

    public void Update()
    {
        transform.eulerAngles += rotacion;
    }



}