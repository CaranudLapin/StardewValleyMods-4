using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using StardewRoguelike.Extensions;
using StardewValley;
using StardewValley.Locations;
using StardewValley.Monsters;
using StardewValley.Projectiles;
using System;
using System.Collections.Generic;

namespace StardewRoguelike.Bosses
{
    public class QueenBee : Fly, IBossMonster
    {
        public string DisplayName => "Hachi the Queen Bee";

        public string MapPath => "boss-queenbee";

        public string TextureName => "Characters\\Monsters\\Fly_dangerous";

        public Vector2 SpawnLocation => new(25, 27);

        public List<string> MusicTracks => new() { "bee_boss" };

        public bool InitializeWithHealthbar => true;

        public float Difficulty { get; set; }

        private int TicksToChargeWarmup = 0;
        private int ChargeDurationTicks = 0;

        private bool ChargingWarmup = false;
        private bool MidCharge = false;
        private Vector2 ChargeVector;

        private int TimesToCharge = 0;

        private int FireRate;
        private int StingersToShoot = 0;
        private int NextShot = 0;

        private int TicksToAttack = 300;

        private int PreviousAttack;

        private int WasHitCounter;
        private float TargetRotation;
        private bool TurningRight;

        public QueenBee() { }

        public QueenBee(float difficulty) : base(Vector2.Zero, true)
        {
            setTileLocation(SpawnLocation);
            Difficulty = difficulty;

            Slipperiness = 12;

            Sprite.LoadTexture(TextureName);
            HideShadow = true;
            Scale = 4f;

            moveTowardPlayerThreshold.Value = 20;
        }

        public override void behaviorAtGameTick(GameTime time)
        {
            if (!MidCharge)
                base.behaviorAtGameTick(time);

            if (Health <= 0)
                return;

            HandleChargeTick();

            if (StingersToShoot > 0)
            {
                NextShot--;

                if (NextShot == 0)
                {
                    ShootStinger();
                    StingersToShoot--;
                    NextShot = FireRate;
                }
                return;
            }

            if (IsCharging())
                return;

            if (TicksToAttack > 0)
            {
                TicksToAttack--;
                return;
            }

            int attack = -1;
            while (attack == -1 || attack == PreviousAttack)
                attack = Game1.random.Next(0, 3);

            if (attack == 0)
            {
                // stingers
                FireRate = 16 - this.AdjustRangeForHealth(0, 8);

                StingersToShoot = 60 * this.AdjustRangeForHealth(5, 10) / FireRate;
                NextShot = FireRate;

                TicksToAttack = 60 * 3;
                PreviousAttack = 0;
            }
            else if (attack == 1)
            {
                // swarm
                int beesToSpawn = this.AdjustRangeForHealth(4, 8);
                if (Roguelike.HardMode)
                    beesToSpawn += 2;
                SummonBees(beesToSpawn);
                TicksToAttack = 60 * 5;
                PreviousAttack = 1;
            }
            else
            {
                // charge
                StartCharging(this.AdjustRangeForHealth(3, 8));
                TicksToAttack = 60 * 3;
                PreviousAttack = 2;
            }
        }

        public void StartCharging(int times)
        {
            if (TimesToCharge == 0)
                TimesToCharge = times;
        }

        public bool IsAttacking()
        {
            return IsCharging() || StingersToShoot > 0;
        }

        public bool IsCharging()
        {
            return MidCharge || ChargingWarmup;
        }

        public void HandleChargeTick()
        {
            if (Player is null || TimesToCharge == 0)
                return;

            if (MidCharge)
            {
                Position += ChargeVector;
                rotation = RoguelikeUtility.VectorToRadians(ChargeVector) + RoguelikeUtility.DegreesToRadians(90);
                ChargeDurationTicks--;
                if (ChargeDurationTicks == 0)
                {
                    MidCharge = false;
                    TimesToCharge--;
                }
            }
            else if (ChargingWarmup && TicksToChargeWarmup > 0)
            {
                rotation = RoguelikeUtility.VectorToRadians(ChargeVector) + RoguelikeUtility.DegreesToRadians(90);
                TicksToChargeWarmup--;
            }
            else if (ChargingWarmup && TicksToChargeWarmup == 0)
            {
                currentLocation.playSound("croak");
                ChargeDurationTicks = Roguelike.HardMode ? 30 : 60;

                ChargingWarmup = false;
                MidCharge = true;
            }
            else if (!ChargingWarmup && TicksToChargeWarmup == 0)
            {
                ChargeVector = Player.Position - Position;
                ChargeVector.Normalize();
                ChargeVector *= this.AdjustRangeForHealth(13, 17);

                ChargingWarmup = true;
                TicksToChargeWarmup = 60 - this.AdjustRangeForHealth(0, 55);
            }
        }

        public void ShootStinger()
        {
            if (Player is null)
                return;

            float projectileSpeed = Roguelike.HardMode ? 12f : 10f;
            Vector2 v = Player.Position - new Vector2(GetBoundingBox().Center.X, GetBoundingBox().Center.Y);
            v.Normalize();
            v *= projectileSpeed;

            RoguelikeUtility.VectorToRadians(v);
            StingerProjectile proj = new(DamageToFarmer, v.X, v.Y, new Vector2(Position.X, Position.Y), "", "Cowboy_gunshot", currentLocation, this);
            proj.startingRotation.Value = RoguelikeUtility.VectorToRadians(v) + RoguelikeUtility.DegreesToRadians(90);
            currentLocation.projectiles.Add(proj);
        }

        public void SummonBees(int amount)
        {
            if (Curse.AnyFarmerHasCurse(CurseType.MoreEnemiesLessHealth))
                amount += 2;

            for (int i = 0; i < amount; i++)
            {
                Vector2 randomTile = new(getTileX() + Game1.random.Next(-4, 5), getTileY() + Game1.random.Next(-4, 5));

                Monster bee = new QueenBeeMinion(randomTile, Difficulty);
                Roguelike.AdjustMonster((MineShaft)currentLocation, ref bee);
                currentLocation.characters.Add(bee);
            }
        }

        public override void MovePosition(GameTime time, xTile.Dimensions.Rectangle viewport, GameLocation currentLocation)
        {
            int extraMovement = this.AdjustRangeForHealth(1, 5);
            for (int i = 0; i < extraMovement; i++)
                base.MovePosition(time, viewport, currentLocation);
        }

        public override void drawAboveAllLayers(SpriteBatch b)
        {
            if (Utility.isOnScreen(Position, 128))
            {
                b.Draw(Sprite.Texture, getLocalPosition(Game1.viewport) + new Vector2(32f, GetBoundingBox().Height / 2 - 32), Sprite.SourceRect, Color.White, rotation, new Vector2(8f, 16f), Math.Max(0.2f, scale) * 4f, flip ? SpriteEffects.FlipHorizontally : SpriteEffects.None, Math.Max(0f, drawOnTop ? 0.991f : ((float)(getStandingY() + 8) / 10000f)));
                b.Draw(Game1.shadowTexture, getLocalPosition(Game1.viewport) + new Vector2(32f, GetBoundingBox().Height / 2), Game1.shadowTexture.Bounds, Color.White, 0f, new Vector2(Game1.shadowTexture.Bounds.Center.X, Game1.shadowTexture.Bounds.Center.Y), 4f, SpriteEffects.None, (float)(getStandingY() - 1) / 10000f);
                if (isGlowing)
                    b.Draw(Sprite.Texture, getLocalPosition(Game1.viewport) + new Vector2(32f, GetBoundingBox().Height / 2 - 32), Sprite.SourceRect, glowingColor * glowingTransparency, rotation, new Vector2(8f, 16f), Math.Max(0.2f, scale) * 4f, flip ? SpriteEffects.FlipHorizontally : SpriteEffects.None, Math.Max(0f, drawOnTop ? 0.99f : ((float)getStandingY() / 10000f + 0.001f)));
            }
        }

        protected override void updateAnimation(GameTime time)
        {
            if (Game1.soundBank is not null && (buzz is null || !buzz.IsPlaying) && (currentLocation is null || currentLocation.Equals(Game1.currentLocation)))
            {
                buzz = Game1.soundBank.GetCue("flybuzzing");
                buzz.SetVariable("Volume", 0f);
                buzz.Play();
            }
            if (Game1.fadeToBlackAlpha > 0.8 && Game1.fadeIn && buzz is not null)
                buzz.Stop(AudioStopOptions.AsAuthored);
            else if (buzz is not null)
            {
                buzz.SetVariable("Volume", Math.Max(0f, buzz.GetVariable("Volume") - 1f));
                float volume = Math.Max(0f, 100f - Vector2.Distance(Position, Player.Position) / 64f / 16f * 100f);
                if (volume > buzz.GetVariable("Volume"))
                    buzz.SetVariable("Volume", volume);
            }

            if (WasHitCounter >= 0)
                WasHitCounter -= time.ElapsedGameTime.Milliseconds;

            Sprite.Animate(time, (FacingDirection == 0) ? 8 : ((FacingDirection != 2) ? (FacingDirection * 4) : 0), 4, 75f);
            if ((withinPlayerThreshold() || Utility.isOnScreen(position, 256)) && invincibleCountdown <= 0)
            {
                faceDirection(0);
                float xSlope = -(Player.GetBoundingBox().Center.X - GetBoundingBox().Center.X) + Game1.random.Next(-64, 65);
                float ySlope = Player.GetBoundingBox().Center.Y - GetBoundingBox().Center.Y + Game1.random.Next(-64, 65);
                float t = Math.Max(1f, Math.Abs(xSlope) + Math.Abs(ySlope));
                if (t < 64f)
                {
                    xVelocity = Math.Max(-7f, Math.Min(7f, xVelocity * 1.1f));
                    yVelocity = Math.Max(-7f, Math.Min(7f, yVelocity * 1.1f));
                }
                xSlope /= t;
                ySlope /= t;

                if (WasHitCounter <= 0)
                {
                    TargetRotation = (float)Math.Atan2(0f - ySlope, xSlope) - (float)Math.PI / 2f;

                    if ((Math.Abs(TargetRotation) - Math.Abs(rotation)) > Math.PI * 7.0 / 8.0 && Game1.random.NextDouble() < 0.5)
                        TurningRight = true;
                    else if ((Math.Abs(TargetRotation) - Math.Abs(rotation)) < Math.PI / 8.0)
                        TurningRight = false;

                    if (TurningRight)
                        rotation -= Math.Sign(TargetRotation - rotation) * ((float)Math.PI / 64f);
                    else
                        rotation += Math.Sign(TargetRotation - rotation) * ((float)Math.PI / 64f);

                    rotation %= (float)Math.PI * 2f;
                    WasHitCounter = 5 + Game1.random.Next(-1, 2);
                }

                float maxAccel = Math.Min(7f, Math.Max(2f, 7f - t / 64f / 2f));
                xSlope = (float)Math.Cos(rotation + Math.PI / 2.0);
                ySlope = 0f - (float)Math.Sin(rotation + Math.PI / 2.0);
                xVelocity += (0f - xSlope) * maxAccel / 6f + Game1.random.Next(-10, 10) / 100f;
                yVelocity += (0f - ySlope) * maxAccel / 6f + Game1.random.Next(-10, 10) / 100f;

                if (Math.Abs(xVelocity) > Math.Abs((0f - xSlope) * 7f))
                    xVelocity -= (0f - xSlope) * maxAccel / 6f;
                if (Math.Abs(yVelocity) > Math.Abs((0f - ySlope) * 7f))
                    yVelocity -= (0f - ySlope) * maxAccel / 6f;
            }

            resetAnimationSpeed();
        }

        public override void reloadSprite()
        {
            Sprite = new(TextureName);
            HideShadow = true;
        }

        public override Rectangle GetBoundingBox()
        {
            int boxWidth = (int)(Sprite.SpriteWidth * 4 * 3 / 6 * Scale);
            int boxHeight = (int)(Sprite.SpriteHeight * Scale * 2);
            return new Rectangle((int)Position.X - boxWidth / 3, (int)Position.Y - boxHeight / 8, boxWidth, boxHeight);
        }

        public override int takeDamage(int damage, int xTrajectory, int yTrajectory, bool isBomb, double addedPrecision, Farmer who)
        {
            int actualDamage = Math.Max(1, damage - resilience);
            if (Game1.random.NextDouble() < missChance - missChance * addedPrecision)
            {
                actualDamage = -1;
            }
            else
            {
                Health -= actualDamage;
                setTrajectory(xTrajectory / 3, yTrajectory / 3);
                WasHitCounter = 500;
                if (currentLocation is not null)
                {
                    currentLocation.playSound("hitEnemy");
                }
                if (Health <= 0)
                {
                    BossManager.Death(who.currentLocation, who, DisplayName, SpawnLocation);

                    if (currentLocation is not null)
                    {
                        currentLocation.playSound("monsterdead");
                        Utility.makeTemporarySpriteJuicier(new TemporaryAnimatedSprite(44, Position, Color.HotPink, 10)
                        {
                            interval = 70f
                        }, currentLocation);
                    }
                    if (Game1.soundBank is not null && buzz is not null)
                        buzz.Stop(AudioStopOptions.AsAuthored);
                }
            }
            addedSpeed = Game1.random.Next(-1, 1);
            return actualDamage;
        }
    }

    public class StingerProjectile : BasicProjectile
    {
        public StingerProjectile() : base() { }

        public StingerProjectile(int damageToFarmer, float xVelocity, float yVelocity, Vector2 startingPosition, string collisionSound, string firingSound, GameLocation? location = null, Character? firer = null)
            : base(damageToFarmer, 5, 0, 0, 0f, xVelocity, yVelocity, startingPosition, collisionSound, firingSound, false, false, location, firer)
        {
            ignoreLocationCollision.Value = true;
            ignoreMeleeAttacks.Value = true;
        }
    }
}
