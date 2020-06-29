using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideHolderScript : MonoBehaviour
{

    public List<GameObject> leftModernSideList;
    public List<GameObject> rightModernSideList;

    // Start is called before the first frame update
    void Start()
    {
        leftModernSideList[Random.Range(0, leftModernSideList.Count)].SetActive(true);
        rightModernSideList[Random.Range(0, rightModernSideList.Count)].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
