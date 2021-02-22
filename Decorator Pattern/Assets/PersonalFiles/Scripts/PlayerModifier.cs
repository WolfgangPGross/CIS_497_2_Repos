using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerModifier
{
    [field: SerializeField] public virtual float speed { set; get; } = 5f;

    [field: SerializeField] public virtual float damage { set; get; } = 5f;

    [field: SerializeField] public virtual float knockback { set; get; } = 5f;

    [field: SerializeField] public virtual string modifiers { set; get; } = "";
}