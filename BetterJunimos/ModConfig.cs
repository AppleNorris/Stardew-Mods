﻿using StardewModdingAPI;

namespace BetterJunimos {
    internal class ModConfig {
        public JunimoCapability JunimoCapabilities { get; set; } = new JunimoCapability();
        internal class JunimoCapability {
            public bool PlantCrops { get; set; } = true;
            public bool FertilizeCrops { get; set; } = true;
            public bool ClearDeadCrops { get; set; } = true;
        }

        public JunimoImprovement JunimoImprovements { get; set; } = new JunimoImprovement();
        internal class JunimoImprovement {
            public bool CanWorkInRain { get; set; } = true;
            public int MaxJunimos { get; set; } = 3;
            public int MaxRadius { get; set; } = 8;
            public bool WorkFaster { get; set; } = false;
        }

        public JunimoPayments JunimoPayment { get; set; } = new JunimoPayments();
        internal class JunimoPayments {
            public bool WorkForWages { get; set; } = false;
            public PaymentAmount DailyWage { get; set; } = new PaymentAmount();
            internal class PaymentAmount {
                public int ForagedItems { get; set; } = 1;
                public int Flowers { get; set; } = 0;
                public int Fruit { get; set; } = 0;
                public int Wine { get; set; } = 0;
            }
        }

        public FunSettings FunChanges { get; set; } = new FunSettings();
        internal class FunSettings {
            public float RainyJunimoSpiritFactor = 0.7f;
            public bool JunimosAlwaysHaveLeafUmbrellas { get; set; } = false;
            public bool InfiniteJunimoInventory { get; set; } = false;
        }

        public OtherSettings Other { get; set; } = new OtherSettings();
        internal class OtherSettings {
            public SButton SpawnJunimoKeybind { get; set; } = SButton.J;
            public bool ReceiveMessages { get; set; } = true;
        }
    }
}
