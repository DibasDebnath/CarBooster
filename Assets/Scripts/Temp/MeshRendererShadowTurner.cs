using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

[SerializeField]
public class MeshRendererShadowTurner : MonoBehaviour
{
    [SerializeField]
    public Transform parent;

    public Transform child;

    public MeshRenderer meshRenderer;

    // Start is called before the first frame update
    void Start()
    {
        recurser(parent);
    }


    void recurser(Transform trans)
    {
        MeshRenderer[] mesh = trans.GetComponentsInChildren<MeshRenderer>();



        foreach (MeshRenderer element in mesh)
        {
            element.shadowCastingMode = ShadowCastingMode.Off;
        }
        //for (int count = 0; count < parent.childCount; count++)
        //{
        //    parent.GetChild(count);
        //}
    }
    
}
