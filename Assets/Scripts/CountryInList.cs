using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountryInList : MonoBehaviour
{
    public Text countryName;
    public Text area;
    public Text population;
    public Text vvp;

    public void SetCountryInList(CountryOnMap c) {
        countryName.text = c.name;
        area.text = c.area.ToString();
        population.text = c.population.ToString();
        vvp.text = c.vvp.ToString();
    }

}
