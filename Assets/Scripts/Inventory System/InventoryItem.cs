using UnityEngine;
 public abstract class InventoryItem : HUDItem
  {
        [Header("Item Data")]
        [SerializeField] private Rarity rarity = null;
        [SerializeField] [Min(0)] private int sellPrice = 1;
        [SerializeField] [Min(1)] private int maxStack = 1;
    
        public override string Rare 
        {
            get
            {
                string hexColour = ColorUtility.ToHtmlStringRGB(rarity.TextColour);
                return $"<color=#{hexColour}>{Name}</color>";
            }
        }
        public int SellPrice => sellPrice;
        public int MaxStack => maxStack;
        public Rarity Rarity => rarity;
 }
