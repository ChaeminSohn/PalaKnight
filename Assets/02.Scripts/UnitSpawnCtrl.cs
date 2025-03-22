using System.Collections.Generic;
using UnityEngine;

public class UnitSpawnCtrl : MonoBehaviour
{
    public Farmer farmerPrefab;
    public Archer archerPrefab;

    public Transform startPoint;

    private List<UnitCtrl> units = new();


    private void Update()
    {

    }

    public void CreateUnit(int num)
    {
        switch (num)
        {
            case 1:
                Farmer farmer = Instantiate(farmerPrefab, startPoint.position, startPoint.rotation);
                units.Add(farmer);
                farmer.OnDeath += () => units.Remove(farmer);
                break;
            case 2:
                Archer archer = Instantiate(archerPrefab, startPoint.position, startPoint.rotation);
                units.Add(archer);
                archer.OnDeath += () => units.Remove(archer);
                break;
        }
    }
}
