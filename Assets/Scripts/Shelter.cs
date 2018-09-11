using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Shelter : MonoBehaviour
{
    [SerializeField]
    private int maxResistance = 5;

    private float regenTime = 5f;

    private bool isDamaged = false;

    private float timeSinceDamage = 0;

    public Text shelterHP;

    

    public int MaxResistance
    {
        get
        {
            return maxResistance;
        }
        set
        {
            maxResistance = value;
        }
    }




    public bool IsDamaged
    {
        get
        {
            return isDamaged;
        }

        set
        {
            isDamaged = value;
        }
    }

    public float TimeSinceDamage
    {
        get
        {
            return timeSinceDamage;
        }

        set
        {
            timeSinceDamage = value;
        }
    }

    public void Damage(int damage)
    {
    }

    private void Update()
    {
        

        if (MaxResistance <= 0)
            Destroy(gameObject);


        shelterHP.text = MaxResistance.ToString();
        
        
            
        





        if (IsDamaged == true)
        {
            print(TimeSinceDamage);
            TimeSinceDamage += Time.deltaTime;
            if(TimeSinceDamage >= regenTime)
            {
                TimeSinceDamage = 0;
                if (MaxResistance < 5)
                {
                    Regenerate();

                }
                
            }

        }


    }

    void Regenerate()
    {
        MaxResistance += 1;


        if (MaxResistance == 5)
        {
            IsDamaged = false;
        }
    }

    


}