using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Timer : MonoBehaviour {

    Image fillImg;
    float timeAmt = 10;
    float time;
    bool run;
    bool pause;

    // Use this for initialization
    void Start()
    {
        fillImg = this.GetComponent<Image>();
        time = timeAmt;
        run = false;
        pause = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (pause) return;
        if (run&&time > 0)
        {
            time -= Time.deltaTime;
            fillImg.fillAmount = time / timeAmt;
        }
        else if(time<=0)
        {
            this.transform.parent.gameObject.GetComponent<draggable>().setFinish();
        }
    }

    public void RunTime()
    {
        run = true;
    }

    public void ClearTime()
    {
        time = timeAmt;
        fillImg.fillAmount = 1;
        run = false;
        pause = false;
    }

    public void Pause()
    {
        pause = true;
    }

    public void Resume()
    {
        pause = false;
    }
}
