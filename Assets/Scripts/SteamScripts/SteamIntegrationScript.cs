using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Steamworks;


public class SteamIntegrationScript : MonoBehaviour
{

  public bool steamActive = false;

  public bool logOutSteam = false;

  protected Callback<GameOverlayActivated_t> m_GameOverlayActivated;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);

    }



    private void OnEnable() {
  		if (SteamManager.Initialized) {
  			m_GameOverlayActivated = Callback<GameOverlayActivated_t>.Create(OnGameOverlayActivated);
  		}
  	}

    private void OnGameOverlayActivated(GameOverlayActivated_t pCallback) {
  		if(pCallback.m_bActive != 0) {
  			Debug.Log("Steam Overlay has been activated");
  		}
  		else {
  			Debug.Log("Steam Overlay has been closed");
  		}
  	}

    // Update is called once per frame
    void Update()
    {


    }


    void OnApplicationQuit(){
      if(steamActive){
        //Steamworks.SteamClient.Shutdown();
      }
    }


    public void UnlockAllItemsAchievement(){
      Steamworks.SteamUserStats.SetAchievement("COLLECT_ALL_ACH");
      Steamworks.SteamUserStats.StoreStats();
    }

    public void GoodEndingAchievement(){
      Steamworks.SteamUserStats.SetAchievement("ENDING_GOOD_ACH");
      Steamworks.SteamUserStats.StoreStats();
    }

    public void BadEndingAchievement(){
      Steamworks.SteamUserStats.SetAchievement("ENDING_BAD_ACH");
      Steamworks.SteamUserStats.StoreStats();
    }


}
