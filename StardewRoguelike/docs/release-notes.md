[← back to readme](README.md)

# Release notes

## 1.1.1

Released on 8 October 2023 for SMAPI 3.15.0 or later.

- Fix: Possible crash when fishing

## 1.1.0

Released on 8 October 2023 for SMAPI 3.15.0 or later.

This release contains the full original game soundtrack created by [Therm](https://www.youtube.com/c/ThermChannel).
Check out the soundtrack on [Spotify](https://open.spotify.com/album/52D2KWYt3HkRcVrWvQQ9Wb?si=XshgYqK2RLGDKGRiILOC-Q) / [YouTube Music](https://music.youtube.com/playlist?list=OLAK5uy_kjGCpe72qCPi_PsKRvihbNU7G2CaAOvY4&si=bJ6E7OqJmnH0JtTP)

- Add: Ability to purchase backpack from merchant floors
- Add: Growable crops on merchant floors
  - Each crop takes a different amount of floors to grow
  - Crops purchasable from Volcano Dwarf
  - Harvest can be sold to Volcano Dwarf
- Add: Fishing capabilities (fishing rod drops from barrels, has limited uses)
- Add: Timed chest that spawns on floor 8 and must be reached before 5 minutes
- Add: Galaxy Soul reward for defeating bosses without being damaged
- Add: Computer in lobby for setting the generation seed
- Add: Save game options in-between game launches
- Add: Hat Board
  - Board spawns on floor 18
  - Choose from 3 random hats, perform quest, receive hat
  - Each hat gives a unique benefit
- Add: Additional cases to the in-game `/stuck` command
  - Remove map obstacles if monsters cannot path to player
- Add: New perks
  - Fisherman: Fishing rod has +2 uses
  - Deconstructor: Deconstructor can spawn on merchant floors and deconstructs items for gold
  - Gamer: Acquire gold from good performances in the arcade machines
  - Tiller: Crops sell for more
- Add: New curses
  - (De)Buff Monsters: Monsters have a 50% chance to apply a random buff/debuff on hit
- Add: New weapon enchantments
  - Star Shooter: Shoot star projectiles on attack
- Add: Sign to inform players of healing spa on merchant floors
- Add: Additional Maps
  - General Gameplay: 2 new custom maps
  - King of the Hill: 1 new custom map, egg hunt map
- Add: Translation capability (please help translate if you can!)
- Add: Visual attack cue indicator in some cases where it was only audio
- Add: Announce music credits on boss floors
- Add: New music track for Goobins ([thanks Therm!](https://www.youtube.com/c/ThermChannel))
- Add: New music track for Telesto ([thanks Therm!](https://www.youtube.com/c/ThermChannel))
- Add: New music track for Odys ([thanks Therm!](https://www.youtube.com/c/ThermChannel))
- Add: New music track for Ozul ([thanks Therm!](https://www.youtube.com/c/ThermChannel))
- Add: New music track for Nadith ([thanks Therm!](https://www.youtube.com/c/ThermChannel))
- Add: New music track for Arc ([thanks Therm!](https://www.youtube.com/c/ThermChannel))
- Add: Configuration option to automatically face the direction your mouse is relative to the player
- Adjust: Limit player to having 12 perks
- Adjust: Floor style will cycle again when looping
- Adjust: Boss HP bar will slowly change color based on their remaining HP
- Adjust: Weapons can be enchanted 999 times (as opposed to 3 times)
- Adjust: The forge can only be used 3 times per appearance
- Adjust: Scale monsters health and damage when looping
- Adjust: Spawn red bats after looping (on hard skull caverns)
- Adjust: Pause time if looting a chest
- Adjust: Increase food prices in shops
- Adjust: Disable chest floor between floors 7 and 11
- Adjust: Nerf Goobins base stats
- Adjust: Load button takes player directly into the game
- Fix: Split screen caused floors to skip, making it unplayable
- Fix: Reset player resilience when resetting
- Fix: Draw location desync for Cavrag on multiplayer
- Fix: Draw location desync for Telesto on multiplayer
- Fix: Stop multiple slingshots from spawning on multiplayer
- Fix: Escape key can now close the gamble wheel menu

## 1.0.17
Released on 11 September 2022 for SMAPI 3.15.0 or later.

- Fix: Possible softlock on speedrun challenge floor in multiplayer
- Fix: Having Indecisive perk would prevent players from opening the shop

## 1.0.16
Released on 10 September 2022 for SMAPI 3.15.0 or later.

- Add: New custom theme for 4th boss
- Add: New speedrun challenge floor
- Add: Whitelist [this zoom mod](https://www.nexusmods.com/stardewvalley/mods/7363)
- Add: Enables the `/stuck` command on boss floors
- Adjust: Item reward chests will attempt to avoid giving items you already have
- Adjust: Pick a Path outcome will change depending on player status
- Adjust: Hot Spring will no longer spawn if player is at or above 90% HP
- Adjust: 4th boss attack pattern
- Adjust: Change chest location of 4th boss
- Adjust: Remove merchant buy backs after menu is closed
- Fix: Possible infinite loop with `/stuck` command on non-normal mines floors
- Fix: Disables hard mode upon save load
- Fix: Bug Killer enchantment would not apply to 5th boss
- Fix: Layering issue with custom floor layout
- Fix: Incorrect rewards on some challenge floors
- Fix: Turtle Shell cooldown would decrease even if paused

## 1.0.15
Released on 7 September 2022 for SMAPI 3.15.0 or later.

- Add: New floor layout
- Adjust: Challenge floors have guaranteed rewards
- Adjust: Stats menu wording
- Adjust: Time will still pass if eating on wave kill challenge floor
- Adjust: Multiplayer clients cannot join mid-run
- Adjust: Multiplayer games cannot continue until all players reach merchant
- Fix: Luck would carry over from previous runs in certain conditions
- Fix: Cobwebs would drop items
- Fix: Various small fixes to custom floor layouts

## 1.0.14
Released on 7 September 2022 for SMAPI 3.15.0 or later.

- Adjust: Lower enemy spawn count on JOTPK floor
- Fix: Player wasn't receiving invincibility on death in singleplayer
- Fix: Heal over Time curse continued indefinitely
- Fix: Typo in Mister Qi dialogue
- Fix: Respawning in multiplayer didn't give items back
- Fix: It was possible to get an extra egg on hard mode
- Fix: Potent buffs curse wasn't applying to existing buffs
- Fix: Possible soft lock on 7th boss in multiplayer
- Fix: Multiplayer clients were able to enter before hosts

## 1.0.13
Released on 6 September 2022 for SMAPI 3.15.0 or later.

- Fix: /stuck command was able to be used in invalid locations

## 1.0.12
Released on 6 September 2022 for SMAPI 3.15.0 or later.

- Fix: Null reference exception with Refreshable Shop

## 1.0.11
Released on 6 September 2022 for SMAPI 3.15.0 or later.

- Add: Two new custom floor layouts
- Add: /stuck in-game command to prevent soft locks
- Add: Display missed items on Dwarf challenge floors
- Adjust: Buff tick rate of Damage over Time curse
- Adjust: Buff tick rate of Healing over Time curse
- Adjust: Enable Wooden Fences to be destroyed by pickaxe
- Adjust: 2nd boss hard mode difficulty adjustments
- Adjust: 5th boss difficulty adjustments
- Adjust: Hidden boss hard mode difficulty adjustments
- Adjust: Remove all crafting recipes except for Wooden Fence
- Fix: 7th boss attack on hard mode had wrong angle
- Fix: Possible exception with Indecisive perk
- Fix: Small visual bug in custom floor layout
- Fix: Dark floor is now chosen with floor generation random
- Fix: Disable monster slayer goals
- Fix: Disable spiders from jumping into water
- Fix: Deallocate MineShaft instances as they become inactive

## 1.0.10
Released on 5 September 2022 for SMAPI 3.15.0 or later.

- Fix: Stop 4th boss from despawning on multiplayer
- Fix: Softlock on new floor layout

## 1.0.9
Released on 5 September 2022 for SMAPI 3.15.0 or later.

- Add: Gamepad support on perk picking menu
- Add: Gamepad support on disclaimer menu
- Add: Gamepad support on stats menu
- Add: Gamepad support on refreshable shop menu
- Add: Gamepad support on wheel menu
- Add: Two new floor layouts
- Adjust: Mention hard mode in Qi's dialogue
- Adjust: Damage over Time curse now scales with total damage to be ticked
- Adjust: Phoenix Ring will now reset Damage over Time ticks (thanks AlexT)
- Fix: Fortune teller wasn't taking max HP (thanks AlexT)
- Fix: Damage over Time curse wasn't activating Phoenix Ring (thanks AlexT)
- Fix: Stop players from buying more than 4 Iridium Milks (thanks AlexT)
- Fix: Remove upload button from stats menu mid-run
- Fix: Stop spiders from jumping out of bounds
- Fix: Remove Refined Quartz from being dropped
- Fix: Various memory leak fixes

## 1.0.8
Released on 4 September 2022 for SMAPI 3.15.0 or later.

- Add: Display current version on game HUD
- Add: Sound effect on Dwarf floor
- Adjust: Rework max health system
- Adjust: Nerf leech to 25% chance (down from 50% chance)
- Fix: Life Elixir ignored Heal Over Time curse
- Fix: Phoenix Ring would not reset each run
- Fix: Fortune teller would still take hp/money even if player has all curses
- Fix: Slingshot challenge wouldn't give reward at 3 waves cleared
- Fix: Slime texture error when spawning slimes off of looped slime

## 1.0.7
Released on 3 September 2022 for SMAPI 3.15.0 or later.

- Add: Display in-game when an update is available
- Adjust: Set maximum cap on knockback
- Adjust: Double aggro range of blue squids
- Adjust: Change food selections with Cheaper Merchant curse
- Adjust: Lower fifth boss movement speed and attack durations
- Adjust: Stop Damage over Time curse from ticking when paused
- Adjust: Lower damage increase of Desperado perk
- Fix: Dwarf floor was taking more health than intended
- Fix: Challenge floors repeating
- Fix: Debug command for adding a specific curse was broken

## 1.0.6
Released on 3 September 2022 for SMAPI 3.15.0 or later.

- Adjust: Skull in top left by floor counter now indicates hard mode
- Adjust: Heal over time curse description
- Adjust: Heal over time will no longer heal while game is paused
- Fix: Cinder shards would be gained on unforging
- Fix: Layers on some trees on egg hunt floor were incorrect

## 1.0.5
Released on 2 September 2022 for SMAPI 3.15.0 or later.

- Add: Gamepad compatibility for the perk viewing menu
- Add: Debug command for adjusting player stamina
- Add: Debug command for forcing forge floors
- Add: Debug command for logging stats payload
- Adjust: Hard mode is now a toggle
- Adjust: Lower first boss max health
- Adjust: Lower projectile count on third boss
- Adjust: Mob cap if player has the more enemies curse
- Adjust: Names and descriptions for various curses and perks
- Adjust: Lower reward tiers on slingshot floors
- Adjust: Gold removal rate on Brittle Crown curse
- Adjust: lower duration on Putrid Ghost debuff
- Remove: Gesture of the Drowned curse
- Fix: Drinking snake milk would heal to max health
- Fix: Challenge floors would ignore history
- Fix: Items would spawn off exploded dirt
- Fix: Exhausting would follow default game behavior

## 1.0.4
Released on 2 September 2022 for SMAPI 3.15.0 or later.

- Fix: Calculation when checking monsters spawned count

## 1.0.3
Released on 2 September 2022 for SMAPI 3.15.0 or later.

- Adjust: Nerf the Arc boss fight
- Remove: Remove Amethyst Ring from the shop
- Fix: Small typos in curse descriptions

## 1.0.2
Released on 2 September 2022 for SMAPI 3.15.0 or later.

- Fix: Bug where floors could be skipped

## 1.0.1
Released on 2 September 2022 for SMAPI 3.15.0 or later.

- Fix: Infinite loop when loading challenge floor

## 1.0.0
Released on 2 September 2022 for SMAPI 3.15.0 or later.

- Initial release