using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BulletPool : MonoBehaviour, IPool<Bullet>
{
    [SerializeField] Bullet bulletModel;
    [SerializeField] private List<Bullet> bullets;
    [SerializeField] int capacity;
    // Start is called before the first frame update

    private void Awake()
    {

    }
    void Start()
    {
        List<Bullet> bullets = new List<Bullet>(capacity);

        var pool = this as IPool<Bullet>;
        pool.InstantiatePool();
    }

    Bullet IPool<Bullet>.GetPooledObject()
    {
        foreach(Bullet bullet in bullets)
        {
            if (!bullet) continue;
            if (!bullet.gameObject.activeInHierarchy)
                return bullet;
        }
        return null;
    }

    void IPool<Bullet>.InstantiatePool()
    {
        for (int i=0; i<capacity; i++)
        {
            var bullet = Instantiate(bulletModel);
            bullets.Add(bullet);
            bullet.transform.parent = gameObject.transform;
            bullet.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
