using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] PlayerSO playerSO;
    [SerializeField] Enemy first;
    [SerializeField] EnemySO enemySO;
    //[SerializeField] Enemy enemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void FirstEnemyNegativeHealth(float loss, float multiplier, float time)
    {
        first.TempChangeMultiplier(multiplier, time);
        first.LoseHealth(loss);
        
    }

    public void PlayerLoseHealth(float loss, float multiplier, float time)
    {
        player.TempChangeMultiplier(multiplier, time);
        player.LoseHealth(loss);
    }

    public void PlayerGainHealth(float gain)
    {
        player.GainHealth(gain);
    }

    public void PlayerChangeMaxHealth(float max)
    {
       // first.LoseHealth(loss);
        //first.TempChangeMultiplier();
    }

    

    //public void ChangeMaxHealth(float )
}
