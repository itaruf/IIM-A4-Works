using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EntityAutoTargeting : MonoBehaviour
{
    [SerializeField] EntityRotation _rotation;
    [SerializeField] PhysicEvent2D _radius;
    [SerializeField] PlayerEntity _player;

    public List<Enemy> _enemiesInRadius;

    Coroutine AimingRoutine { get; set; }

    private void Start()
    {
        _enemiesInRadius = new List<Enemy>();
        _radius.TriggerEnter2D += _radius_TriggerEnter2D;
        _radius.TriggerExit2D += _radius_TriggerExit2D;

        AimingRoutine = StartCoroutine(Aiming());
    }

    IEnumerator Aiming()
    {
        while(true)
        {
            yield return new WaitForSeconds(0.1f);

            if (_enemiesInRadius.Count <= 0) continue;

            var nearestEnemy = _enemiesInRadius
                .Select(character => (character, Vector3.Distance(_player.transform.position, character.transform.position)))
                .Aggregate((a, b) => a.Item2 < b.Item2 ? a : b)
                .character;

            _rotation.AimPosition = nearestEnemy?.transform.position ?? _rotation.AimPosition;
        }

        yield break;
    }


    private void _radius_TriggerEnter2D(Collider2D arg0)
    {
        if(arg0.TryGetComponent(out Enemy e))
        {
            _enemiesInRadius.Add(e);
        }
    }

    private void _radius_TriggerExit2D(Collider2D arg0)
    {
        if (arg0.TryGetComponent(out Enemy e))
        {
            _enemiesInRadius.Remove(e);
        }
    }
}
