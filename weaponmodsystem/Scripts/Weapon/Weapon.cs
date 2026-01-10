using Godot;
using System;
using System.Collections.Generic;

public partial class Weapon : Node3D
{
    [Export]
    public WeaponData weaponData;
   
    private float fireRateTimer = 0.0f;
    public int bulletsInClip;
    public bool isEnabled = true;

    private static Random _random = new Random();

    public override void _Ready()
    {

    }

    public void SetupNewWeapon(WeaponData newWeaponData)
    {
        weaponData = newWeaponData;
        weaponData = (WeaponData)weaponData.Duplicate();

        bulletsInClip = weaponData.ClipSize;
    }

    public override void _Process(double delta)
    {
        fireRateTimer += (float)delta;
    }

    public void _on_shoot_button_pressed()
    {
        Shoot(Vector3.Zero);
    }

    public void Shoot(Vector3 direction)
    {
        if (bulletsInClip <= 0)
        {
            if (isEnabled)
            {
                Reload();
            }
        }
        else
        {
            if (fireRateTimer >= 1 / weaponData.FireRate && isEnabled)
            {
                fireRateTimer = 0.0f;
                bulletsInClip--;

                for (int i = 0; i < weaponData.ProjectilesPerShot; i++)
                {
                    //Calculate Spread
                    float halfSpread = weaponData.Spread / 2f;
                    float randomAngleDeg = (float)(_random.NextDouble() * weaponData.Spread - halfSpread);
                    float randomAngleRad = Mathf.DegToRad(randomAngleDeg);
                    Vector3 newDirection = direction.Rotated(Vector3.Up, randomAngleRad);
                }
            }
        }
    }

    public async void Reload()
    {
        isEnabled = false;
        GD.Print("Reload");
        await ToSignal(GetTree().CreateTimer(weaponData.ReloadTime), "timeout");
        bulletsInClip = weaponData.ClipSize;
        isEnabled = true;
    }

    public int GetCurrentBulletsInClip()
    {
        return bulletsInClip;
    }
    public int GetClipSize()
    {
        return weaponData.ClipSize;
    }
    public string GetWeaponName()
    {
        return weaponData.WeaponName;
    }

    public void ApplyMods(List<WeaponModResource> mods)
    {
        foreach (WeaponModResource mod in mods)
        {
            if (mod == null) continue;

            weaponData.Damage *= mod.DamageMultiplier;
            weaponData.FireRate *= mod.FireRateMultiplier;
            weaponData.ReloadTime *= mod.ReloadSpeedMultiplier;
            weaponData.ClipSize += mod.ExtraAmmo;
            weaponData.ProjectilesPerShot += mod.ExtraBulletsPerShot;
            weaponData.Spread += mod.SpreadBonus;
            weaponData.Pierce += mod.ExtraPierce;
            weaponData.ProjectileSpeed *= mod.ProjectileSpeedMultiplier;
        }

        bulletsInClip = weaponData.ClipSize;
    }
}
