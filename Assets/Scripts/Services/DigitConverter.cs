using System.Linq;
using System.Numerics;
using TMPro;
using UnityEngine;

public static class DigitConverter
{
    public static (string text, Color color) ConvertToText(BigInteger number)
    {
        return (number.ToString(), new Color(1, 1, 1));
        var str = number.ToString();
        int digits = str.Length;

        var floatPart = digits % 3;
        var integerPart = 3 - floatPart;
        string text = new string(number.ToString().Take(3).ToArray());
        if (floatPart > 0 && digits > 3)
            text = text.Insert(integerPart-1, ",");

        Color color = new Color(1,1,1);

        switch (digits)
        {
            case 4: 
                text += " K";
                color = new Color(0.9f, 0.2f, 0.2f);
                break;
            case 7:
                text += " M";
                color = new Color(0.9f, 0.2f, 0.2f);
                break;
            case 10:
                text += " B";
                color = new Color(0.9f, 0.2f, 0.2f);
                break;
            case 13:
                text += " T";
                color = new Color(0.9f, 0.2f, 0.2f);
                break;
            case 16:
                text += " Qd";
                color = new Color(0.9f, 0.2f, 0.2f);
                break;
            case 19:
                text += " Qn";
                color = new Color(0.9f, 0.2f, 0.2f);
                break;
            case 22:
                text += " Sx";
                color = new Color(0.9f, 0.2f, 0.2f);
                break;
            case 25:
                text += " Sp";
                color = new Color(0.9f, 0.2f, 0.2f);
                break;
            case 28:
                text += " O";
                color = new Color(0.9f, 0.2f, 0.2f);
                break;
            case 31:
                text += " N";
                color = new Color(0.9f, 0.2f, 0.2f);
                break;
            case 34:
                text += " D";
                color = new Color(0.9f, 0.2f, 0.2f);
                break;
        }

        return (text, color);
    }
}