using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifierKnockbackDown : PlayerCharacterDecorator
{
    public PlayerModifier playerModifier;

    public ModifierKnockbackDown(PlayerModifier playerModifier)
    {
        this.playerModifier = playerModifier;
    }
    public override float knockback
    {
        get
        {
            return playerModifier.knockback - 1;
        }
        set
        {
            playerModifier.knockback = value;
        }
    }

    public override string modifiers
    {
        get
        {
            return playerModifier.modifiers += ", KnockbackDown";
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
    public override float damage 
    {
        get
        {
            return playerModifier.damage;
        }
        set
        {
            playerModifier.damage = value;
        }
    } 
}