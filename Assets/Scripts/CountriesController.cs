using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountriesController : MonoBehaviour
{
    public UIController uIController;
    public List<CountryOnMap> countries;
    private GameObject lastChosenAttaction;
    private GameObject lastChosenMarker;
    private List<CountryOnMap> selectedCountries = new List<CountryOnMap>();
    [HideInInspector]
    public bool isSelecting;


    public CountryOnMap GetCountry(GameObject mark) {
        foreach (CountryOnMap c in countries) {
            if(c.marker == mark) {
                return c;
             }
        }
        return null;
    }

    public void ActivateCountry(CountryOnMap clickedCountry) {
        SetLastCountry();
        HideMarker(clickedCountry);   
        ShowCountryAttraction(clickedCountry);
        uIController.infoPanel.ActivatePanel();
        uIController.infoPanel.SetInfo(clickedCountry);
    }

    public void ShowCountryAttraction(CountryOnMap aCountry) { //использовать для селекта?
                lastChosenAttaction = aCountry.attraction;
                lastChosenAttaction.SetActive(true);
    }

    public void SetLastCountry() {
        if ( lastChosenAttaction != null && lastChosenMarker != null) {
            lastChosenAttaction.SetActive(false);
            lastChosenMarker.SetActive(true);
        }
    }

    public void HideMarker(CountryOnMap co) {
        lastChosenMarker = co.marker;
        lastChosenMarker.SetActive(false);
    }

    public void ChangeSelectingStatus(bool status) {
        isSelecting = status;
    }

    public void SetCountriesToDefault() {
        foreach (CountryOnMap c in countries) {
            c.marker.SetActive(true);
            c.check.SetActive(false);
            c.attraction.SetActive(false);
        }
    }

    public void SelectCountry(CountryOnMap sCountry) {
        if (isSelecting == false) {
            SetLastCountry();
        }
        ChangeSelectingStatus(true);
        sCountry.attraction.SetActive(true);
        HideMarker(sCountry);
        uIController.SetActiveButtons(true);
        sCountry.check.SetActive(true);
        if (!selectedCountries.Exists(x => x == sCountry)) {
            selectedCountries.Add(sCountry);
        }
        uIController.infoPanel.DisactivatePanel();
        uIController.selectedPanel.ActivatePanel();
        uIController.selectedPanel.SetSelectedCount(selectedCountries.Count);
    }

    public void EndSelection() {
        selectedCountries.Clear();
        ChangeSelectingStatus(false);
        uIController.SetActiveButtons(false);
        uIController.selectedPanel.DisactivatePanel();
        SetCountriesToDefault();
    } 

    public void ShowSelectedCountries() {
        uIController.SetList(selectedCountries);
    }

    public void SortByArea() {
        selectedCountries.Sort((x, y) => x.area.CompareTo(y.area));
    }

    public void ReversSelectedCountries() {
        selectedCountries.Reverse();
    }

    public void SortByPop() {
        selectedCountries.Sort((x, y) => x.population.CompareTo(y.population));
    }

    public void SortByVVP() {
        selectedCountries.Sort((x, y) => x.vvp.CompareTo(y.vvp));
    }
}
