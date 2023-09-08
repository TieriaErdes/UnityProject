using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[ExecuteInEditMode]
public class UniqueID : MonoBehaviour
{
    [ReadOnly, SerializeField] private string _id = Guid.NewGuid().ToString();
    [SerializeField] private static SerializableDictionary<string, GameObject> idDatabase = new SerializableDictionary<string, GameObject>();

    public string ID => _id;

    private void Awake()
    {
        if (idDatabase == null) idDatabase =
                new SerializableDictionary<string, GameObject>();

        if (idDatabase.ContainsKey(_id)) Generate();
        else idDatabase.Add(_id, this.gameObject);
    }

    //private void OnValidate()
    //{
    //    if (idDatabase.ContainsKey(_id)) Generate();
    //    else idDatabase.Add(_id, this.gameObject);
    //}

    private void OnDestroy()
    {
        if (idDatabase.ContainsKey(_id)) idDatabase.Remove(_id);
    }

    private void Generate()
    {
        _id = Guid.NewGuid().ToString();
        idDatabase.Add(_id, this.gameObject);

        //Debug.Log(idDatabase.Count);
    }
}
