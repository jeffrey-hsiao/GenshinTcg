using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HaveEffect
{
    public Armor def;
    public Effect endturneffect;
    public Effect AddEffect(Effect input,Effect link)
    {
        

        if (link==null)
        {
            link=input;
        }
        else
        {
            Effect temp=link;
            Effect disposer;
            while (temp.next!=null)
            {
                if (temp.name==link.name)
                {
                    disposer=temp;
                    temp=temp.next;
                    disposer.Dispose();
                }
                else
                    temp=temp.next;
                
            }
            temp.next=input;
        }
        return link;
    }


    public int Defense(int Damage)
    {
        
        Armor temp =def;

        while(temp != null)
        {
            Damage=temp.Defense(Damage);
            Effect disposer=temp;
            temp=(Armor)temp.next;
            if (disposer.check())
            {
                def=null;
                break;
            }
            
            
        }
        
        return Damage;
    }
}
