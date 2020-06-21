using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAnimCon : MonoBehaviour
{


    public Animator endPanelAnimator;
    public Animator startPanelAnimator;



    private string EndPanelIn = "EndPanelIn";
    private string EndPanelOut = "EndPanelOut";
    private string StartPanelIn = "StartPanelIn";
    private string StartPanelOut = "StartPanelOut";



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void endPanelIn()
    {
        endPanelAnimator.SetTrigger(EndPanelIn);
    }
    public void endPanelOut()
    {
        endPanelAnimator.SetTrigger(EndPanelOut);
    }
    public void startPanelIn()
    {
        startPanelAnimator.SetTrigger(StartPanelIn);
    }
    public void startPanelOut()
    {
        startPanelAnimator.SetTrigger(StartPanelOut);
    }
}
