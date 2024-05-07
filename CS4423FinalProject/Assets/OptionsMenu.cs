using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    [SerializeField] Canvas canvas;
    [SerializeField] Toggle toggle;
    [SerializeField] EnemySO enemySO;
    
    public void OpenOptions()
    {
        canvas.enabled = true;
    }

    public void CloseOptions()
    {
        canvas.enabled = false;
    }

    public void HardMode()
    {
        if (toggle.isOn)
            enemySO.hard = true;
        else
            enemySO.hard = false;
    }
}
