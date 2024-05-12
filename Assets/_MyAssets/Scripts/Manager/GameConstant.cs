using Cinemachine;
using UnityEngine;

public static class GameConstant
{
    public static float timeWaitToGainMana = 0.1f;
    public static float[] timeUseSkill = { 0, 0.2f, 3 };
    public static float attackRange = 0.3f;
    public static float takeDmgTime = 0.2f;

    public static float manaToDash = 5f;
    // public enum AttackType { Punch, Skill, UltimateSkill, Defaut }
    public static float[] manaToCastSkill = {0, 5, 50, 0 };
}

