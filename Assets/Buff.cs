using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buff:Effect
{
    private int buff;
    
    public int Buf(int Damage)
    {
        Damage=Damage+this.buff;
        return Damage;
    }
    public Buff(string n,int i)
    {
        this.name=n;
        this.buff=i;
    }
}
