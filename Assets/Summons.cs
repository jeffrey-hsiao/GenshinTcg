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
                summons=(Summons)temp.Override(s,summons);
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
}

public class MonaESummons:Summons
{
    
    
    public MonaESummons()
    {
        skill=new Skill(1,4);
        skill.element=new Element(2);
        
        skill.defender = new Reduce("虛影",1,1);
        

    }

    
    
}
