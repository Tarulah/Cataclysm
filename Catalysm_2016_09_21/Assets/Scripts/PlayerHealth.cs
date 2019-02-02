using UnityEngine;
using System.Collections;

//Script for player//

//Is used to share the information about players healht with other scripts
public class SharePlayerHealth {

    private static SharePlayerHealth HealthInstance = null;
    public static SharePlayerHealth SharedHealtheCounter
    {
        get
        {
            if (HealthInstance == null)
            {
                HealthInstance = new SharePlayerHealth();
            }
            return HealthInstance;
        }
    }
    public int Health = 100;
}

public class PlayerHealth : MonoBehaviour
{
    void Update()
    {
        //Health check
        if (SharePlayerHealth.SharedHealtheCounter.Health <= 0) {
            //The player is dead
            Debug.Log("Död");
        }
    }
    
}
