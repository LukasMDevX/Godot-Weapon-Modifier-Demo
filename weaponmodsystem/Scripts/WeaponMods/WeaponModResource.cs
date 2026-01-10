using Godot;
using System;
using static System.Net.Mime.MediaTypeNames;

[GlobalClass]
public partial class WeaponModResource : Resource
{
    [Export] public string Id = "mod_default";
    [Export] public string DisplayName = "Name";
    [Export] public string Description = "Description";

    [Export] public float DamageMultiplier = 1.0f;
    [Export] public float FireRateMultiplier = 1.0f;
    [Export] public float ReloadSpeedMultiplier = 1.0f;
    [Export] public int ExtraAmmo = 0;
    [Export] public int ExtraPierce = 0;
    [Export] public int ExtraBulletsPerShot = 0;
    [Export] public float SpreadBonus = 0f;
    [Export] public float ProjectileSpeedMultiplier = 1f;

    [Export] public Texture2D Icon;

    [Export] public string UnlockMapId = "map1";   // Which map unlocks it
    [Export] public int UnlockRound = 15;          // Round required

    public virtual string SlotType => "generic";

    public void ApplyToWeapon(WeaponData weapon)
    {
        weapon.Damage *= DamageMultiplier;
        weapon.FireRate *= FireRateMultiplier;
        weapon.ReloadTime *= ReloadSpeedMultiplier;
        weapon.ClipSize += ExtraAmmo;
        weapon.Pierce += ExtraPierce;
        weapon.ProjectilesPerShot += ExtraBulletsPerShot;
    }
}
