﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifierSpeedDown : PlayerCharacterDecorator
{
    public PlayerModifier playerModifier;

    public ModifierSpeedDown(PlayerModifier playerModifier)
    {
        this.playerModifier = playerModifier;
    }
    public override float speed 
    {
        get
        {
            return playerModifier.speed - 1;
        }
        set
        {
            playerModifier.speed = value;
        }
    }

    public override string modifiers
    {
        get
        {
            return playerModifier.modifiers += ", SpeedDown";
        }
        set
        {
            playerModifier.modifiers = value;
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