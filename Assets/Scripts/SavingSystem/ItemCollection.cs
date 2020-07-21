using System;
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ItemCollection
{

  public bool dogPoster = false;
  public bool sadRock = false;
  public bool happyRock = false;
  public bool lollipop = false;

  public static ItemCollection operator +(ItemCollection t, ItemCollection t2)
  {
    ItemCollection temp = new ItemCollection();

    temp.dogPoster = t.dogPoster || t2.dogPoster;
    temp.sadRock = t.sadRock || t2.sadRock;
    temp.happyRock = t.happyRock || t2.happyRock;
    temp.lollipop = t.lollipop || t2.lollipop;

    return temp;
  }

}
