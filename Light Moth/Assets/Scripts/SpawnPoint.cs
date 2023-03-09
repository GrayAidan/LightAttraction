using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public GameObject mothPrefab;
    public GameObject deadMoth;
    public GameObject currentMoth;

    // Start is called before the first frame update
    void Start()
    {
        Respawn(false);
    }

    public void Respawn(bool die)
    {
        if (currentMoth != null)
        {
            if (die)
            {
                Instantiate(deadMoth, currentMoth.transform.position, currentMoth.transform.rotation);
            }
            
            Destroy(currentMoth);
        }

        currentMoth = Instantiate(mothPrefab, this.transform.position, mothPrefab.transform.rotation);


    }
}
