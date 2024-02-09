using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buff:Effect
{
    
    public int buff;
    
    
    public int Buf(int Damage)
    {
        Damage=Damage+this.buff;
        return Damage;
    }
    public Buff(string n,int i)
    {
        this.name=n;
        this.buff=i;
        dur=1;
    }
    public Buff(string n)
    {
        name=n;
    }
}





public class MonaQBuff:Buff
{
    
    
    public new int Buf(int Damage)
    {
        Damage=Damage*2;
        dur=-1;
        return Damage;
    }
    public MonaQBuff(string n):base(n)
    {
        name=n;
        dur=1;
    }
}