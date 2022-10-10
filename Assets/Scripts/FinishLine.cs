using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] public float loadDelay = 1.5f;
    [SerializeField] public ParticleSystem finishEffect;

    void OnTriggerEnter2D(Collider2D other) {
        
        if (other.tag == "Player")
        {
            Debug.Log("finish : " + SceneManager.GetActiveScene().name);
            
            FindObjectOfType<PlayerController>().DisableControls();

            if (finishEffect != null)
                finishEffect.Play();

            var audio = GetComponent<AudioSource>();
            if (audio != null) 
                audio.Play();

            Invoke("ReloadScene", loadDelay);
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

