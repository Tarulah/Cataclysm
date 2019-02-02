using UnityEngine;
using System.Collections;

//Script for sword//

public class DamagePlayer : MonoBehaviour {

    void OnTriggerEnter()
    {
        SharePlayerHealth.SharedHealtheCounter.Health -= 5;
        Debug.Log("Player Health " + SharePlayerHealth.SharedHealtheCounter.Health);
        Debug.Log("Hit player");
        StartCoroutine(DamageCoolDown());
        
    }

    IEnumerator DamageCoolDown()
    {
        yield return new WaitForSeconds(5f);
    }
}
