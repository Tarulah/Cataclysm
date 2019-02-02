using UnityEngine;
using System.Collections;

//Tulee vihollisille ja pelaajalle

public class SetOnFire : MonoBehaviour {

    public ParticleSystem FireEffect;
    public ParticleSystem.EmissionModule em;

    void Start()
    {
        FireEffect = gameObject.GetComponentInChildren<ParticleSystem>();
    }

    void OnTriggerStay(Collider col)
    {
        if(col.gameObject.tag == "FireOnGroundTag")
        {
            Debug.Log("AAAAAAAAAAAAAAHHHH!!!!!!!!!!!!!!");
            FireEffect.Play();
            SharePlayerHealth.SharedHealtheCounter.Health -= 1;
            //em = FireEffect.emission;
            //em.enabled = true;
        }

        StartCoroutine(fireDelay());

    }

    IEnumerator fireDelay()
    {
        yield return new WaitForSeconds(3f);
        Debug.Log("Not on fire");
        FireEffect.Stop();
        //em = FireEffect.emission;
        //em.enabled = false;
    }
    
}
