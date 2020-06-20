using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameplay : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        enableInputs();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void enableInputs()
    {
        RefHolder.instance.playerController.takeInputsBool = true;
    }
    public void disableInputs()
    {
        RefHolder.instance.playerController.takeInputsBool = false;
    }


}
