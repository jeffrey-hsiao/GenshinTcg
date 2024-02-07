using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player:RunEffect
{
    public Character[] characters;
    public Character MainCharacter;
    public SummonList summons= new SummonList();
    

    public Character character()
    {
        return  MainCharacter;
    }
    public void SetMainCharacter(Character character)
    {
        MainCharacter=character;
    }


    
    
   
    

    public Player(Character[] c)
    {
        characters=c;
    }
    public Player(Character c)
    {
        characters = new Character[1];
        characters[0]=c;
    }
    public void AddDefender(Defender Defender)
    {
        def=(Defender)this.AddEffect(Defender,def);
        
    }
  
}
