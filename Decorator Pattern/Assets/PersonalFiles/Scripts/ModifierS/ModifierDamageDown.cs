using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifierDamageDown : PlayerCharacterDecorator
{
    public PlayerModifier playerModifier;

    public ModifierDamageDown(PlayerModifier playerModifier)
    {
        this.playerModifier = playerModifier;
    }
    public override float damage
    {
        get
        {
            return playerModifier.damage - 1;
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
            return playerModifier.modifiers += ", DamageDown";
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