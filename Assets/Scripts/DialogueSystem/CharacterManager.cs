using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterManager : MonoBehaviour
{
    public Color dialogueColor;
    public Expression[] expressions;
    public SpeechBubblePosition[] bubblePositions;
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
    public Vector3 pos;
}