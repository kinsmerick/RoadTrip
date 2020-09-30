using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteamIntegrationScript : MonoBehaviour
{

  public bool steamActive = false;

  public bool logOutSteam = false;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        try
        {
        	Steamworks.SteamClient.Init( 1427300, true );
          steamActive = true;
        }
        catch ( System.Exception e )
        {
        	Debug.Log("Error. No Steam?" + e);
          steamActive = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
      if(steamActive){
        Steamworks.SteamClient.RunCallbacks();
      }

      if(logOutSteam){
        Steamworks.SteamClient.Shutdown();
        logOutSteam  = false;
        steamActive = false;
      }

    }


    void OnApplicationQuit(){
      if(steamActive){
        Steamworks.SteamClient.Shutdown();
      }
    }


}
