using Isekai.Utility;
using System.Collections.Generic;
using UnityEngine;

public class AssigmentDatabase : Singleton<AssigmentDatabase>
{
    [SerializeField] private List<AssigmentData> _assigmentData;

    public static AssigmentData GetAssigment(int id) => _Instance._assigmentData.Find(AssigmentData => AssigmentData.GetID() == id);

    public static AssigmentData GetAssigment(string name) => _Instance._assigmentData.Find(AssigmentData => AssigmentData.Name == name);

    public static AssigmentData GetRandomAssigment() => _Instance._assigmentData[Random.Range(0, _Instance._assigmentData.Count)];
}