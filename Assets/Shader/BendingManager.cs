using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

[ExecuteAlways]
public class BendingManager : MonoBehaviour
{

    private string Enable = "ENABLE";
    private int SideCurveID = Shader.PropertyToID("SIDE_CURVE");
    private int DownCurveID = Shader.PropertyToID("DOWN_CURVE");



    [Header("Public FieldView")]
    //[Range(-0.1f, 0.1f)]
    //public float curveStrength = 0.01f;
    //[Range(-0.1f, 0.1f)]
    //public float curveStrength2 = 0.01f;
    [Range(0, 0.01f)]
    public float downCurve = 0f;

    public float maxSideCurve = 0.01f;
    public float minSideCurve = -0.01f;

    [Header("Private FieldView")]
    public float currentCurveStrenght = 0;
    //public float toBeCurveStrenght;
    public float smoothedCurveStrenght = 0;
    public bool isCurverOn = false;


    void Update()
    {
        Shader.SetGlobalFloat(SideCurveID, smoothedCurveStrenght);
        //Shader.SetGlobalFloat(m_CurveStrengthID2, curveStrength2);

        if(RefHolder.instance != null)
        {
            if (isCurverOn && RefHolder.instance.playerController.ProcessedTap)
            {

                smoothedCurveStrenght = Mathf.Lerp(smoothedCurveStrenght, currentCurveStrenght, 0.05f * Time.deltaTime);
            }
        }
        

    }

    private void Start()
    {
        currentCurveStrenght = UnityEngine.Random.Range(minSideCurve, maxSideCurve);
        smoothedCurveStrenght = currentCurveStrenght;
        Shader.SetGlobalFloat(DownCurveID, downCurve);
        //StartCurver();

        //Debug.LogError(Shader.GetGlobalFloat(m_CurveStrengthID));
    }

    public void StartCurver()
    {
        isCurverOn = true;

        //smoothedCurveStrenght = currentCurveStrenght;
        StartCoroutine(CurveValueChanger());
    }

    public void StopCurver()
    {
        isCurverOn = false;
        StopCoroutine(CurveValueChanger());
    }


    IEnumerator CurveValueChanger()
    {

        while (isCurverOn)
        {

            float lateUpdate = UnityEngine.Random.Range(5, 10);
            yield return new WaitForSeconds(lateUpdate);
            if (isCurverOn && RefHolder.instance.playerController.ProcessedTap)
            {
                currentCurveStrenght = UnityEngine.Random.Range(minSideCurve, maxSideCurve);
            }

        }


    }







    private void Awake()
    {
        if (Application.isPlaying)
        {
            Shader.EnableKeyword(Enable);            
        }
        else
        {
            Shader.DisableKeyword(Enable);
        }
        Shader.SetGlobalFloat(SideCurveID, 0f);
    }

    private void OnEnable()
    {
        if (!Application.isPlaying)
            return;

        RenderPipelineManager.beginCameraRendering += OnBeginCameraRendering;
        RenderPipelineManager.endCameraRendering += OnEndCameraRendering;
    }
    private void OnDisable()
    {
        RenderPipelineManager.beginCameraRendering -= OnBeginCameraRendering;
        RenderPipelineManager.endCameraRendering -= OnEndCameraRendering;
    }


    private static void OnBeginCameraRendering(ScriptableRenderContext ctx,
                                              Camera cam)
    {
        cam.cullingMatrix = Matrix4x4.Ortho(-300, 300, -300, 300, 0.001f, 300) *
                            cam.worldToCameraMatrix;
    }

    private static void OnEndCameraRendering(ScriptableRenderContext ctx,
                                              Camera cam)
    {
        cam.ResetCullingMatrix();
    }


}
