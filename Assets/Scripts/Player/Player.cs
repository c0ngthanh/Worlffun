using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : Singleton<Player>
{
    Dictionary<HarvestUnit,int> harvestUnits = new Dictionary<HarvestUnit,int>();
}
