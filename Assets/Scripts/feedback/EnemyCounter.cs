using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCounter : MonoBehaviour
{
    public FloatValue deadEnemies;
    public string text;
    public TextMeshProUGUI myText;
    void Start()
    {
        InitText();
    }

    public void InitText()
    {
        myText.text = "0";
    }
    public void UpdateText()
    {
        deadEnemies.RuntimeValue += 1;
        myText.text = deadEnemies.RuntimeValue.ToString();

    }
}
