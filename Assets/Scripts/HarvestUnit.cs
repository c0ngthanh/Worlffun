using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum HarvestUnitType
{
    Tomato = 1,
    Berry = 2,
    Cow = 3,
    Strawberry = 4
}

public class HarvestUnit : MonoBehaviour
{
    [SerializeField] private HarvestUnitType harvestUnitType;
    private UnitData.RowData unitData;
    private Sprite sprite;
    public BaseState<HarvestUnit> currentState;
    public HarvestUnitRipeState ripeState = new HarvestUnitRipeState();
    public HarvestUnitGrowState growState = new HarvestUnitGrowState();
    // Static dictionary to cache sprites
    private static Dictionary<string, Sprite> spriteCache = new Dictionary<string, Sprite>();

    // Static method to load all sprites once
    private static void LoadSprites()
    {
        if (spriteCache.Count == 0) // Only load if not already loaded
        {
            Sprite[] sprites = Resources.LoadAll<Sprite>("Sprite/HarvestUnit");
            foreach (var s in sprites)
            {
                spriteCache[s.name] = s; // Cache sprite by name
            }
        }
    }

    void Awake()
    {
        sprite = GetComponent<SpriteRenderer>().sprite;
    }

    void Start()
    {
        // Ensure sprites are loaded
        LoadSprites();
        SwtichState(growState);
        unitData = CSVReader.Instance.unitData.GetUnitData((int)harvestUnitType);
        if (unitData != null)
        {
            // Retrieve sprite from cache
            if (spriteCache.TryGetValue(unitData.spriteName[2], out sprite))
            {
                GetComponent<SpriteRenderer>().sprite = sprite;
            }
            else
            {
                Debug.LogError("Sprite not found in cache: " + unitData.spriteName[2]);
            }

            Debug.Log("Unit Name: " + unitData.unitName);
            Debug.Log("Time: " + unitData.Time);
            Debug.Log("Max Value: " + unitData.MaxValue);
            Debug.Log("Sprite Names: " + string.Join(", ", unitData.spriteName));
        }
    }
    private void SwtichState(BaseState<HarvestUnit> newState)
    {
        currentState = newState;
        currentState.EnterState(this);
    }
    private void Update()
    {
        currentState.UpdateState(this);
    }
}
