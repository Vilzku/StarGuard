using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private int maxHealth;
    [SerializeField] private int deathScore;

    [SerializeField] AudioClip explosionSound;

    private int currentHealth;

    private AudioSource audioSource;
    private bool isDead = false;
    [SerializeField] private Slider healthSlider;

    void Start()
    {
        if (healthSlider)
        {
            healthSlider.maxValue = maxHealth;
            healthSlider.value = maxHealth;
        }

        currentHealth = maxHealth;
        audioSource = GetComponent<AudioSource>();
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (healthSlider) healthSlider.value = currentHealth;

        if (currentHealth <= 0 && !isDead)
        {
            isDead = true;
            audioSource.PlayOneShot(explosionSound);
            animator.SetBool("IsDead", true);
            StartCoroutine(nameof(DestroyAfterDelay));
            int currentScore = PlayerPrefs.GetInt("currentScore", 0);
            PlayerPrefs.SetInt("currentScore", currentScore + deathScore);
        }
    }

    private IEnumerator DestroyAfterDelay()
    {
        yield return new WaitForSeconds(0.6f);
        Destroy(gameObject);
    }

    public bool IsObjectDead()
    {
        return isDead;
    }
}
