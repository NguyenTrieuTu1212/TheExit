using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTrap : MonoBehaviour
{
    [SerializeField] GameObject particalSystems;
    [SerializeField] List<ParticleSystem> listParticleSystems;
    [SerializeField] List<GameObject> listGameObjectTrap;
    [SerializeField] public float timeCounter;

    [Range(1f,20f)] public float maxParticleDuration;
    [Range(1f, 10f)] public float resetTime ;
  

    private enum TrapState { Inactive, Active, Resetting }
    private TrapState currentState = TrapState.Inactive;
    private float activeTimer = 0f;

    public Collider2D colliderDetecton;

    private void Awake()
    {
        LoadParticalSystem();
    }
    private void Update()
    {
        switch (currentState)
        {
            case TrapState.Inactive:
                timeCounter += Time.deltaTime;
                if (timeCounter >= 0)
                {
                    currentState = TrapState.Active;
                    activeTimer = 0f;
                    ActivateAllParticleSystems();
                }
                break;

            case TrapState.Active:
                colliderDetecton.enabled = true;
                activeTimer += Time.deltaTime;
                if (activeTimer >= maxParticleDuration)
                {
                    currentState = TrapState.Resetting;
                    DisableAllParticleSystems();
                }
                break;

            case TrapState.Resetting:
                colliderDetecton.enabled = false;
                timeCounter += Time.deltaTime;
                if (timeCounter >= resetTime)
                {
                    currentState = TrapState.Inactive;
                    timeCounter = 0f;
                }
                break;
        }
    }

    private void LoadParticalSystem()
    {
        for (int i = 0; i < particalSystems.transform.childCount; i++)
        {
            listParticleSystems.Add(particalSystems.transform.GetChild(i).GetComponent<ParticleSystem>());
        }
    }

    private void ActivateAllParticleSystems()
    {
        
        foreach (ParticleSystem ps in listParticleSystems)
        {
            ps.Play();
        }
        colliderDetecton.enabled = true;
    }

    private void DisableAllParticleSystems()
    {
        colliderDetecton.enabled = false;
        foreach (ParticleSystem ps in listParticleSystems)
        {
            ps.Stop();
        } 
    }
}
