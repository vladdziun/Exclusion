using UnityEngine;
using System.Collections;

public class NewBehaviourScriptss : MonoBehaviour
{

    void OnTriggerEnter(Collider GO)
    {

        if (GO.CompareTag("Player"))
        {

            GameManager.gm.BeatLevel();
        }
    }
}