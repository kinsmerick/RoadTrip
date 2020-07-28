using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

/*The CharacterManager class will be attached to each character in the game, including NPCs. Here we can set
 the color that character's text bubbles will be, any expressions/art they will cycle between in scenes
 (only Daniella and Mish will have any in car/motel scenes), any set positions their text will be printed to
 (only relevant again for the car and motel scenes), and a boolean that will track if this character is Daniella
 or not. All of this is set within the Unity editor. The Dialogue Manager refers to all this data.
 
 When we have proper storyboards of scenes/shots, Kinsey will make a txt file with all the names/numbers, and
 prefabs of car and motel scene Daniella and Mish characters can be made.
 
 YET TO BE IMPLEMENTED: YarnCommand SetExpression that will change the Sprite being used by the character
 GameObject's SpriteRenderer to a given expression.*/

public class CharacterManager : MonoBehaviour
{
    [Tooltip("This is the color the character's speech bubbles will be.")]
    public Color DialogueColor;
    [Tooltip("This is the array of possible expressions a character can have during car and motel scenes.")]
    public Expression[] Expressions;
    [Tooltip("This is the array of possible placements of speech bubbles for a character during car and motel " +
                "scenes. Only Daniella needs positions for the option bubbles, as other characters will not " +
                "have dialogue choices connected to them.")]
    public SpeechBubblePosition[] BubblesPositions;
    [Tooltip("Check true if this character is Daniella.")]
    public bool isDaniella;

    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = this.GetComponent<SpriteRenderer>();
    }

    [YarnCommand("SetExpression")]
    public void SetExpression(string exp)
    {
        //changes sprite being rendered by sprite renderer to sprite in Expressions[] that matches exp
        Debug.Log("SetExpression called with " + exp);

        //checks to make sure the user entered expressions into the character's Expressions array
        if (Expressions.Length < 1)
        {
            Debug.LogError(gameObject.name + " doesn't have any initialized expressions in their array.");
        }//end if

        else
        {
            //goes through the character's Expressions array to find an expression with a name that matches the
            //name passed to the method in the command call. If found, it sets the character's sprite renderer's
            //sprite to the one associated with the found expression. If not, it throws an error.

            for (int i = 0; i < Expressions.Length; i++)
            {
                if (string.Equals(Expressions[i].expressionName, exp, System.StringComparison.CurrentCultureIgnoreCase))
                {
                    _spriteRenderer.sprite = Expressions[i].expression;
                    break;
                }

                if (i == (Expressions.Length - 1))
                {
                    Debug.LogError(exp + " expression not found in " + gameObject.name + "'s Expressions array.");
                }

            }//end for loop

        }//end else insuring Expressions[] was initialized

    }//end SetExpression method

    private void Update()
    {
        if(Input.GetKeyDown("space") && !isDaniella)
        {
            SetExpression("test");
        }
    }
}

/*The Expression struct stores an expression's name and related sprite.
 
 This information is only relevant in car and motel scenes, so they won't be initialized in the
 CharacterManager components of character GameObjects in exploration scenes.*/

[System.Serializable]
public struct Expression
{
    [Tooltip("The name of the expression that will be called through Yarn, i.e. \"Happy\".")]
    public string expressionName;
    [Tooltip("The Sprite that is to be shown when this expression is called.")]
    public Sprite expression;
}

/*The SpeechBubblePosition struct stores a configuration of speech bubble's name, the position of the
 text speech bubble associated with the name, and, if Daniella, should also have the positions of
 the options buttons. Note that other characters could have data accidentally entered into the options
 bubbles, but it would never be referred to, so the game wouldn't break.
 
 This information is only relevant in car and motel scenes, so they won't be initialized in the
 CharacterManager components of character GameObjects in exploration scenes.*/

[System.Serializable]
public struct SpeechBubblePosition
{
    [Tooltip("The name of this configuration of speech bubbles, i.e. \"Far\" or \"InsideCar\". The Z axis should " +
                "stay at zero.")]
    public string posName;
    public Vector3 textPos;
    public Vector3 option1Pos;
    public Vector3 option2Pos;
}