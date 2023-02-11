using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject telaConfig;

    public void ToggleConfig()
    {
        if (telaConfig.activeInHierarchy)
            telaConfig.SetActive(false);
        else
            telaConfig.SetActive(true);
    }
}
