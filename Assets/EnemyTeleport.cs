using UnityEngine;
using System.Collections;

public class EnemyTeleport : MonoBehaviour
{
    public GameObject ScareCrow;
    public float RateTele;
    public Transform Player;

    void Start()
    {
       ScareCrow.SetActive(false);
        Spawn();
    }

    public void Spawn()
    {

        StartCoroutine(Teleporter());
    }

        private IEnumerator Teleporter()
    {
        while (true) { 
        yield return new WaitForSeconds(15);
       ScareCrow.SetActive(true);
        transform.position = Camera.main.transform.position + Camera.main.transform.forward * 20;
        
        yield return new WaitForSeconds(8);
            transform.position = new Vector3(0, 0, 0);
            ScareCrow.SetActive(false);
            
            yield return null;
        }
    }
}