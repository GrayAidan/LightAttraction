using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public GameObject mothPrefab;

    public GameObject currentMoth;

    // Start is called before the first frame update
    void Start()
    {
        Respawn();
    }

    public void Respawn()
    {
        if (currentMoth != null)
        {
            Destroy(currentMoth);
        }

        currentMoth = Instantiate(mothPrefab, this.transform.position, mothPrefab.transform.rotation);


    }
}