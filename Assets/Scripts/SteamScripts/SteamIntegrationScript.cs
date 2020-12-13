using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if STEAM
using Steamworks;
#endif

public class SteamIntegrationScript : MonoBehaviour
{

  public bool steamActive = false;

  private static SteamIntegrationScript DetoursSteamInit;

    // Start is called before the first frame update
    void Start()
    {
        if(DetoursSteamInit == null){
          DetoursSteamInit = this;
          DontDestroyOnLoad(this.gameObject);

#if STEAM
        try
        {
        	SteamClient.Init( 1427300, true );
          steamActive = true;
        }
        catch ( System.Exception e )
        {
        	Debug.Log("Error. No Steam?" + e);
          steamActive = false;
        }
#endif
      }
      else{
        GameObject.Destroy(this);
      }

    }

    // Update is called once per frame
    void Update()
    {


    }

    public void UnlockGoodEndingAchievement(){
#if STEAM
  if (SteamClient.IsValid && SteamClient.IsLoggedOn)
      {
          var ach = new Achievement("ENDING_GOOD_ACH");
          ach.Trigger();
      }
#endif
    }

    public void UnlockBadEndingAchievement(){
#if STEAM
  if (SteamClient.IsValid && SteamClient.IsLoggedOn)
      {
          var ach = new Achievement("ENDING_BAD_ACH");
          ach.Trigger();
      }
#endif
    }

    public void UnlockItemsAchievement(){
#if STEAM
  if (SteamClient.IsValid && SteamClient.IsLoggedOn)
      {
          var ach = new Achievement("COLLECT_ALL_ACH");
          ach.Trigger();
      }
#endif
    }


}
