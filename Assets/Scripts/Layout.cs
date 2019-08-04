using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Layout : MonoBehaviour
{
    public void UpdateText(int value) {
        GetComponent<Text>().text = value.ToString();
    }
}
