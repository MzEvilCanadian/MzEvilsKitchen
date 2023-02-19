﻿using Kitchen;
using KitchenData;
using KitchenLib.Colorblind;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace ModdedKitchen.Mains.Chili.Extras.Deluxe
{
    class DeluxeChiliPlated : CustomItemGroup <MyItemGroupView>
    {
        public override string UniqueNameID => "Deluxe Plated Chili";
        public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("DelxueChiliPlated");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemValue ItemValue => ItemValue.MediumLarge;
        public override Item DisposesTo => Main.Plate;
        public override Item DirtiesTo => Main.DirtyPlate;
        public override bool CanContainSide => true;

        public override List<ItemGroup.ItemSet> Sets => new()
        {
            new ItemGroup.ItemSet()
            {
                Max = 2,
                Min = 2,
                IsMandatory = true,
                Items = new List<Item>()
                {
                    Main.DeluxeChiliPortion,
                    Main.Plate
                }
            },
            new ItemGroup.ItemSet()
            {
                Max = 2,
                Min = 0,
                RequiresUnlock = true,
                Items = new List<Item>()
                {
                    Main.GratedCheese,
                    Main.WhippingCream
                }
            },
        };
        public override void OnRegister(GameDataObject gameDataObject)
        {

            var materials = new Material[]
            {
                  MaterialUtils.GetExistingMaterial("Plate"),
                  MaterialUtils.GetExistingMaterial("Plate - Ring")
        };
            MaterialUtils.ApplyMaterial(Prefab, "Bowl", materials);

            MaterialUtils.ApplyMaterial(Prefab, "Plate", materials);

            materials[0] = MaterialUtils.GetExistingMaterial("Tomato Flesh");
            materials[1] = MaterialUtils.GetExistingMaterial("Tomato Flesh");
            MaterialUtils.ApplyMaterial(Prefab, "Sauce", materials);

            materials[0] = MaterialUtils.GetExistingMaterial("Tomato");
            materials[1] = MaterialUtils.GetExistingMaterial("Tomato");
            MaterialUtils.ApplyMaterial(Prefab, "Tomato", materials);
            MaterialUtils.ApplyMaterial(Prefab, "Tomato 2", materials);

            materials[0] = MaterialUtils.GetExistingMaterial("Onion - Flesh");
            materials[1] = MaterialUtils.GetExistingMaterial("Onion - Flesh");
            MaterialUtils.ApplyMaterial(Prefab, "Onion", materials);
            MaterialUtils.ApplyMaterial(Prefab, "Onion 2", materials);

            materials[0] = MaterialUtils.GetExistingMaterial("Soup - Meat");
            materials[1] = MaterialUtils.GetExistingMaterial("Soup - Meat");
            MaterialUtils.ApplyMaterial(Prefab, "Meat", materials);

            materials[0] = MaterialUtils.GetExistingMaterial("Sweetcorn - Cooked");
            materials[1] = MaterialUtils.GetExistingMaterial("Sweetcorn - Cooked");
            MaterialUtils.ApplyMaterial(Prefab, "Corn", materials);

            materials[0] = MaterialUtils.GetExistingMaterial("Bean - Cooked");
            materials[1] = MaterialUtils.GetExistingMaterial("Bean - Cooked");
            MaterialUtils.ApplyMaterial(Prefab, "Beans", materials);

            materials[0] = MaterialUtils.GetExistingMaterial("Plastic - Yellow");
            materials[1] = MaterialUtils.GetExistingMaterial("Plastic - Yellow");
            MaterialUtils.ApplyMaterial(Prefab, "Cheese", materials);

            materials[0] = MaterialUtils.GetExistingMaterial("Plate");
            materials[1] = MaterialUtils.GetExistingMaterial("Plate");
            MaterialUtils.ApplyMaterial(Prefab, "Sour Cream", materials);

            Prefab.GetComponent<MyItemGroupView>()?.Setup(Prefab);
            if (!Prefab.TryGetComponent<ItemGroupView>(out var itemGroupView))
            {
                GameObject clonedColourBlind = ColorblindUtils.cloneColourBlindObjectAndAddToItem(GameDataObject as ItemGroup);
                ColorblindUtils.setColourBlindLabelObjectOnItemGroupView(itemGroupView, clonedColourBlind);
            }
        }
    }
    public class MyItemGroupView : ItemGroupView
    {
        internal void Setup(GameObject prefab)
        {
            // This tells which sub-object of the prefab corresponds to each component of the ItemGroup
            // All of these sub-objects are hidden unless the item is present
            ComponentGroups = new()
            {
                new()
                {
                    Objects = new()
                    {
                        GameObjectUtils.GetChildObject(prefab, "Bowl"),
                        GameObjectUtils.GetChildObject(prefab, "Sauce"),
                        GameObjectUtils.GetChildObject(prefab, "Tomato"),
                        GameObjectUtils.GetChildObject(prefab, "Tomato 2"),
                        GameObjectUtils.GetChildObject(prefab, "Onion"),
                        GameObjectUtils.GetChildObject(prefab, "Onion 2"),
                        GameObjectUtils.GetChildObject(prefab, "Meat"),
                        GameObjectUtils.GetChildObject(prefab, "Corn"),
                        GameObjectUtils.GetChildObject(prefab, "Beans"),
                    },
                    Item = Main.DeluxeChiliPortion,
                    DrawAll = true
                },
                new()
                {

                    GameObject = GameObjectUtils.GetChildObject(prefab, "Plate"),
                    Item = Main.Plate,
                },
                new()
                {

                    GameObject = GameObjectUtils.GetChildObject(prefab, "Cheese"),
                    Item = Main.GratedCheese,
                },
                new()
                {

                    GameObject = GameObjectUtils.GetChildObject(prefab, "Sour Cream"),
                    Item = Main.WhippedCream,
                },

            };
            ComponentLabels = new()
            {
                new()
                {
                    Item = Main.DeluxeChiliPortion,
                    Text = "DC"
                },
                new()
                {
                    Item = Main.Plate,
                    Text = "h"
                },
                new()
                {
                    Item = Main.GratedCheese,
                    Text = "C"
                },
                new()
                {
                    Item = Main.WhippedCream,
                    Text = "Sc"
                },

            };
        }
    }
}
