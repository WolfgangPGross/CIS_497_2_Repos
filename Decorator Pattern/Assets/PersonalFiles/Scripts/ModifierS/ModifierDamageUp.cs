using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifierDamageUp : PlayerCharacterDecorator
{
    public PlayerModifier playerModifier;

    public ModifierDamageUp(PlayerModifier playerModifier)
    {
        this.playerModifier = playerModifier;
    }
    public override float damage
    {
        get
        {
            return playerModifier.damage + 1;
        }
        set
        {
            playerModifier.damage = value;
        }
    }

    public override string modifiers
    {
        get
        {
            return playerModifier.modifiers += ", DamageUp";
        }
        set
        {
            playerModifier.modifiers = value;
        }
    }

    public override float speed 
    {
        get
        {
            return playerModifier.speed;
        }
        set
        {
            playerModifier.speed = value;
        }
    } 
    public override float knockback 
    {
        get
        {
            return playerModifier.knockback;
        }
        set
        {
            playerModifier.knockback = value;
        }
    } 
}