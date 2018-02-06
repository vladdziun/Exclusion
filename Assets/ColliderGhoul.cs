using UnityEngine;
using System.Collections;

public class ColliderGhoul : MonoBehaviour {



    void OnTriggerEnter(Collider PlayerCol)
    {

        if (PlayerCol.CompareTag("Ghoul"))
            GameManager.gm.currentTime = 100;

    }
}
