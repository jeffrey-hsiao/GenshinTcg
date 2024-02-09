using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public Player p1;
    public Player p2;
    
    

    // Start is called before the first frame update
    void Start()
    {
        
        Character diona = new Diona();
        Character mona = new Mona();
        p1 = new Player(diona);
        p2 = new Player(mona);
        Act(p2,p1,1);
        Debug.Log(diona.hp);
        Act(p1,p2,1);
        Debug.Log(mona.hp);
        Act(p2,p1,1);
        Debug.Log(diona.hp);
        Act(p2,p1,1);
        Debug.Log(diona.hp);


    }
    public void Act(Player p1,Player p2,int i)
    {
        
        //紀錄攻擊者
        Character attacker=p1.character();
        Character attacked=p2.character();
        //取得技能
        CharacterSkill act=attacker.CharacterSkill[i];
        
        Attack(act,p1,p2);
           
    }
    public int DamageOperation(Player p1,Player p2,int Damage)
    {
        //增傷buff結算
        AttackerOperation(p1,Damage);
        
        //防禦類效果結算
        AttackedOperation(p2,Damage);
        return Damage;
    }
    public int AttackerOperation(Player p1,int Damage)
    {
        Damage=(p1).character().RunBuff(Damage);
        Damage=(p1).RunBuff(Damage);
        Damage=(p1).summons.RunBuff(Damage);
        return Damage;
    }
    public int AttackedOperation(Player p2,int Damage)
    {
        int D = Damage;
        Damage=(p2).character().Defense(Damage,D);
        Damage=(p2).Defense(Damage,D);
        Damage=(p2).summons.Defense(Damage,D);
        return Damage;
    }
    public void Attack(Skill act,Player p1,Player p2)
    {
        //紀錄攻擊者
        Character attacker=p1.character();
        Character attacked=p2.character();
        int Damage=act.atk;
        //反映生效
        Damage=ElementBuff(act.element,attacked,p1)+Damage;
        Damage=DamageOperation(p1,p2,Damage);
        //傷害生效
        attacked.hp =attacked.hp -Damage ;
        


        //召喚物序列
        
    
        //護盾結算順序結晶反應->角色技能->武器效果
        //技能效果發動
        //護盾效果
        if (act.GetDefender()!=null)
        {
            p1.AddDefender(act.GetDefender());
        }
        //專屬於攻擊者的護盾
        if (act.GetSelfDefender()!=null)
        {
            attacker.AddDefender(act.GetSelfDefender());
        }
        //節末效果
        if (act.EndEffect!=null)
        {
            p1.endturneffect.append(act.EndEffect);
        }
        //專屬於攻擊者的節末效果
        if (act.selfEndEffect!=null)
        {
            attacker.endturneffect.append(act.selfEndEffect);
        }
        //專屬於被攻擊者的節末效果
        if (act.AttackedEndEffect!=null)
        {
            attacked.endturneffect.append(act.AttackedEndEffect);
        }
        //專屬於被攻擊方的節末效果
        if (act.enemyEndEffect!=null)
        {
            p1.endturneffect.append(act.enemyEndEffect);
        }
        if (act.healer !=null)
        {
            act.healer.Heal(p1);
        }
    }
    public void EndTurn(Effect endturneffect)
    {
        Effect temp=endturneffect;
        while (temp!=null)
        {
            
            temp=temp.next;
        }



    }
    public int ElementBuff(Element element,Character attacked,Player p1)
    {
        //element 無元素 0 火1 水2 冰3 雷4 岩5 風6 草7 冰草8 草冰9 凍結10
        return 0;
    }
    public void SummonAttack(Player p1,Player p2,SummonList SL)
    {
        
        //反映生效
        Summons temp = SL.summons;
        int index=0;
        while (temp!=null)
        {
            Attack(temp.skill,p1,p2);
            Summons disposer=temp;
            temp.dur= temp.dur-1;
            
            temp=(Summons)temp.next;
            if (temp.dur<=0)
            {
                SL.Delete(index);
                SL.RunBuff(0);
                SL.Defense(0,0);
                index++;
            }
            
            
            
        }
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
