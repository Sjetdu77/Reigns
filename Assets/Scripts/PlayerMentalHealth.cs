using UnityEngine;
using System.Collections;

public class PlayerMentalHealth : MonoBehaviour
{
    public int maxMentalHealth = 1000;
    public int currentMentalHealth;
    public int creaturesDied = 0;

    public MentalHealthBar mentalHealthBar;
    public Animator fadeSystem;

    public static PlayerMentalHealth instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("There is already an instance of PlayerMentalHealth.");
            return;
        }

        instance = this;
    }

    void Start()
    {
        currentMentalHealth = maxMentalHealth;
        mentalHealthBar.SetMaxHealth(maxMentalHealth);
    }

    void FixedUpdate()
    {
        int damage = (int)(PlayerMovement.instance.rigidbodyPlayer.velocity.magnitude * creaturesDied);
        if (damage > 0)
        {
            TakeDamage(damage);
        }

        mentalHealthBar.SetHealth(currentMentalHealth);
    }

    public void SetMaxHealth() => currentMentalHealth = mentalHealthBar.GetMaxHealth();

    public void SetMaxHealth(int maxMentalHealth)
    {
        currentMentalHealth = maxMentalHealth;
        mentalHealthBar.SetMaxHealth(maxMentalHealth);
    }

    public void TakeDamage(int damage)
    {
        currentMentalHealth -= damage;
        if (currentMentalHealth < 0) currentMentalHealth = 0;
        if (currentMentalHealth <= 0) StartCoroutine(Die());
    }

    IEnumerator Die()
    {
        fadeSystem.SetTrigger("FadeIn");

        var playerMovement = PlayerMovement.instance;
        playerMovement.MovePlayer(0, 0);
        playerMovement.enabled = false;
        playerMovement.animator.SetTrigger("Die");
        playerMovement.rigidbodyPlayer.bodyType = RigidbodyType2D.Kinematic;
        playerMovement.boxColliderPlayer.enabled = false;
        yield return new WaitForSeconds(3f);
        GameOverManager.instance.OnPlayerDeath();
    }

    public void Respawn()
    {
        fadeSystem.SetTrigger("FadeOut");
        SetMaxHealth();
        creaturesDied = 0;
        var playerMovement = PlayerMovement.instance;
        playerMovement.animator.SetTrigger("Restart");
        playerMovement.enabled = true;
        playerMovement.rigidbodyPlayer.bodyType = RigidbodyType2D.Dynamic;
        playerMovement.boxColliderPlayer.enabled = true;
        GameObject.FindGameObjectWithTag("Player").transform.position = CurrentSceneManager.instance.respawnPoint;
    }
}
