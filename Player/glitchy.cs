using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class glitchy : MonoBehaviour
{
    public Shader Shader;
    public float flipIntensity;
    public float ColorIntensity;
    public float flicktime = 0.5f;
    public float glitchtimeup = .5f;
    public float glitchtimedown = .5f;
    float flicker;
    float glitchup;
    float glitchdown;
    public Material m;
    // Start is called before the first frame update
    void Start()
    {
        m = new Material(Shader);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        m.SetFloat("_ColorIntensity", ColorIntensity);
        flicker += Time.deltaTime * ColorIntensity;
        if (flicker > flicktime)
        {
            m.SetFloat("filterRadius", Random.Range(-3f, 3f) * ColorIntensity);
            m.SetVector("direction", Quaternion.AngleAxis(Random.Range(0, 360) * ColorIntensity, Vector3.forward) * Vector4.one);
            flicker = 0;
            flicktime = Random.value;
        }

        if (ColorIntensity == 0)
        {
            m.SetFloat("filterRadius", 0);
        }

        glitchup += Time.deltaTime * flipIntensity;
        if (glitchup > glitchtimeup)
        {
            if (Random.value < 0.1f * flipIntensity)
            {
                m.SetFloat("flip_up", Random.Range(0, 1f) * flipIntensity);
            }
            else
            {
                m.SetFloat("flip_up", 0);
            }

            glitchup = 0;
            glitchtimeup = Random.value / 10f;
        }

        if (flipIntensity == 0)
        {
            m.SetFloat("flip_up", 0);
        }


        glitchdown += Time.deltaTime * flipIntensity;
        if (glitchdown > glitchtimedown)
        {
            if (Random.value < 0.1f * flipIntensity)
            {
                m.SetFloat("flip_down", 1 - Random.Range(0, 1f) * flipIntensity);
            }
            else
            {
                m.SetFloat("flip_down", 1);
            }

            glitchdown = 0;
            glitchtimedown = Random.value / 10f;
        }

        if (flipIntensity == 0) { 
            m.SetFloat("flip_down", 1);
        }
        Graphics.Blit(source, destination, m);
    }
}
