using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour, ITouchable
{
    [SerializeField] List<LootTableConfig> _lootTable;

    private void Start()
    {
        if (_lootTable.Count == 0)
            _lootTable = new List<LootTableConfig>();
    }
    public void Touch(int power)
    {
        var randomItem = Random.Range(0, _lootTable.Count - 1);
        var chance = Random.Range(0, _lootTable[randomItem].dropRate);

        if (chance == 0)
        {
            Instantiate(_lootTable[randomItem].item, transform.position, Quaternion.identity, null);
        }

        Destroy(gameObject);
    }
}
