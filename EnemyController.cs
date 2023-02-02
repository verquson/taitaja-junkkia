using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    int currentHealth;
    public EnemyData data;
    AudioSource AS;

    // Start is called before the first frame update
    void Start()
    {
       
       currentHealth = data.MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        AudioManager.Instance.PlayClipOnce(data.OnTakeDamageSE,this.gameObject);

        if (currentHealth <= 0)
        {
            AudioManager.Instance.PlayClipOnce(data.OnDeathSE, this.gameObject);
            Destroy(this.gameObject);
        }
    }
}
