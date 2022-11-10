using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CellHelper
{
    public static void ChangeColor<T>(List<T> list, Color color) where T : Component
    {
        foreach (T element in list)
        {
            element.GetComponent<MeshRenderer>().material.color = color;
        }

        //for (int i = 0; i < list.Count; i++)
        //{
        //    list[i].gameObject.GetComponent<MeshRenderer>().material.color = color;
        //}
    }

    public static void ChangeMaterial<T>(List<T> list, Material material) where T : MeshRenderer
    {
        foreach (T element in list)
        {
            element.GetComponent<MeshRenderer>().material = material;
        }
    }
}
