using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightIntensity : MonoBehaviour
{
    public float intensity;
    public List<MouseOver> intensityButtons;

    public Material lightMat;
    private Material ogMat;

    private int lastButtonPressed;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            intensityButtons.Add(transform.GetChild(i).gameObject.GetComponent<MouseOver>());
        }

        ogMat = intensityButtons[0].GetComponent<MeshRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < intensityButtons.Count; i++)
        {
            if (intensityButtons[i].mouseOver)
            {
                CheckClick(i);
            }

            if(i <= lastButtonPressed)
            {
                intensityButtons[i].GetComponent<MeshRenderer>().material = lightMat;
            }
            else
            {
                intensityButtons[i].GetComponent<MeshRenderer>().material = ogMat;
            }
        }

        intensity = lastButtonPressed;
        print(intensity);
    }

    public void CheckClick(int index)
    {
        if (Input.GetMouseButtonDown(0))
        {
            lastButtonPressed = index;
        }
    }
}
