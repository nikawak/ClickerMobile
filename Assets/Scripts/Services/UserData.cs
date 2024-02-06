using System;
using System.Numerics;
using UnityEngine;

public static class UserData
{
    public static void ResetAll()
    {
        Coins = 0;
        Stage = 0;
        Level = 0;
        LevelCharacter = 0;
        StageCharacter = 0;
    }
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
    public static int StageCharacter
    {
        get => PlayerPrefs.GetInt("StageCharacter");
        set => PlayerPrefs.SetInt("StageCharacter", value);
    }
    public static int GetAbilityLevel(string codeName) => PlayerPrefs.GetInt("LevelAbility" + codeName);
    
    public static void IncrementAbilityLevel(string codeName)
    {
        var current = GetAbilityLevel(codeName);
        PlayerPrefs.SetInt("LevelAbility" + codeName, current + 1);
    }
}