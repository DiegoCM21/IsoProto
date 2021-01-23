using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attribute
{
    // Base value of the attribute
    private float baseValue;
    // List containing all the modifiers applied to the attribute
    private List<AttributeModifier> modList;

    public Attribute(float value)
    {
        this.baseValue = value;
        modList = new List<AttributeModifier>();
    }

    /*
     * Calculate the final value of the attribute after applying all the modifiers
     */
    // CONSIDERATION : Maybe the final value should be an attribute that only refreshes every time a new mod is added instead of being calculated every time we do a get for FValue
    private float calculateFValue()
    {
        float retVal = baseValue;
        float mult = 1;
        foreach (AttributeModifier modifier in modList)
        {
            if (modifier.modType == AttModType.Additive)
            {
                retVal += modifier.value;
            }
            // All the multiplicative modifiers are added together and multiply the final value
            else if(modifier.modType == AttModType.Multiplicative)
            {
                mult += modifier.value;
            }
        }
        return Mathf.Round(retVal * mult);
    }

    /*
     * Returns the modified value of the attribute
     */
    public float FValue { get { return calculateFValue(); } }

    public void addModifier(AttributeModifier mod)
    {
        modList.Add(mod);
    }

    public void removeModifier(AttributeModifier mod)
    {
        modList.Remove(mod);
    }

}
