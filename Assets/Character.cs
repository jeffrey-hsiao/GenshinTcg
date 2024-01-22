using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character:HaveEffect
{   
    public Effect endturneffect;
    public string name;
    
    public int maxHp;
    public int hp;
    public Skill[] skill;
    public int skillnumber;
    
    
    
    public void AddArmor(Armor armor)
    {
        def=(Armor)this.AddEffect(armor,def);
    }

  
}

public class Diona:Character
{

    public Diona()
    {
        name="迪奧娜";
        maxHp=10;
        hp=10;
        skillnumber=3;
        skill= new Skill[3];
        skill[0] = new Skill(2,0);
        skill[1] = new Skill(2,1);
        skill[2] = new Skill(1,2);
        //tag=0 普通攻擊 tag=1 元素戰技 tag=2 元素爆發
        skill[1].SetArmor(new Armor("貓爪護盾",1));
    }
}

public class Mona:Character
{
    public Mona()
    {
        maxHp=10;
        hp=10;
        skillnumber=3;
        skill= new Skill[3];
        skill[0] = new Skill(1,0);
        skill[1] = new Skill(1,1);
        skill[2] = new Skill(1,2);
        
    }

}