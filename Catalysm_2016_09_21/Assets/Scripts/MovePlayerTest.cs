using UnityEngine;
using System.Collections;

//Script for player//

public class MovePlayerTest : MonoBehaviour {

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            //Vasen
            transform.position = new Vector3(-1, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            //Oikealle
            transform.position = new Vector3(1, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            //Ylös
            transform.position = new Vector3(0, 1, 0);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            //Alas
            transform.position = new Vector3(0, -1, 0);
        }
    }
}
