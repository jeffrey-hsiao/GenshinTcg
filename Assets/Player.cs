using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player:RunEffect
{
    public Character[] characters;
    public int index = 0;

    public SummonList summons= new SummonList();
    

    public Character character()
    {
        return characters[index];
    }


    
    
   
    

    public Player(Character[] c)
    {
        index = 0;
        characters=c;
        def=null;
    }
    public Player(Character c)
    {
        characters = new Character[1];
        index = 0;
        characters[0]=c;
        def=null;
    }
    public void AddDefender(Defender Defender)
    {
        def=(Defender)this.AddEffect(Defender,def);
        
    }
  
}
