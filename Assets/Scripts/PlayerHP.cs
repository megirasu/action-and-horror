using UnityEngine;
using UnityEngine.UI;
using StarterAssets;

public class PlayerHP : MonoBehaviour
{
    [SerializeField] private int maxHP = 3;
    [SerializeField] private Slider hpBar;
    [SerializeField] private GameObject gameoverCanvas;
    [SerializeField] private GameObject playerArmature;
    private int currentHP;
    private bool isDead = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHP = maxHP;
        if(hpBar != null)
        {
            hpBar.maxValue = maxHP;
            hpBar.value = currentHP;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(int damage)
    {
        if(isDead == true)return;
        currentHP -= damage;
        if(hpBar != null)
        {
            hpBar.value = currentHP;
        }

        if(currentHP <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        isDead = true;
        if(gameoverCanvas != null)
        {
            gameoverCanvas.SetActive(true);
        }
        if(playerArmature != null)
        {
            playerArmature.GetComponent<CharacterController>().enabled = false;
            playerArmature.GetComponent<StarterAssets.ThirdPersonController>().enabled = false;
        }
    }
}
