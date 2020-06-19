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

    private void OnEnable()
    {
        m_CurveStrengthID = Shader.PropertyToID("_CurveStrength");
        m_CurveStrengthID2 = Shader.PropertyToID("_CurveStrength2");
    }

	void Update()
	{
		Shader.SetGlobalFloat(m_CurveStrengthID, curveStrength);
		Shader.SetGlobalFloat(m_CurveStrengthID2, curveStrength2);
	}
}
