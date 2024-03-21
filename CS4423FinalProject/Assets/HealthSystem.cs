using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] Player player;
<<<<<<< HEAD
=======
    [SerializeField] PlayerSO playerSO;
    [SerializeField] FirstEnemy first;
>>>>>>> cbdd3774196778a2269ac7002ec2b3ef650bc132
    //[SerializeField] Enemy enemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

<<<<<<< HEAD
=======

    public void FirstEnemyNegativeHealth(float loss, float multiplier, float time)
    {
        first.LoseHealth(loss);
        first.TempChangeMultiplier(multiplier, time);
    }

>>>>>>> cbdd3774196778a2269ac7002ec2b3ef650bc132
    public void PlayerLoseHealth(float loss)
    {
        player.LoseHealth(loss);
    }

    public void PlayerGainHealth(float gain)
    {
        player.GainHealth(gain);
    }

<<<<<<< HEAD
    public void EnemyLoseHealth(float loss)
    {

    }

=======
    public void PlayerChangeMaxHealth(float max)
    {
       // first.LoseHealth(loss);
        //first.TempChangeMultiplier();
    }

    

>>>>>>> cbdd3774196778a2269ac7002ec2b3ef650bc132
    //public void ChangeMaxHealth(float )
}
