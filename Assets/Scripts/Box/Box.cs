﻿using System.Collections.Generic;
using UnityEngine;

public class Box : Pickable {

    public Sprite carryingBox;
    public Sprite closedBox;
    public int MaximumIngredients = 4;
    public List<Ingredient> Ingredients;
    public List<Transform> SpawnPoints;
    private bool _isClosed;

    private void Start()
    {
        CanBePicked = false;
    }

    public void AddIngredient(Ingredient ingredient)
    {
        if (_isClosed)
        {
            return;
        }

        ingredient.transform.parent = gameObject.transform;
        ingredient.transform.position = SpawnPoints[Ingredients.Count].transform.position;
        Ingredients.Add(ingredient);
        ingredient.CanBePicked = false;


        var decorators = ingredient.GetComponents<ProximityDecorator>();
        foreach (var dec in decorators)
        {
            Destroy(dec);
        }
        var ingredientColliders = ingredient.GetComponents<Collider2D>();
        foreach (var col in ingredientColliders)
        {
            Destroy(col);
        }

        if (Ingredients.Count == MaximumIngredients)
        {
            CloseBox();
        }

    }

    public override void PickUp()
    {
        base.PickUp();
        GetComponent<SpriteRenderer>().sprite = carryingBox;
        GetComponent<SpriteRenderer>().sortingOrder = 4;
    }

    public override void PutDown()
    {
        base.PutDown();
        GetComponent<SpriteRenderer>().sprite = closedBox;
        GetComponent<SpriteRenderer>().sortingOrder = 1;
    }

    public void CloseBox()
    {
        _isClosed = true;
        CanBePicked = true;
        GetComponent<SpriteRenderer>().sprite = closedBox;
        foreach (var i in Ingredients)
        {
            i.GetComponent<SpriteRenderer>().enabled = false;
        }
        Destroy(transform.GetChild(0).GetComponent<Collider2D>());
    }
}
