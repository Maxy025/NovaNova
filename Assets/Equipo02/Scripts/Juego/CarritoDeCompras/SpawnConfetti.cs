using UnityEngine;
using Assets.Scripts.Juego.Lista;
using Assets.Scripts.Juego.Canasta;

public class SpawnConfetti : MonoBehaviour
{
    public ParticleSystem confetti;

    public void ActivarConfetti()
    {
        confetti.Play();
    }
}

