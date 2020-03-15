using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public InfoPanel infoPanel;
    public SelectedPanel selectedPanel;
    public Button ShowListbutton;
    public Button ClearListButton;
    public GameObject listOfCountriesPanel;

    public GameObject countryInList;
    public GameObject content;
    List<GameObject> cells = new List<GameObject>();
    CountriesController countriesController;

    public Button areaSortButton;
    public Button popSortButton;
    public Button vvpSortButton;

    bool areaSortAscending = true;
    bool popSortAscending = true;
    bool vvpSortAscending = true;

    private void Start() {
        countriesController =  GameObject.FindGameObjectWithTag("GameController").GetComponent<CountriesController>();
    }

    
    public void SetActiveButtons(bool st) {
        ShowListbutton.gameObject.SetActive(st);
        ClearListButton.gameObject.SetActive(st);
    }

    public void SetList(List<CountryOnMap> selectedCountries) {
        foreach (GameObject c in cells) {
            Destroy(c);
        }
        cells.Clear();
        listOfCountriesPanel.SetActive(true);
        foreach (CountryOnMap sc in selectedCountries) {
            var copy = Instantiate(countryInList);
            cells.Add(copy);
            copy.GetComponent<CountryInList>().SetCountryInList(sc);
            copy.transform.parent = content.transform;
            copy.transform.localPosition = Vector3.zero;
        }
    }

    public void BackButton() {
        listOfCountriesPanel.SetActive(false);
    }

    public void OnAreaSortButtonClick() {
        countriesController.SortByArea();

        if (areaSortAscending) {
            areaSortButton.GetComponentInChildren<Text>().text = "По площади (убыв.)";
        } else {
            countriesController.ReversSelectedCountries();
            areaSortButton.GetComponentInChildren<Text>().text = "По площади (возраст.)";
        }
        areaSortAscending = !areaSortAscending;
        countriesController.ShowSelectedCountries();
    }

    public void OnPopSortButtonClick() {
        countriesController.SortByPop();

        if (popSortAscending) {
            popSortButton.GetComponentInChildren<Text>().text = "По населению (убыв.)";
        }
        else {
            countriesController.ReversSelectedCountries();
            popSortButton.GetComponentInChildren<Text>().text = "По населению (возраст.)";
        }
        popSortAscending = !popSortAscending;
        countriesController.ShowSelectedCountries();
    }

    public void OnVvpSortButtonClick() {
        countriesController.SortByVVP();

        if (vvpSortAscending) {
            vvpSortButton.GetComponentInChildren<Text>().text = "По ВВП (убыв.)";
        }
        else {
            countriesController.ReversSelectedCountries();
            vvpSortButton.GetComponentInChildren<Text>().text = "По ВВП (возраст.)";
        }
        vvpSortAscending = !vvpSortAscending;
        countriesController.ShowSelectedCountries();
    }


}
