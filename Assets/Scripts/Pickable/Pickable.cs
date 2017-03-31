﻿using UnityEngine;

public class Pickable : MonoBehaviour
{
    public bool IsPickedUp;
    public bool CanBePicked = true;

    public void PickUp()
    {
        IsPickedUp = true;
    }

    virtual public void PutDown()
    {
        IsPickedUp = false;
    }
}