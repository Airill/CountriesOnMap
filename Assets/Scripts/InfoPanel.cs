using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoPanel : MonoBehaviour
{
    public Text AreaText;
    public Text PopulationText;
    public Text VvpText;
    private GameObject panel;

    public void Start() {
        panel = transform.GetChild(0).gameObject;
    }

    public void SetInfo(CountryOnMap country) {
        AreaText.text = "Площадь: " +country.area.ToString() + " км^2";
        PopulationText.text = "Население: " + country.population.ToString() + " чел.";
        VvpText.text = "ВВП: " + country.vvp.ToString() + " трлн. долл.";
    }

    public void ActivatePanel() {
        panel.SetActive(true);
    }

    public void DisactivatePanel() {      
        panel.SetActive(false);
    }

}
