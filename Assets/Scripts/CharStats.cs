using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Character", menuName = "Char")]
public class CharStats : ScriptableObject
{
    public string name;

    public int health = 100;
    public int energy = 100;

    public int strength = 10;
    public int vitality = 10;
    public int agility = 10;
    public int dexterity = 10;
    public int intelligence = 10;
    public int wisdom = 10;


}
