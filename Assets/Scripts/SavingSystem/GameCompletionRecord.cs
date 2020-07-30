using System;
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GameCompletionRecord
{
//works very similarly to ItemCollection.cs

  public bool act1Complete = false;
  public bool act2Complete = false;
  public bool act3Complete = false;


    public static GameCompletionRecord operator +(GameCompletionRecord t, GameCompletionRecord t2)
    {
      GameCompletionRecord temp = new GameCompletionRecord();

      temp.act1Complete = t.act1Complete || t2.act1Complete;
      temp.act2Complete = t.act2Complete || t2.act2Complete;
      temp.act3Complete = t.act3Complete || t2.act3Complete;

      return temp;
    }

}
