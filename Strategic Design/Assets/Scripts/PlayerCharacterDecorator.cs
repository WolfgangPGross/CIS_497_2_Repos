using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerCharacterDecorator : PlayerModifier
{
    public override abstract float speed { get; set; }

    public override abstract float damage { get; set; }

    public override abstract float knockback { get; set; }

    public override abstract string modifiers { get; set; }

}
