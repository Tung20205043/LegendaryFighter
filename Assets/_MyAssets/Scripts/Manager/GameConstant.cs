public static class GameConstant
{
    public static float timeWaitToGainMana = 0.1f;
    public static float attackRange = 0.3f;
    public static float[] takeDmgTime = { 0.2f, 0.2f, 1.2f, 0.2f, 1.2f };

    public static float manaToDash = 5f;
    //  AttackType { Punch, Skill, UltimateSkill, Kameha, Teleport, HeavyPunch, Defaut }
    public static float[] timeUseSkill = { 0, 0.2f, 1.5f, 3f, 0.2f, 0.8f };
    public static float[] manaToCastSkill = {0, 5, 50, 40, 10, 20, 0 };
    public static string[] AttackCode = { "P", "S", "U", default, default };
}

