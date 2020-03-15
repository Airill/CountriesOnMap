using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListOfCountriesController : MonoBehaviour
{

    public GameObject countryInList;
    public GameObject content;
    List<GameObject> cells;

    public void PlaceToList() {
        var copy = Instantiate(countryInList);
        copy.transform.parent = content.transform;
        copy.transform.localPosition = Vector3.zero;
    }

    public void SetList(List<CountryOnMap> selectedCountries) {

    }
}
