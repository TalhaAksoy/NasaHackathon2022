using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Computer : MonoBehaviour, IInteractable
{

    [SerializeField] private string _promt;
    string IInteractable.InteractionPromt => _promt;

    bool IInteractable.Interact(Interactor interactor)
    {
        Debug.Log(message: "hi");
        return true;

    }
}
