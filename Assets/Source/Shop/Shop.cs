using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private List<GameObject> towerObjects;

    // Update is called once per frame
    void Update()
    {

    }

    public GameObject Buy(string name, CurrencyContainer currencyContainer)
    {
        foreach (var towerObject in towerObjects)
        {
            Tower tower = towerObject.GetComponent<Tower>();
            if (tower.name.Equals(name))
            {
                if (currencyContainer.GetValue() >= tower.price)
                {
                    currencyContainer.Subtract(tower.price);
                    return towerObject;
                }
                throw new InsufficientFundsException();
            }
        }
        throw new NoMatchException("Unable to find a macthing tower for the name: "+name);
    }

    public Tower Get(string name)
    {
        foreach (var towerObject in towerObjects)
        {
            Tower tower = towerObject.GetComponent<Tower>();
            if (tower.name.Equals(name))
            {
                return tower;
            }
        }
        throw new NoMatchException("Unable to find a macthing tower for that name!");
    }
}

public class NoMatchException : Exception
{
    public NoMatchException(string message) : base(message)
    {
    }
}

public class InsufficientFundsException : Exception
{

}
