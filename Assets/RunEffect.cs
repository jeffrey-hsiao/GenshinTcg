using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunEffect
{
    public Defender def;
    public Buff buf;
    public Effect endturneffect;
    public Effect AddEffect(Effect input,Effect link)
    {
        if  (input==null) 
        {
            return link;
        }
        else if (link==null)
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


    public int Defense(int Damage,int D)
    {
        
        Defender temp =def;

        while(temp != null)
        {
            Damage=temp.Defense(Damage,D);
            Effect disposer=temp;
            temp=(Defender)temp.next;
            if (disposer.check())
            {
                def=null;
                break;
            }
            
            
        }
        
        return Damage;
    }


    public int RunBuff(int Damage)
    {
        
        Buff temp =buf;

        while(temp != null)
        {
            Damage=temp.Buf(Damage);
            Effect disposer=temp;
            temp=(Buff)temp.next;
            if (disposer.check())
            {
                buf=null;
                break;
            }
            
            
        }
        
        return Damage;
    }
}
