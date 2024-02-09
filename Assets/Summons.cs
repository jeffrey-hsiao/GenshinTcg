using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonList:RunEffect
{

    public SummonList()
    {

    }
    public Summons summons;
    public int num_of_summons=0;
    public Summons GetInit()
    {
        return summons;
    }

    public int append(Summons s)
    {
        def=(Defender)this.AddEffect(s.GetDefender(),def);//召喚物的防禦序列
        buf=(Buff)this.AddEffect(s.GetBuff(),def);//召喚物增商序列
        Summons temp = summons;
        for (int i=0;i<num_of_summons;i++)
        {
            if (temp.name==s.name)
            {
                summons=(Summons)temp.Override(s,summons);//如果存在同名召喚物 則覆寫
                return 0;
            }
            temp=(Summons)temp.next;
        }
        if (num_of_summons==4)
        {
            summons=(Summons)summons.Override(s,summons);
        }
        else
        {
            summons.append(s);
            num_of_summons++;
        }
        return 1;

    }
    public void Delete(int d)
    {
        summons.Selfdelete();
        
        if (d==0)
        {
            
            summons.next.prev=null;

            summons=(Summons)summons.next;

        }
        else
        {
            summons.check();
        }

        
    }
   


}


public class Summons:Effect
{
    
    public int time; 
    public Skill skill;
    public Defender GetDefender()
    {
        return skill.defender;
    }
    public Buff GetBuff()
    {
        return skill.buff;
    }
    public int GetAtk()
    {
        return skill.atk;
    }
    public void Selfdelete()
    {
        skill.defender.dur=-1;
        skill.buff.dur=-1;
    }
}

public class MonaESummons:Summons
{
    
    
    public MonaESummons(string n)
    {
        name=n;
        skill=new Skill(1,4);
        skill.element=new Element(2);
        
        skill.defender = new Reduce("虛影",1,1);
        

    }

    
    
}

public class DionaQSummons:Summons//迪奧娜的召喚物
{
    
    
    public DionaQSummons(string n)
    {
        name=n;
        skill=new Skill(1,4);//傷害1點 tag=4(召喚物)
        skill.element=new Element(3);//穿透:0 火:1 水:2 冰:3 雷:4 岩:5 風:6 草:7 物理8
        
        skill.healer = new Healer(2);
        

    }

    
    
}