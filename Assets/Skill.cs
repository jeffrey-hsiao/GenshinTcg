
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Skill 
{
    public int atk;
    public int tag;
    //tag=0 普通攻擊 tag=1 元素戰技 tag=2 元素爆發
    private Defender Defender;

    private Summons summons;
    private Defender selfDefender;
    public Element element;
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
    
    public void SetDefender(Defender input)
    {
        if (Defender==null)
            Defender=input;
        else 
            Defender.next=input;
    }
    

    public Defender GetDefender()
    {
        return Defender;
    }
    public Defender GetSelfDefender()
    {
        return selfDefender;
    }

}

