using Isekai.Utility;
using System.Collections.Generic;

public class AssigmentSystem : Singleton<AssigmentSystem>
{
    private static List<AssigmentData> _assigmentData = new List<AssigmentData>();

    public static void AddAssigment(AssigmentData data) => _assigmentData.Add(data);

    public static int AssigmentListCount() => _assigmentData.Count;

    public static List<AssigmentData> GetAssigmentList() => _assigmentData;

    public static void RemoveAssigment(AssigmentData data) => _assigmentData.Remove(data);
}
