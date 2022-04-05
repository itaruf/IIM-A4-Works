using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TransformExtension		// Class static !
{

    public static void DestroyAllChildren(this Transform ctx)	// Méthode static, et “this” pour _											indiquer que l’on étend le type Transform
    {
        foreach (Transform el in ctx)
        {
            GameObject.Destroy(el.gameObject);
        }
    }

}
