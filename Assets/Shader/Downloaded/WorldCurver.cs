using System;
using System.Collections;
using UnityEngine;

[ExecuteInEditMode]
public class WorldCurver : MonoBehaviour
{
	[Range(-0.1f, 0.1f)]
	public float curveStrength = 0.01f;
	[Range(-0.1f, 0.1f)]
	public float curveStrength2 = 0.01f;

    int m_CurveStrengthID;
    int m_CurveStrengthID2;

    public float maxSideCurve = 0.01f;
    public float minSideCurve = -0.01f;

    [Header("Private FieldView")]
    public float currentCurveStrenght = 0;
    //public float toBeCurveStrenght;
    public float smoothedCurveStrenght = 0;
    public bool isCurverOn = false;


    //public Shader shader;
    private void OnEnable()
    {
        //m_CurveStrengthID = Shader.PropertyToID("_CurveStrength");
        //m_CurveStrengthID2 = Shader.PropertyToID("_CurveStrength2");
        m_CurveStrengthID = Shader.PropertyToID("SideCurve");
        m_CurveStrengthID2 = Shader.PropertyToID("DownCurve");
    }

	void Update()
	{
        Shader.SetGlobalFloat(m_CurveStrengthID, smoothedCurveStrenght);
        //Shader.SetGlobalFloat(m_CurveStrengthID2, curveStrength2);

        
        if (isCurverOn && RefHolder.instance.playerController.ProcessedTap)
        {
            
            smoothedCurveStrenght = Mathf.Lerp(smoothedCurveStrenght, currentCurveStrenght, 0.05f * Time.deltaTime);
        }
        
    }

    private void Start()
    {
        currentCurveStrenght = UnityEngine.Random.Range(minSideCurve, maxSideCurve);
        StartCurver();
        //Debug.LogError(Shader.GetGlobalFloat(m_CurveStrengthID));
    }

    public void StartCurver()
    {
        isCurverOn = true;
        
        smoothedCurveStrenght = currentCurveStrenght;
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
            if(isCurverOn && RefHolder.instance.playerController.ProcessedTap)
            {
                currentCurveStrenght = UnityEngine.Random.Range(minSideCurve, maxSideCurve);
            }
            
        }
        

    }

}
