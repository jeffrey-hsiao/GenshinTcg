using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill 
{
    public int atk;
    public int tag;
    //tag=0 普通攻擊 tag=1 元素戰技 tag=2 元素爆發
    
    private Armor armor;
    private Armor selfarmor;
    private Effect Element element;
    public Effect selfEndEffect;
    public Effect EndEffect;
    public Effect AttackedEndEffect;
    public Effect enemyEndEffect;

    
    //傷害屬性 暫且先擱置

    public Skill(int a,int t)
    {
        atk=a;
        tag=t;
    }
    
    public void SetArmor(Armor input)
    {
        if (armor==null)
            armor=input;
        else 
            armor.next=input;
    }
    public void SetArmor(Armor input)
    {
        if (armor==null)
            selfarmor=input;
        else 
            selfarmor.next=input;
    }


    public Armor GetArmor()
    {
        return armor;
    }
    public Armor GetSelfArmor()
    {
        return selfarmor;
    }

}
