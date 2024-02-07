
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Skill
{
    public Defender defender;//例如迪奧娜護盾
    public int atk;
    public int tag; //tag=0 普通攻擊 tag=1 元素戰技 tag=2 元素爆發 tag=4 召喚物

    public Defender SelfDefender;//例如討債人護盾
    public Element element;//元素
    public Effect selfEndEffect;
    public Effect EndEffect;
    public Effect AttackedEndEffect;//例如女士妮祿節末追打
    public Effect enemyEndEffect;//

    public Buff SelfBuff;//例如賽諾大招
    public Buff buff;//例如班尼特大招



    public Skill(int a,int t) //tag=0 普通攻擊 tag=1 元素戰技 tag=2 元素爆發 tag=4 召喚物
    {
        atk=a;
        tag=t;
    }

    public void SetDefender(Defender input)
    {
        if (defender==null)
            defender=input;
        else 
            defender.next=input;
    }
    public void SetSelfDefender(Defender input)
    {
        if (SelfDefender==null)
            SelfDefender=input;
        else 
            SelfDefender.next=input;
    }
    public Defender GetDefender()
    {
        return defender;
    }
    public Defender GetSelfDefender()
    {
        return SelfDefender;
    }


    public void Setbuff(Buff input)
    {
        if (buff==null)
            buff=input;
        else 
            buff.next=input;
    }
    public void SetSelfBuff(Buff input)
    {
        if (SelfBuff==null)
            SelfBuff=input;
        else 
            SelfBuff.next=input;
    }
    public Buff GetBuff()
    {
        return buff;
    }
    public Buff GetSelfBuff()
    {
        return SelfBuff;
    }
    
   
   


}


public class CharacterSkill:Skill
{
    
   
    

    private Summons summons;
    
    

    
    //傷害屬性 暫且先擱置

    public CharacterSkill(int a,int t):base(a,t)
    {
        
    }
    
    
    
}

