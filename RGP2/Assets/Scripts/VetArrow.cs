using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VetArrow : MonoBehaviour
{
    public Sprite vetArrow1;
    public Sprite vetArrow2;
    public SpriteRenderer vetArrowRender;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("ArrowSwap", 1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ArrowSwap()
    {
        if(vetArrowRender.sprite == vetArrow1)
        {
            vetArrowRender.sprite = vetArrow2;
        }

        else if (vetArrowRender.sprite == vetArrow2)
        {
            vetArrowRender.sprite = vetArrow1;
        }

    }
}
