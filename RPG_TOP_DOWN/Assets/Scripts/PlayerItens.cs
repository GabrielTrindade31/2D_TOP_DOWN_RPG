using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItens : MonoBehaviour
{
    [SerializeField] private int totalWood;
    [SerializeField] private int carrot;
    [SerializeField] private int fish;
    public int TotalWood { get => totalWood; set => totalWood = value; }
    public int TotalCarrot { get => carrot; set => carrot = value; }
    public float WaterLimit1 { get => waterLimit; set => waterLimit = value; }
    public float CarrotLimit { get => carrotLimit; set => carrotLimit = value; }
    public float WoodLimit { get => woodLimit; set => woodLimit = value; }
    public int Fishs { get => fish; set => fish = value; }
    public float FishLimit { get => fishLimit; set => fishLimit = value; }

    // Start is called before the first frame update
    public float totalWater;
    private float waterLimit = 50;
    private float carrotLimit = 10;
    private float woodLimit = 6;

    private float fishLimit = 4;
    void Start()
    {
        totalWood = 0;
        totalWater = 0;
        carrot = 0;
        Fishs = 0;

    }

    public void WaterLimit(float water)
    {
        if (totalWater <= WaterLimit1)
        {
            totalWater += water;
        }

    }
}
