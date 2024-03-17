using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] Player player;
    //[SerializeField] Enemy enemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayerLoseHealth(float loss)
    {
        player.LoseHealth(loss);
    }

    public void PlayerGainHealth(float gain)
    {
        player.GainHealth(gain);
    }

    public void EnemyLoseHealth(float loss)
    {

    }

    //public void ChangeMaxHealth(float )
}
