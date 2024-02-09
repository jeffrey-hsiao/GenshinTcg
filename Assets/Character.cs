using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character:RunEffect
{   
    public Character next;

    public Character prev;
    public string name;
    
    public Element element;
    public int maxHp;
    public int hp;
    public CharacterSkill[] CharacterSkill;
    public int CharacterSkillnumber;
    
    
    
    public void AddDefender(Defender Defender)
    {
        def=(Defender)this.AddEffect(Defender,def);
    }

  
}

public class Diona:Character
{

    public Diona()
    {
        name="迪奧娜";
        maxHp=10;
        hp=10;
        CharacterSkillnumber=3;
        CharacterSkill= new CharacterSkill[3];
        CharacterSkill[0] = new CharacterSkill(2,0);
        CharacterSkill[1] = new CharacterSkill(2,1);
        CharacterSkill[2] = new CharacterSkill(1,2);
        //tag=0 普通攻擊 tag=1 元素戰技 tag=2 元素爆發
        CharacterSkill[1].SetDefender(new Armor("貓爪護盾",1));
        CharacterSkill[2].SetHealer(new Healer(2));
        CharacterSkill[2].SetSummons(new DionaQSummons("酒霧領域"));
    }
}

public class Mona:Character
{
    public Mona()
    {
        maxHp=10;
        hp=10;
        CharacterSkillnumber=3;
        CharacterSkill= new CharacterSkill[3];
        CharacterSkill[0] = new CharacterSkill(1,0);
        CharacterSkill[1] = new CharacterSkill(1,1);
        CharacterSkill[2] = new CharacterSkill(1,2);
        //tag=0 普通攻擊 tag=1 元素戰技 tag=2 元素爆發
        CharacterSkill[2].SetSummons(new MonaESummons("虛影"));
        CharacterSkill[3].Setbuff(new MonaQBuff("泡影"));
    }

}


