using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterManager : MonoBehaviour
{
    public Color DialogueColor;
    public Expression[] Expressions;
    public SpeechBubblePosition[] BubblesPositions;
    public bool isDaniella;
}

[System.Serializable]
public struct Expression
{
    public string expressionName;
    public Sprite expression;
}

[System.Serializable]
public struct SpeechBubblePosition
{
    public string posName;
    public Vector3 textPos;
    public Vector3 option1Pos;
    public Vector3 option2Pos;
}