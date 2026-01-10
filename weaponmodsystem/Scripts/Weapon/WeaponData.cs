using Godot;
using System;

[GlobalClass]
public partial class WeaponData : Resource
{
    [Export] public string Id { get; set; } = "default";
    [Export] public string WeaponName { get; set; } = "Default Weapon";
    [Export] public bool isPistol = false;
    [Export] public float Damage { get; set; } = 1.0f;
    [Export] public int Pierce { get; set; } = 0;
    [Export] public int ProjectilesPerShot { get; set; } = 1;
    [Export] public float Spread { get; set; } = 0;
    [Export] public float ProjectileSpeed { get; set; } = 30.0f;
    [Export] public float FireRate { get; set; } = 5.0f;
    [Export] public int ClipSize { get; set; } = 30;
    [Export] public float ReloadTime { get; set; } = 1.0f;
    [Export] public AudioStream ShootSound{ get; set; }
    [Export] public AudioStream ReloadSound { get; set; }
    [Export] public PackedScene ProjectileScene { get; set; }
    [Export] public PackedScene WeaponScene { get; set; }
    [Export] public WeaponData CurseWeapon { get; set; }
    [Export] public bool isCursedVersion { get; set; }
    [Export] public Texture2D Icon { get; set; }

    [Export] public MagazineModResource MagazineMod { get; set; }
    [Export] public CoreModResource CoreMod { get; set; }
    [Export] public BarrelModResource BarrelMod { get; set; }


    public WeaponData GetModifiedVersion()
    {
        var modded = (WeaponData)this.Duplicate();

        MagazineMod?.ApplyToWeapon(modded);
        CoreMod?.ApplyToWeapon(modded);
        BarrelMod?.ApplyToWeapon(modded);

        return modded;
    }
}
