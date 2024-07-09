using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Unity.Mathematics;
using UnityEngine;

public class LightSource : MonoBehaviour
{
    [Header("Light Settings")]
    public Gradient colorGradient;

    public float speed = 0.2f;
    public float emission = 2.3f;
    public Vector2 minMaxStartOffset;

    [Header("References")]
    public MeshRenderer lightRenderer;
    public MeshRenderer emissionRenderer;
    public Light ligth;

    Color color;
    Material m_emissionMaterial;
    Material m_lightBeamMaterial;

    float m_currentTime;

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

        m_emissionMaterial.color = color;
        m_emissionMaterial.SetColor ("_EmissionColor", color);

        ligth.color = color;
    }
}
