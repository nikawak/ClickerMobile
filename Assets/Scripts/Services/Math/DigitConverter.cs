using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using TMPro;
using UnityEngine;

public static class DigitConverter
{
    public static Dictionary<int, string> NumberScale = new Dictionary<int, string>()
    {
        { 0, "" },    { 1, " K" },  { 2, " M" },  { 3, " B" },  { 4, " T" },  { 5, " Qd" },
        { 6, " Qn" }, { 7, " Sx" },  { 8, " Sp" },  { 9, " A" },  { 10, " B" }, { 11, " C" },
        { 12, " D" }, { 13, " E" }, { 14, " E" }, { 15, " F" }, { 16, " G" }, { 17, " H" }, 
        { 18, " I" }, { 19, " G" }, { 20, " L" }, { 21, " N" }, { 22, " O" }, { 23, " P" },
        { 24, " R" }, { 25, " U" }, { 26, " V" }, { 27, " W" }, { 28, " X" }, { 29, " Y" },
        { 30, " Z" }, { 31, " USSR+" }, { 32, " SSS+" }, { 33, " Kaneki Ken" }
    };
    public static (string text, Color color) ConvertToText(BigInteger number)
    {
        var str = number.ToString();
        int digits = str.Length;

        var floatPart = digits % 3;
        var integerPart = 3 - floatPart;
        string text = new string(number.ToString().Take(3).ToArray());
        if (floatPart > 0 && digits > 3)
            text = text.Insert(floatPart, ",");

        Color color = new Color(1,1,1);
        text += NumberScale[(digits-1)/3];

        return (text, color);
    }
}