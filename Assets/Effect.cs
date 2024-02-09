using System.Collections;
using System.Collections.Generic;


public class Effect
{
    public string name;

    public Effect next;
    public Effect prev;
    public int dur;

    public Effect()
    {
        next=null;
    }
    public bool check()
    {
        if (dur<1)
        {
            if (this.next==null && this.prev==null)
            {
                return true;
            }
            else
            {
                this.Dispose();
            }
            
        }
        return false;
    }
    public void append(Effect e)
    {
        Effect temp=this;
        while (temp.next!= null)
        {
            
            temp=temp.next;
        }
        temp.next=e;
    }
    public void Dispose()
    {
        if (prev!=null)
            prev.next = next;
        if (next!=null)
            next.prev = prev;
        

        
        
    }

    public Effect Override(Effect e,Effect rot)
    {
        if (next!=null)
            next.prev=e;
        if (prev!=null)
            prev.next=e;
        if (next==null && prev==null)
        {
            rot=e;
        }
        return rot;
    }
}
