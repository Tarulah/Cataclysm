using UnityEngine;
using System.Collections;

public class AmmoHit : MonoBehaviour {
	void OnParticleCollision(GameObject col){
		//if (col.tag == "Enemy") {
			Rigidbody rb = col.GetComponentInParent<Rigidbody> ();
			Vector3 direction = col.transform.position - transform.position;
			if(rb)rb.AddForce (direction.normalized * 100f); 
		//}	
	}

}
