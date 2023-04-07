using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : Collectable
{
    //записываем в ручную название объекта. По этой переменной будут вызываться нужные методы
    public string objectName;
    public GameObject item;//сам предмет. Для саписи в инвентарь
    
    

    protected override void OnCollectpl()
    {
        switch (objectName)
        {
            case "door":

                break;

            case "takingitem":
                TakeItem(item);
                break;
            
            case " ":

                break;

            default:
                break;
        }
    }

    protected void TakeItem(GameObject item)
    {
        Debug.Log("подбирается");
        Destroy(gameObject);
    }

}
