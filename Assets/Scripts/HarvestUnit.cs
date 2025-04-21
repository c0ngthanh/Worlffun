using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum HarvestUnitType
{
    Carrot = 1,
    Onion = 2,
    Cow = 3,
    SugarBeet = 4
}

public class HarvestUnit : MonoBehaviour
{
    [SerializeField] private HarvestUnitType harvestUnitType;
    public UnitData.RowData unitData;
    private Sprite sprite;
    public BaseState<HarvestUnit> currentState;
    public HarvestUnitRipeState ripeState = new HarvestUnitRipeState();
    public HarvestUnitGrowState growState = new HarvestUnitGrowState();
    private Animator animator;
    private static Dictionary<string, int> animationHash = new Dictionary<string, int>();
    private int speedHash = Animator.StringToHash("Speed");
    void Awake()
    {
        sprite = GetComponent<SpriteRenderer>().sprite;
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        // Ensure sprites are loaded
        unitData = CSVReader.Instance.unitData.GetUnitData((int)harvestUnitType);
        if(!animationHash.ContainsKey(unitData.animationName))
        {
            animationHash.Add(unitData.animationName, Animator.StringToHash(unitData.animationName));
        }
        SwitchState(growState);
        if (unitData != null)
        {
            Debug.Log("Unit Name: " + unitData.unitName);
            Debug.Log("Time: " + unitData.Time);
            Debug.Log("Max Value: " + unitData.MaxValue);
            Debug.Log("Sprite Names: " + unitData.animationName);
        }
    }
    public void SwitchState(BaseState<HarvestUnit> newState)
    {
        currentState = newState;
        currentState.EnterState(this);
    }
    private void Update()
    {
        currentState.UpdateState(this);
    }
    public void PlayAnimation()
    {
        if (animationHash.ContainsKey(unitData.animationName))
        {
            animator.Play(animationHash[unitData.animationName]);
            animator.SetFloat(speedHash, 1/(float)unitData.Time); 
        }
        else
        {
            Debug.LogWarning("Animation not found: " + unitData.animationName);
        }
    }
}
