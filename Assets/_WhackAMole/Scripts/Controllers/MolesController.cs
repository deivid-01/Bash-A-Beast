using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MolesController : MonoBehaviour
{
    [SerializeField] private MoleController[] moles;

    private Coroutine _coroutineRandomStart;
    void Init()
    {
        
    }

    public void StartAllMolesBehavior()
    {
        if(_coroutineRandomStart!=null)
            StopCoroutine(_coroutineRandomStart);
        StartCoroutine(RandomStart());
    }

    IEnumerator RandomStart()
    {
        foreach (var mole in moles)
        {
            yield return new WaitForSeconds(Random.Range(0.5f, 1f));
            mole.StartBehavior();
        }
    }

    public void StopAllMolesBehavior()
    {
        foreach (var mole in moles)
        {
            mole.StopBehavior();
        }
    }
}
