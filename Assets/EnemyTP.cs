using UnityEngine;
using System.Collections;

public class EnemyTP : MonoBehaviour
{
    public GameObject ScareCrow;
    public float RateTele;
    public Transform target;
    public float minX;
    public float maxX;
    public float minZ;
    public float maxZ;


    void Start()
    {
        
        Spawn();
    }

    public void Spawn()
    {

        StartCoroutine(TP());
    }

    private IEnumerator TP()
    {
      
        while(true)
        {
            

            yield return new WaitForSeconds(RateTele);
            ScareCrow.SetActive(true);

            transform.position = new Vector3(target.position.x + Random.Range(minX,maxX), transform.position.y, target.position.z + Random.Range(minZ, maxZ));
            
           
            yield return null;
            
        }
       

    }
    void OnTriggerEnter(Collider GhoulCol)
    {

        if (GhoulCol.CompareTag("Player"))
            GameManager.gm.currentTime = 100;

    }

}
