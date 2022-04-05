using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class LootTableConfig
{
    public Item item;
    [Range(0,4)] public int dropRate;
}
