using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Unity.Mathematics;
using UnityEngine;

public class LightSource : MonoBehaviour
{
    public Gradient colorGradient;

    public float speed = 0.2f;

    public MeshRenderer lightRenderer;
    public MeshRenderer emissionRenderer;
    public Light ligth;

    public Color color;
    Material m_emissionMaterial;
    Material m_lightBeamMaterial;

    float m_currentTime;

    public Vector2 minMaxStartOffset;
    // Start is called before the first frame update
    void Start()
    {
        m_currentTime = UnityEngine.Random.Range (minMaxStartOffset.x, minMaxStartOffset.y);

        m_lightBeamMaterial = lightRenderer.sharedMaterial = new Material (lightRenderer.material);
        m_emissionMaterial = emissionRenderer.sharedMaterial = new Material (emissionRenderer.material);
    }

    // Update is called once per frame
    void Update()
    {
        m_currentTime += Time.deltaTime * speed;

        while(m_currentTime > 1 )
        {
            m_currentTime -= 1;
        }

        color = colorGradient.Evaluate (m_currentTime);

        m_lightBeamMaterial.SetColor ("_Light_Color", color);
        m_lightBeamMaterial.SetColor ("_Emission", color);

        m_emissionMaterial.SetColor ("_Color", color);
        m_emissionMaterial.SetColor ("_Emission", color);
    }
}
