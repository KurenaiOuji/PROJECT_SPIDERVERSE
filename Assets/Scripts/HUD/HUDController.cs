using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    public static HUDController instance;

    [SerializeField] TMP_Text InteractionText;

    private void Awake()
    {
        instance = this;
    }

    public void EnableInteractionText(string text)
    {
        InteractionText.text = text + (" [F]");
        InteractionText.enabled = true;
    }

    public void DisableInteractionText()
    {
        InteractionText.enabled = false;
    }
}
