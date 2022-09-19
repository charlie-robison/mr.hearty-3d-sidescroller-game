using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UILabels : MonoBehaviour
{
    public TMP_Text coinsLabel;

    public void updateCoinsLabel(int coinsAmount)
    {
        print("HEY");
        coinsLabel.text = coinsAmount + " Coins";
    }
}
