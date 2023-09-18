using Unity.VisualScripting;
using UnityEngine;

public class Effects : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem crashEffect;

    [SerializeField]
    private AudioSource carAudioSource;

    [SerializeField]
    private AudioClip crashClip;

    [SerializeField]
    private AudioSource AudioEffectSource;

    [SerializeField]
    private float nitroEnginePitch;

    [SerializeField]
    private AudioClip fuelGatherClip;


    [SerializeField]
    private AudioClip SqueakySound;

    private float normalEnginePitch;
    private bool hasPlayedDeathAnimation = false;
    private bool hasPlayedCrashSound = false;

    public void Awake()
    {
        normalEnginePitch = carAudioSource.pitch;
    }

    public void GatherFuel(int value)
    {
        if (value > 0)
        {
            AudioEffectSource.PlayOneShot(fuelGatherClip);
        }
    }

    public void ObstacleHit(int value)
    {
        if (Player.IsAlive && value < 0)
        {
            AudioEffectSource.PlayOneShot(SqueakySound);
        }
       
    }

    private void DeathAnimation()
    {
        if (!hasPlayedDeathAnimation)
        {
            var explosion = Instantiate(crashEffect, transform.position, Quaternion.identity);
            explosion.Play();
            hasPlayedDeathAnimation = true;
        }
    }

    private void DeathSoundEffect()
    {
        if (!hasPlayedCrashSound)
        {
            carAudioSource.PlayOneShot(crashClip);
            hasPlayedCrashSound = true;
        }
    }

    private void LateUpdate()
    {
        if (!Player.IsAlive)
        {
            DeathAnimation();
            DeathSoundEffect();
        }
    }

    private void ObstacleHit()
    {
        carAudioSource.PlayOneShot(SqueakySound);
    }
}
