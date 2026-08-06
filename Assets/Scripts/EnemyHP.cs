using UnityEngine;
using UnityEngine.UI;

public class EnemyHP : MonoBehaviour
{
    [SerializeField] private int maxHP = 10;
    [SerializeField]private lightsphere sphere;
    [SerializeField]private Slider hpBar;
    private int currentHP;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHP = maxHP;
        if(hpBar !=null)
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
        currentHP -= damage;

        if(hpBar != null)
        {
            hpBar.maxValue = maxHP;
            hpBar.value = currentHP;//hpを更新
        }
        if(currentHP <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        
        if(sphere != null)
        {
            sphere.Release();//sphereの動き再開
        
        }
        Destroy(gameObject);
    }

    }
