using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : Collectable
{
    //���������� � ������ �������� �������. �� ���� ���������� ����� ���������� ������ ������
    public string objectName;
    public GameObject item;//��� �������. ��� ������ � ���������
    
    

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
        Debug.Log("�����������");
        Destroy(gameObject);
    }

}
