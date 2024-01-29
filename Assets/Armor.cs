using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : Effect
{
    public int thickness;
    public int threshold=0;

    public int Defense(int damage,int Damage)
    {
        if (damage<=0)
        {
            return 0;
        }
        else if (Damage<=threshold)
        {
            return damage;
        }
        Consume(damage);
        return damage;
    }

    protected virtual void Consume(int damage)
    {
        // 实现 consume 方法的逻辑
    }

    
}

public class Reduce : Defender
{
    
    public Reduce(string n, int i,int d)
    {
        this.name = n;
        this.thickness = i;//厚度
        this.dur = d;//可用次數
    }


    protected override void Consume(int damage)
    {
        damage = damage -this.thickness;
        dur = dur-1;
    }
}

public class Armor : Defender
{

    public Armor(string n, int i)
    {
        this.name = n;
        this.thickness = i;
        this.dur = i;
    }


    protected override void Consume(int damage)
    {
        damage = damage - this.thickness;
        if (damage<0)
        {
            damage=0;
        }
        else if (damage >0 || damage==0)
        {
            this.dur=0;
        }
    }
    // 在 Defender 类中可以添加额外的成员或方法
}
