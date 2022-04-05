using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBrain : MonoBehaviour
{
    [SerializeField] EntityFire _fire;

    [SerializeField] PlayerEntity _playerTarget;
    [SerializeField] float _detectionRadius = 10f;

    [SerializeField] bool _drawGizmo;

    IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1f, 3f));

            if(Vector3.Distance(_playerTarget.transform.position, transform.position) < _detectionRadius) 
                _fire.FireBullet(2);
        }
    }

    private void OnDrawGizmos()
    {
        if (!_drawGizmo) return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _detectionRadius);
    }


}


