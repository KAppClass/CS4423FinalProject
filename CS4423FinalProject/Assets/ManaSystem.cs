using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaSystem : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] PlayerSO playerSO;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReduceMana(float reduce)
    {

        player.ReduceMana(reduce);

    }

}
