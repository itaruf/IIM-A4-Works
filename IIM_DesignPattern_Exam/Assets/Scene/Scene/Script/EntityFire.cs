using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityFire : MonoBehaviour
{
    [SerializeField] Transform _spawnPoint;
    [SerializeField] Bullet _bulletPrefab;
    [SerializeField] BulletPoolReference _bulletPoolReference;

    public void FireBullet(int power)
    {
        /*var b = Instantiate(_bulletPrefab, _spawnPoint.transform.position, Quaternion.identity, null)
            .Init(_spawnPoint.TransformDirection(Vector3.right), power);*/

        var pool = _bulletPoolReference.Instance as IPool<Bullet>;
        var bullet = pool.GetPooledObject();

        if (bullet != null)
        {
            bullet.gameObject.SetActive(true);
            bullet.transform.position = _spawnPoint.transform.position;
            bullet.transform.rotation = Quaternion.identity;
            bullet.Init(_spawnPoint.TransformDirection(Vector3.right), power);
        }

        else
        {
            var b = Instantiate(_bulletPrefab, _spawnPoint.transform.position, Quaternion.identity, null)
            .Init(_spawnPoint.TransformDirection(Vector3.right), power);
        }
    }

}
