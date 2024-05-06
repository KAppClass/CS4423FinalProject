using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] PlayerSO playerSO;
    [SerializeField] Enemy first;
    [SerializeField] EnemySO enemySO;
    bool giveMult = true;
    bool giveSpeed = true;
    

    public void EnemyNegativeHealth(float loss, float multiplier, float speed)
    {
        if (giveMult && multiplier > 0)
        {
            first.ChangeMultiplier(multiplier);
            giveMult = false;
        }
        if (giveSpeed && speed > 0)
        {
            first.ChangeSpeed(speed);
            giveSpeed = false;
        }
        first.LoseHealth(loss);
        
    }

    public void PlayerLoseHealth(float loss)
    {
        if (playerSO.shield != 0)
        {
            player.ReduceShield(loss);
        }
        else
        {
            player.LoseHealth(loss);
        }
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
