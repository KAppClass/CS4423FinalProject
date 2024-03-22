using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaManager : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] FirstEnemy first;
    //[SerializeField] PlayerSO playerSO;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReduceMana(float reduce, int type)
    {

        
        switch (type)
        {
            case 0:
                    player.ReduceMana(reduce);
                    break;
            case 1:
                    first.ReduceMana(reduce);
                    break;
            default:
                Debug.Log("Mana Choosing went wrong");
                break;
        }

        // if ( type == 0)
        //     player.ReduceMana(reduce);
        

    }

}
