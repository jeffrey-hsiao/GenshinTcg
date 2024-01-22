using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor:Effect
{
    private int thickness;
    
    public int Defense(int Damage)
    {
        
        Damage=Damage-this.thickness;
        if (Damage<0)
        {
            Damage=0;
        }
        else if (Damage >0 || Damage==0)
        {
            this.dur=0;
        }
        return Damage;
    }
    public Armor(string n,int i)
    {
        this.name=n;
        this.thickness=i;
    }
    public void debug()
    {
        Debug.Log(thickness);
    }
    
}
