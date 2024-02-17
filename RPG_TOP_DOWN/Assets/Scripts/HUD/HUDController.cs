using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{

    [Header("Itens")]
    [SerializeField] private Image WaterBar;
    [SerializeField] private Image WoodBar;
    [SerializeField] private Image CarrotBar;
    [SerializeField] private Image FishsBar;

    [Header("Tools")]
    // [SerializeField] private Image axeUI;
    // [SerializeField] private Image shovelUI;
    // [SerializeField] private Image watercanUI;
    public List<Image> toolsUI = new List<Image>();
    [SerializeField] private Color Selectedcolor;
    [SerializeField] private Color Alphacolor;
    private PlayerItens playerItens;
    private Player player;

    private int initial;
    private void Awake()
    {
        playerItens = FindAnyObjectByType<PlayerItens>();
        player = playerItens.GetComponent<Player>();
    }
    // Start is called before the first frame update
    void Start()
    {
        WaterBar.fillAmount = 0f;
        CarrotBar.fillAmount = 0f;
        WoodBar.fillAmount = 0f;
        FishsBar.fillAmount = 0f;
        initial = player.HandlingObj;
        ColorUI();
    }

    // Update is called once per frame
    void Update()
    {
        WaterBar.fillAmount = playerItens.totalWater / playerItens.WaterLimit1;
        CarrotBar.fillAmount = playerItens.TotalCarrot / playerItens.CarrotLimit;
        WoodBar.fillAmount = playerItens.TotalWood / playerItens.WoodLimit;
        FishsBar.fillAmount = playerItens.Fishs / playerItens.FishLimit;
        if (player.HandlingObj != initial)
        {
            ColorUI();
            initial = player.HandlingObj;
        }
    }

    private void ColorUI()
    {
        for (int i = 0; i < toolsUI.Count; i++)
        {
            if (i == player.HandlingObj)
            {
                toolsUI[i].color = Selectedcolor;
            }
            else
            {
                toolsUI[i].color = Alphacolor;
            }
        }
    }
}
