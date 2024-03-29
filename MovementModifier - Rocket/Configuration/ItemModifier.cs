﻿using SDG.Unturned;
using System.Globalization;
using System.Xml.Serialization;
// ReSharper disable CompareOfFloatsByEqualityOperator

namespace MovementModifier.Configuration
{
    public class ItemModifier
    {
        [XmlAttribute]
        public string Id = "0";

        [XmlIgnore]
        public ItemAsset? Asset = null;

        [XmlIgnore]
        public bool ModifiesAnything => Speed != 1 || Jump != 1 || Gravity != 1 || StaminaCost != 1;

        [XmlIgnore]
        public float Speed = 1;

        [XmlAttribute("Speed")]
        public string? SpeedStr
        {
            get => Speed == 1 ? null : Speed.ToString(CultureInfo.InvariantCulture);
            set => Speed = value == null ? 1 : float.Parse(value, CultureInfo.InvariantCulture);
        }

        [XmlIgnore]
        public float Jump = 1;

        [XmlAttribute("Jump")]
        public string? JumpStr
        {
            get => Jump == 1 ? null : Jump.ToString(CultureInfo.InvariantCulture);
            set => Jump = value == null ? 1 : float.Parse(value, CultureInfo.InvariantCulture);
        }


        [XmlIgnore]
        public float Gravity = 1;

        [XmlAttribute("Gravity")]
        public string? GravityStr
        {
            get => Gravity == 1 ? null : Gravity.ToString(CultureInfo.InvariantCulture);
            set => Gravity = value == null ? 1 : float.Parse(value, CultureInfo.InvariantCulture);
        }


        [XmlIgnore]
        public float StaminaCost = 1;

        [XmlAttribute("StaminaCost")]
        public string? StaminaCostStr
        {
            get => StaminaCost == 1 ? null : StaminaCost.ToString(CultureInfo.InvariantCulture);
            set => StaminaCost = value == null ? 1 : float.Parse(value, CultureInfo.InvariantCulture);
        }


        [XmlIgnore]
        public bool? MustBeEquipped = null;

        [XmlAttribute("MustBeEquipped")]
        public string? MustBeEquippedStr
        {
            get => MustBeEquipped?.ToString();
            set => MustBeEquipped = string.IsNullOrEmpty(value) ? null : bool.Parse(value!);
        }

        public bool GetMustBeEquipped()
        {
            if (MustBeEquipped.HasValue) return MustBeEquipped.Value;

            if (Asset == null) return false;

            switch (Asset.type)
            {
                case EItemType.BACKPACK:
                case EItemType.GLASSES:
                case EItemType.HAT:
                case EItemType.MASK:
                case EItemType.PANTS:
                case EItemType.SHIRT:
                case EItemType.VEST:

                case EItemType.CLOUD:
                case EItemType.GUN:
                case EItemType.MELEE:
                case EItemType.TOOL:
                case EItemType.VEHICLE_REPAIR_TOOL:
                    return true;

                default:
                    return false;
            }
        }
    }
}
