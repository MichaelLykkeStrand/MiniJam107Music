using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlacementController : MonoBehaviour
{
    public static PlacementController Instance;
    private TowerContainer towerContainer;
    private GameObject placeHolder;
    public static Grid<GameObject> grid;
    public const int CELL_SIZE = 1;
    //private Store store;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        grid = new Grid<GameObject>(4, 6, CELL_SIZE, new Vector3(0 - 0.5f, 0 - 0.5f), (Grid<GameObject> g, int x, int y) => null);
    }
    public void OnButtonClick()
    {
        if (placeHolder != null) return;
        this.towerContainer = EventSystem.current.currentSelectedGameObject.GetComponent<TowerContainer>();
        placeHolder = Instantiate(towerContainer.placeHolderObject);
    }

    public void Update()
    {
        MovePlaceHolder();
        PlaceTowerOnPlaceHolder();
        DestroyPlaceHolder();
    }

    private void PlaceTowerOnPlaceHolder()
    {
        Vector2 snappedPlacementPosition = grid.SnapToGridLocation((Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition));
        if (Input.GetMouseButtonDown(0))
        {
            //towerPrice = towerContainer.towerObject.GetComponent<Tower>().price;
            try
            {
                if (grid.GetGridObject(snappedPlacementPosition) != null) return;
                GameObject tower = Instantiate(towerContainer.towerObject);
                tower.transform.position = snappedPlacementPosition;
                grid.SetGridObject(snappedPlacementPosition, tower);
                Deselect();
            }
            catch (IllegalGridPlacmentException)
            {

            }
        }
    }

    private void MovePlaceHolder()
    {
        if (towerContainer != null)
        {
            placeHolder.transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }

    private void DestroyPlaceHolder()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Deselect();
        }
    }

    private void Deselect()
    {
        towerContainer = null;
        Destroy(placeHolder);
    }
}
