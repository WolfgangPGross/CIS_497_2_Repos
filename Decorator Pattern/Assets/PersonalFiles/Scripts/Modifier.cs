using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Modifier : MonoBehaviour
{
    public enum ModifierType { MODIFIERSPEEDUP, MODIFIERSPEEDDOWN, MODIFIERDAMAGEUP, MODIFIERDAMAGEDOWN, MODIFIERKNOCKBACKUP, MODIFIERKNOCKBACKDOWN }

    public ModifierType modifierType;
}
