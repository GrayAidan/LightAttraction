using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MothTowards : MonoBehaviour
{
    public float maxSpeed;
    public float mothOverlap;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Collider[] lights = Physics.OverlapSphere(this.transform.position, mothOverlap, LayerMask.GetMask("Light"));

        for(int i = 0; i < lights.Length; i++)
        {   
            LightIntensity _li = lights[i].GetComponent<LightIntensity>();

            Vector2 vectorTowardsLight = lights[i].transform.position - transform.position;

            transform.Translate(vectorTowardsLight.normalized * _li.intensity * maxSpeed * Time.deltaTime);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, mothOverlap);
    }
}
