using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour
{

    public ParticleSystem IceEffect;
    public GameObject LightningEffect;
    public GameObject FireEffect;

    public GameObject FireBall;
    public GameObject HandLightning;
    public GameObject HandFire;

    Camera FpsCam;
    LineRenderer LaserLine;

    WaitForSeconds SingleTapShotDuration = new WaitForSeconds(0.1f);
    WaitForSeconds ThreeSecHoldShotDuration = new WaitForSeconds(0.1f);
    WaitForSeconds FiveSecHoldShotDuration = new WaitForSeconds(0.1f);

    float NextFrost;
    float NextFire;

    int SpellChoice = 1;

    void Start()
    {
        FpsCam = GetComponentInParent<Camera>();
        IceEffect = GetComponentInChildren<ParticleSystem>();
        //LightningEffect = GetComponentInChildren<ParticleSystem> ();
        LaserLine = GetComponent<LineRenderer>();

        HandFire.SetActive(false);
        HandLightning.SetActive(false);
    }

    void Update()
    {

        Shoot();
        //Lightning ();

    }

    void Frost()
    {
        IceEffect.emissionRate = 9001;
    }

    void Lightning()
    {
        // single tap, damage = 12,5; range 15; 10% chance to affect up to 2 enemies <3m
        //LightningEffect.emissionRate = 100;
        LightningEffect.SetActive(true);
        LightningLine(15f);

        // 3s hold, damage = 17,5; range = 10; 10% chance to affect up to 3 enemies <5m

        // 5s hold, damage = 22,5; range = 5; 10% chance to affect up to 5 enemies <7m


    }

    void Fire()
    {
        if (Input.GetMouseButtonDown(0))
        {
            float force = 500f;

            GameObject fireball = Instantiate(FireBall, FireEffect.transform.position, FireEffect.transform.rotation) as GameObject;

            Rigidbody rb = fireball.GetComponent<Rigidbody>();
            rb.AddForce(FireEffect.transform.forward * force);

            Destroy(fireball, 2f);
        }
    }

    void Shoot()
    {

        if (Input.GetKey(KeyCode.Alpha1))   // FROST
        {
            SpellChoice = 1;
            HandFire.SetActive(false);
            HandLightning.SetActive(false);
        }
        else if (Input.GetKey(KeyCode.Alpha2))  // LIGHTNING
        {
            SpellChoice = 2;
            HandFire.SetActive(false);
            HandLightning.SetActive(true);
        }
        else if (Input.GetKey(KeyCode.Alpha3))  // FIRE
        {
            SpellChoice = 3;
            HandFire.SetActive(true);
            HandLightning.SetActive(false);
        }

        if (Input.GetMouseButton(0))
        {
            if (SpellChoice == 1)
            {
                Frost();
                //LightningEffect.emissionRate = 0;
            }
            else if (SpellChoice == 2)
            {
                Lightning();
                IceEffect.emissionRate = 0;
            }
            else if (SpellChoice == 3)
            {
                Fire();
            }

        }
        else
        {
            IceEffect.emissionRate = 0;
            //LightningEffect.emissionRate = 0;
            LightningEffect.SetActive(false);
            //FireEffect.SetActive(false);
        }

    }

    // TYÖN ALLA!!!!!
    void LightningLine(float lightningWeaponRange)
    {
        float lightningGunDamage = 12.5f;
        float lightningFireRate = .2f;
        //float lightningWeaponRange = 15f;
        float lightningHitForce = 50f;

        float time = 0;

        RaycastHit hit;

        //Set position to the center of the screen using ViewPortToWorldPoint.
        Vector3 rayOrigin = FpsCam.ViewportToWorldPoint(new Vector3(.5f, .5f, 0f));

        //if (Input.GetMouseButtonDown (0) && Time.time > NextFire)
        //{
        //	//time += Time.deltaTime;

        //	NextFire = Time.time + lightningFireRate;	
        //	StartCoroutine (SingleTapShotEffect ());

        LaserLine.SetPosition(0, LightningEffect.transform.position);

        /*if (Input.GetMouseButtonUp (0) && time < 3)
        {

        }
        else if (Input.GetMouseButtonUp (0) && time >= 3) {
            StartCoroutine (ThreeSecondHoldShotEffect ());
        } 
        else if (Input.GetMouseButtonUp (0) && time >= 5) 
        {
            StartCoroutine (FiveSecHoldShotEffect ());
        }
        */

        if (Physics.Raycast(rayOrigin, FpsCam.transform.forward, out hit, lightningWeaponRange))
        {
            LaserLine.SetPosition(1, hit.point);

            EnemyHealth health = hit.collider.GetComponentInParent<EnemyHealth>();

            if (health != null)
            {
                health.Damage(lightningGunDamage);
                Debug.Log(health.BruteHealth);
            }
        }
        else
        {
            LaserLine.SetPosition(1, rayOrigin + (FpsCam.transform.forward * lightningWeaponRange));
        }

        //time = 0;
        //}
    }

    IEnumerator SingleTapShotEffect()
    {
        LaserLine.enabled = true;
        yield return SingleTapShotDuration;
        Debug.Log("Single tap shot effect!");
        LaserLine.enabled = false;
    }

    IEnumerator ThreeSecondHoldShotEffect()
    {
        LaserLine.enabled = true;
        yield return ThreeSecHoldShotDuration;
        Debug.Log("Three sec shot effect!");
        LaserLine.enabled = false;
    }

    IEnumerator FiveSecHoldShotEffect()
    {
        LaserLine.enabled = true;
        yield return FiveSecHoldShotDuration;
        Debug.Log("Five sec shot effect!");
        LaserLine.enabled = false;
    }

}
