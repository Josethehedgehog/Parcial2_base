using UnityEngine;
using UnityEngine.UI;

public class KillVolume : MonoBehaviour
{
    public Shelter[] shelters;
    public Shelter shelter;

    private void Start()
    {
        shelter = GetComponent<Shelter>();
    }

    private void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Hazard>() != null)
        {
            for (int i = 0; i < shelters.Length; i++)
            {
                if (shelters[i] != null)
                {
                    print("Damaging a shelter");

                }

               


            }
        }

        Destroy(collision.gameObject);
    }
}