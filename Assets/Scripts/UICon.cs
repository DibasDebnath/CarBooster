using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UICon : MonoBehaviour
{
    public UIAnimCon uiAnimCon;




    
    public EventTrigger tapToStartEventTrigger;
    public GameObject tapToStartEventTriggerObject;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
                
    }

    public void TapToStart()
    {
        //Debug.Log("Tap to Start Press");
        tapToStartEventTrigger.enabled = false;
        tapToStartEventTriggerObject.SetActive(false);
        uiAnimCon.startPanelOut();
        RefHolder.instance.gameplay.startGame();
    }

    public void RestartButtonTap()
    {
        uiAnimCon.endPanelOut();
        uiAnimCon.startPanelIn();
        tapToStartEventTrigger.enabled = true;
        tapToStartEventTriggerObject.SetActive(true);
    }
}
