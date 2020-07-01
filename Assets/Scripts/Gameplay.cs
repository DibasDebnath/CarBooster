using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameplay : MonoBehaviour
{


    public float levelEndTimer = 10f;

    // Start is called before the first frame update
    void Start()
    {
        //enableInputs();
        disableInputs();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void startGame()
    {
        enableInputs();
        RefHolder.instance.bendingManager.StartCurver();
        RefHolder.instance.playerController.MoveDisplacement = 0;
        StartCoroutine(EndRaceCounter());
    }
    public void endGame()
    {
        disableInputs();
        RefHolder.instance.bendingManager.StopCurver();
        RefHolder.instance.uiCon.uiAnimCon.endPanelIn();
    }


    public void enableInputs()
    {
        RefHolder.instance.playerController.takeInputsBool = true;
    }
    public void disableInputs()
    {
        RefHolder.instance.playerController.takeInputsBool = false;
    }




    IEnumerator EndRaceCounter()
    {
        yield return new WaitForSeconds(levelEndTimer);
        RefHolder.instance.levelGenaration.EndraceTileBool = true;
    }
}
