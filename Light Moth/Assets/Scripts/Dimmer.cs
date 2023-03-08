using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dimmer : MonoBehaviour
{
    [HideInInspector]
    public float intensity;
    public float lightSpriteMaxSize;

    public GameObject sliderCanvas;

    private MouseOver _mo;
    private GameObject currentSlider;
    private Slider currentSliderBar;
    private SpriteRenderer _sr;

    // Start is called before the first frame update
    void Start()
    {
        _mo = GetComponent<MouseOver>();
        _sr = transform.GetChild(2).gameObject.GetComponent<SpriteRenderer>();
        _sr.color = new Color(_sr.color.r, _sr.color.g, _sr.color.b, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (_mo.mouseOver)
        {
            DimmerOpen();
        }
        else if(!_mo.mouseOver && currentSlider != null)
        {
            Destroy(currentSlider);
        }

        if(intensity == 0)
        {
            transform.GetChild(1).gameObject.GetComponent<CircleCollider2D>().enabled = false;
        }
        else
        {
            transform.GetChild(1).gameObject.GetComponent<CircleCollider2D>().enabled = true;
        }
    }

    public void DimmerOpen()
    {
        if(currentSlider == null)
        {
            currentSlider = Instantiate(sliderCanvas, transform.GetChild(0));
            currentSliderBar = currentSlider.transform.GetChild(0).gameObject.GetComponent<Slider>();
            currentSliderBar.value = intensity;
        }

        intensity = currentSliderBar.value;
        _sr.transform.localScale = new Vector2(lightSpriteMaxSize * intensity, lightSpriteMaxSize * intensity);
        _sr.color = new Color(_sr.color.r, _sr.color.g, _sr.color.b, intensity / 2.5f);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, transform.GetChild(1).gameObject.GetComponent<CircleCollider2D>().radius);
    }
}
