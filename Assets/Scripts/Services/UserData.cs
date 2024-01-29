using System;
using System.Numerics;
using UnityEngine;

public static class UserData
{
    public static BigInteger Coins
    {
        get => BigInteger.Parse(PlayerPrefs.GetString("Coins"));
        set => PlayerPrefs.SetString("Coins", value.ToString());
    }
    public static int Stage
    {
        get => PlayerPrefs.GetInt("Stage");
        set => PlayerPrefs.SetInt("Stage", value);
    }
    public static int Level
    {
        get => PlayerPrefs.GetInt("Level");
        set => PlayerPrefs.SetInt("Level", value);
    }
    public static int LevelCharacter
    {
        get => PlayerPrefs.GetInt("LevelCharacter");
        set => PlayerPrefs.SetInt("LevelCharacter", value);
    }
    public static int GetAbilityLevel(string codeName)
    {
        var name = "LevelAbility" + codeName;
        if (!PlayerPrefs.HasKey(name)) return 0;

        return PlayerPrefs.GetInt(name);
    }
    public static void IncrementAbilityLevel(string codeName)
    {
        var current = GetAbilityLevel(codeName);
        PlayerPrefs.SetInt("LevelAbility", current + 1);
    }
}