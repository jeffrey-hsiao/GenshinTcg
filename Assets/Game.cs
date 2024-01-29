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
        int D;
        //紀錄攻擊者
        Character attacker=p1.character();
        Character attacked=p2.character();

        //取得技能
        Skill act=attacker.skill[i];
        //取得攻擊力
        Damage=act.atk;
        D=Damage;

        //反映生效
        Damage=ElementBuff(act.element,attacked,p1)+Damage;
        
        



        //增傷buff結算
        Damage=(p2).character().RunBuff(Damage);
        Damage=(p2).RunBuff(Damage);
        Damage=(p2).summons.RunBuff(Damage);
        
        //防禦類效果結算
        Damage=(p2).character().Defense(Damage,D);
        Damage=(p2).Defense(Damage,D);
        Damage=(p2).summons.Defense(Damage,D);
        
        


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


    // Update is called once per frame
    void Update()
    {
        
    }
}
