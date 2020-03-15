using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickDetector : MonoBehaviour
{
    public CountriesController countriesController;

    public float holdTimeLimit = 1f;
    float pressTime;
    bool isPressed = false;



    // Update is called once per frame
    void Update() {

        if (isPressed) {
            pressTime += Time.deltaTime;
        }

        if (Input.GetMouseButtonDown(0)) {
            //prevent click through UI
            if (EventSystem.current.IsPointerOverGameObject())
                return;

            isPressed = true;
        }

        if (Input.GetMouseButtonUp(0)) {
            if (isPressed) {
                OnClick();
            }
            isPressed = false;
            pressTime = 0f;
        }

        if (pressTime >= holdTimeLimit) {
            isPressed = false;
            OnHold();
        }
    }

    public void OnClick() {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo)) {
            CountryOnMap chosenCountry = hitInfo.transform.GetComponentInParent<CountriesController>().GetCountry(hitInfo.collider.gameObject);
            if (countriesController.isSelecting == false) {
                countriesController.ActivateCountry(chosenCountry);
            } else { countriesController.SelectCountry(chosenCountry); }

            
        }
    }

    public void OnHold() {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo)) {
            CountryOnMap chosenCountry = hitInfo.transform.GetComponentInParent<CountriesController>().GetCountry(hitInfo.collider.gameObject);
           /// countriesController.ChangeSelectingStatus(true);
            countriesController.SelectCountry(chosenCountry);
        }
    }
}