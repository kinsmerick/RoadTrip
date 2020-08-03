using System;
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ItemCollection
{

//a bool for each collectable item you can find.
//the pickup items will have a instance of this class
//with the corresponding item set to "true"
//then, adds (using the override below) that instance to the saved data
  public bool dogPoster = false;
  public bool sadRock = false;
  public bool happyRock = false;
  public bool lollipop = false;
  public bool robot = false;
  public bool plushFrog = false;
  public bool happyOwl = false;
  public bool sadOwl = false;




//addition override so you can simply load the saved save data, add the item from an instance of this class, then save it back
//for each item there should be another line added to this override to allow for it
  public static ItemCollection operator +(ItemCollection t, ItemCollection t2)
  {
    ItemCollection temp = new ItemCollection();

    temp.dogPoster = t.dogPoster || t2.dogPoster;
    temp.sadRock = t.sadRock || t2.sadRock;
    temp.happyRock = t.happyRock || t2.happyRock;
    temp.lollipop = t.lollipop || t2.lollipop;
    temp.robot = t.robot || t2.robot;
    temp.plushFrog = t.plushFrog || t2.plushFrog;
    temp.happyOwl = t.happyOwl || t2.happyOwl;
    temp.sadOwl = t.sadOwl || t2.sadOwl;

    return temp;
  }

}
