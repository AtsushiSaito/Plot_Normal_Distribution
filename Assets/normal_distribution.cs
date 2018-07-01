using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class normal_distribution : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        RandomParticleSystem();
    }

    // Update is called once per frame
    void Update()
    {
        RandomParticleSystem();
        //Debug.Log(NormalPDF(1, 1, 0));
    }

    void RandomParticleSystem()
    {
        ParticleSystem particleSystem = GetComponent<ParticleSystem>();
        int num = 1000;

        particleSystem.Emit(num);
        ParticleSystem.Particle[] particle = new ParticleSystem.Particle[num];
        particleSystem.GetParticles(particle);
        particleSystem.Pause();

        float sig = Mathf.Sin(Time.frameCount * 0.01f);
        for (int i = 0; i < num; i++)
        {
            float x = -50 + i * 0.1f;
            float prob = NormalPDF(x, 1.0f, sig * 45) * 60;
            particle[i].position = new Vector3(x, 0, prob);
        }

        particleSystem.SetParticles(particle, num);
    }
    float NormalPDF(float x, float sigma, float mu)
    {
        return (1.0f / Mathf.Sqrt(2.0f * Mathf.PI * sigma * sigma) * Mathf.Exp(-((x - mu) * (x - mu)) / (2 * sigma * sigma)));
    }
}
