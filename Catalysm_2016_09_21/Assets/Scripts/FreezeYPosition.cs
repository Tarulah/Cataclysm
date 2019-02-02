using UnityEngine;
using System.Collections;

public class FreezeYPosition : MonoBehaviour {
	void Update () {
		Vector3 newPosition = transform.position;
		if(newPosition.y<2.7f)
			newPosition.y = 2.7f;
	}
}
