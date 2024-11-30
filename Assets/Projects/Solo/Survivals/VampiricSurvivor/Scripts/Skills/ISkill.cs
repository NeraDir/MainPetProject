using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SkillType
{
    Knifes,
    Shield,
}

public interface ISkill
{
    public SkillType Type { get; }

    public int Level { get;}

    public void Init();

    public void Use();

    public void LevelUp();
}
