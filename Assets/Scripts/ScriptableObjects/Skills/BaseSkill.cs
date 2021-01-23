using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseSkill : ScriptableObject
{
    public string name = "Skill";
    public string description = "This is a skill";
    public Sprite icon;
    public int baseCD = 0;

    public abstract void TriggerSkill();
}
