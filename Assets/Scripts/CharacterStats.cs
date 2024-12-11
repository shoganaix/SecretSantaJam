using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    [SerializeField]
    private int maxLife = 10;
    private int life;

    // Start is called before the first frame update
    void Start()
    {
        life = maxLife;
    }

    public void GetDamage(int Damage)
    {
        life -= Damage;
    }

    public void Heal(int heal)
    {
        life += heal;
        if(life > maxLife)
            life = maxLife;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
