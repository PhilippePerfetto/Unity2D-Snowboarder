using UnityEngine;

public class DustTrail : MonoBehaviour
{
    [SerializeField] public ParticleSystem snowParticles;
    [SerializeField] public AudioSource snowSound;

    private void Start() {
        snowSound = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D other) {
        snowParticles.Play();
        snowSound.Play(5000);

    }

    private void OnCollisionExit2D(Collision2D other) {
        snowParticles.Stop();
        snowSound.Stop();
    }
}
