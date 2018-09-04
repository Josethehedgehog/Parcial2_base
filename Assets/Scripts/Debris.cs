using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Debris : Hazard
{
    int spinSpeed;
    Vector3 rotacion;

    protected override void Start()
    {
        base.Start();
        spinSpeed = Random.Range(50, 100);

        rotacion = new Vector3(0, 0, spinSpeed);
        
        
    }

    private void Update()
    {
        transform.eulerAngles += rotacion;
    }



}