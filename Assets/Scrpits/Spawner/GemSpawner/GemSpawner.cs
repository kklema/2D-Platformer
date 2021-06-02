using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemSpawner : MonoBehaviour
{
    [SerializeField] private Gem _gemPrefab;
    [SerializeField] private float _cooldown;

    private Gem createdGem;

    private float _elapsedTime = 0;


    private void Start()
    {
        createdGem = Instantiate(_gemPrefab, transform.position, Quaternion.identity);
        createdGem.gameObject.SetActive(true);
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime >= _cooldown && createdGem.gameObject.activeSelf == false)
        {
            _elapsedTime = 0;
            createdGem.gameObject.SetActive(true);
        }
    }
}