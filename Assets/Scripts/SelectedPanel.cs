using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectedPanel : MonoBehaviour
{
    public Text TitleText;
    private GameObject panel;

    public void Start() {
        panel = transform.GetChild(0).gameObject;
    }

    public void SetSelectedCount(int count) {
        TitleText.text = "Выбрано " + count + " стран";
    }

    public void ActivatePanel() {
        panel.SetActive(true);
    }

    public void DisactivatePanel() {
        panel.SetActive(false);
    }

}