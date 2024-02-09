using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healer : Effect
{
    public int healAmount;
    
    
    public Healer(int amount)
    {
        this.healAmount = amount;
    }

    // 治疗方法，接收一个 Player 对象，对其血量进行治疗，并返回治疗后的血量
    public void Heal(Player p)
    {
        if (p.character().hp + healAmount < p.character().maxHp)
        {
            p.character().hp=p.character().hp + healAmount;
        }
        else
        {
            p.character().hp = p.character().maxHp;
        }
    }
    public void Heal(Character c)
    {
        if (c.hp + healAmount < c.maxHp)
        {
            c.hp=c.hp + healAmount;
        }
        else
        {
            c.hp = c.maxHp;
        }
    }
}