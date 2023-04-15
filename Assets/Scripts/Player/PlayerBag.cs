using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBag : MonoBehaviour
{
    public List<Product> products = new List<Product>();
    private Vector3 lastPosition;
    public int size = 4;
    public int count = 0;

    public bool isFull = false;

    private void Start() 
    {
        lastPosition = Vector3.zero;
        size = 4;
    }

    public void AddProduct(Product newProduct)
    {
        if (newProduct == null) return;
        if (products.Contains(newProduct)) return;
        if (products.Count < size)
        {
            products.Add(newProduct);
            ArrangePosition(newProduct);
            count++;
            isFull = count>= size ? true : false;
        }
    }

    private void ArrangePosition(Product p)
    {
        p.transform.SetParent(this.transform,true);
        p.transform.localPosition = lastPosition;
        lastPosition = new Vector3 (0,lastPosition.y + p.Height,0);
    }

    public void RemoveProduct(Product productToGo)
    {
        products.Remove(productToGo);
        count--;
        isFull = count>= size ? true : false;
        ReArrangeProducts();
    }

    private void ReArrangeProducts()
    {
        lastPosition = Vector3.zero;

        foreach (Product p in products)
        {
            ArrangePosition(p);
        }
    }
}
