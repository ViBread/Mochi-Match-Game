using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsOpener : MonoBehaviour
{
    public GameObject Options;

    public void OpenOptions()
    {
        if (Options != null)
        {
            bool isActive = Options.activeSelf;

            Options.SetActive(!isActive);
        }
    }
}
