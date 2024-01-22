using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public Effect endturneffect;
    // Start is called before the first frame update
    void Start()
    {
        
        
        Character diona = new Diona();
        Character mona = new Mona();
        Player p1 = new Player(diona);
        Player p2 = new Player(mona);

        Attack(p2,p1,1);
        Debug.Log(diona.hp);
        Attack(p1,p2,1);
        Debug.Log(mona.hp);
        Attack(p2,p1,1);
        Debug.Log(diona.hp);
        Attack(p2,p1,1);
        Debug.Log(diona.hp);


    }
    public void Attack(Player p1,Player p2,int i)
    {
        int Damage;
        //紀錄攻擊者
        Character attacker=p1.character();
        Character attacked=p2.character();

        //取得技能
        Skill act=attacker.skill[i];
        //取得攻擊力
        Damage=act.atk;
        
        
        //增傷buff結算
        //暫時不寫

        //防禦類效果結算
        Damage=(p2).character().Defense(Damage);
        Damage=(p2).Defense(Damage);
        
        //傷害生效
        attacked.hp =attacked.hp -Damage ;
        
    
        //護盾結算順序結晶反應->角色技能->武器效果
        //技能效果發動
        //護盾效果
        if (act.GetArmor()!=null)
        {
            p1.AddArmor(act.GetArmor());
        }
        //專屬於攻擊者的護盾
        if (act.GetSelfArmor()!=null)
        {
            attacker.AddArmor(act.GetSelfArmor());
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
        if (act.enemyEndEffect!=0)
        {
            p1.endturneffect.append(act.enemyEndEffect);
        }        

        

        
        
        
        
        
        

    }

    public void EndTurn()
    {
        Effect temp=endturneffect;
        while (temp!=null)
        {
            
            temp=temp.next;
        }
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
