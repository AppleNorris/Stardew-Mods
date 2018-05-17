﻿using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace TillableGround {
     public class TillableGround : Mod {
        private ModConfig Config;

        public override void Entry(IModHelper helper) {
            Config = Helper.ReadConfig<ModConfig>();

            if (Config.TillAnywhere) {
                InputEvents.ButtonReleased += InputEvents_ButtonReleased;
            }
            else {
                InputEvents.ButtonPressed += InputEvents_ButtonPressed;
            }
        }

        void InputEvents_ButtonPressed( object sender, EventArgsInput e ) {
            if (!Context.IsWorldReady) { return; }

            if (e.Button == SButton.H) {
                Vector2 tile = e.Cursor.Tile;
                int x = (int)tile.X, y = (int)tile.Y;
                if (Utility.tileWithinRadiusOfPlayer(x, y, 1, Game1.player)) {
                    SetTileTillable(x, y);
                    FancyTillFeedback(x, y);
                }
            }
        }

        void InputEvents_ButtonReleased( object sender, EventArgsInput e ) {
            if (e.IsUseToolButton && Game1.player.CurrentTool is StardewValley.Tools.Hoe) {
                foreach (Vector2 tile in GetHoedTiles()) {
                    int x = (int)tile.X, y = (int)tile.Y;
                    SetTileTillable(x, y);
                }
            }
        }

        public void SetTileTillable(int x, int y) {
            Game1.currentLocation.setTileProperty(x, y, "Back", "Diggable", "T");
        }

        public List<Vector2> GetHoedTiles() {
            Farmer player = Game1.player;
            Vector2 vector = player.GetToolLocation(false);
            Vector2 offset = new Vector2((float)(vector.X / 64), (float)(vector.Y / 64));

            return this.Helper.Reflection.GetMethod(player.CurrentTool, "tilesAffected").
                Invoke<List<Vector2>>(offset, player.toolPower, player);
        }

        public void FancyTillFeedback(int x, int y) {
            // Add the hoe animation without hoeing
            Game1.currentLocation.temporarySprites.Add(
                 new TemporaryAnimatedSprite(12, new Vector2(x * 64f, y * 64f), Color.White, 8,
                     Game1.random.NextDouble() < 0.5, 50f, 0, -1, -1f, -1, 0)
            );

            Game1.addHUDMessage(new HUDMessage("Made tile tillable", 3) {
                noIcon = true,
                timeLeft = HUDMessage.defaultTime / 4
            });
        }
    }
}
