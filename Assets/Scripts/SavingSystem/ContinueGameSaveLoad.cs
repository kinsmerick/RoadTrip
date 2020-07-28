using System;
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Yarn.Unity;

[Serializable]
public class ContinueGameSaveLoad : MonoBehaviour
{

  public string savedSceneName;
  public string savedNodeName;
  public InMemoryVariableStorage savedVars;
  public bool loadingScene = false;

  public void Start(){
    DontDestroyOnLoad(this.gameObject);
    SceneManager.sceneLoaded += OnSceneLoaded;
  }

  public void OnSceneLoaded(Scene scene, LoadSceneMode mode){

  }

  public void ContinueGame(){
    loadingScene = true;
    SceneManager.LoadScene(savedSceneName);

  }

  public void SaveGame(){
    savedSceneName = SceneManager.GetActiveScene().name;
  }

}
