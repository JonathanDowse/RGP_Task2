using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StopwatchAnimator : MonoBehaviour
{
    public Sprite frame1;
    public Sprite frame2;
    public Sprite frame3;
    public Sprite frame4;
    public Sprite frame5;
    public Sprite frame6;
    public Sprite frame7;
    public Sprite frame8;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("FrameSwitch", 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FrameSwitch()
    {
        if (this.GetComponent<Image>().sprite == frame1)
        {
            this.GetComponent<Image>().sprite = frame2;
            Invoke("FrameSwitch", 1);
        }
        else if (this.GetComponent<Image>().sprite == frame2)
        {
            this.GetComponent<Image>().sprite = frame3;
            Invoke("FrameSwitch", 1);
        }
        else if (this.GetComponent<Image>().sprite == frame3)
        {
            this.GetComponent<Image>().sprite = frame4;
            Invoke("FrameSwitch", 1);
        }
        else if (this.GetComponent<Image>().sprite == frame4)
        {
            this.GetComponent<Image>().sprite = frame5;
            Invoke("FrameSwitch", 1);
        }
        else if (this.GetComponent<Image>().sprite == frame5)
        {
            this.GetComponent<Image>().sprite = frame6;
            Invoke("FrameSwitch", 1);
        }
        else if (this.GetComponent<Image>().sprite == frame6)
        {
            this.GetComponent<Image>().sprite = frame7;
            Invoke("FrameSwitch", 1);
        }
        else if (this.GetComponent<Image>().sprite == frame7)
        {
            this.GetComponent<Image>().sprite = frame8;
            Invoke("FrameSwitch", 1);
        }
        else if (this.GetComponent<Image>().sprite == frame8)
        {
            this.GetComponent<Image>().sprite = frame1;
            Invoke("FrameSwitch", 1);
        }
    }
}
