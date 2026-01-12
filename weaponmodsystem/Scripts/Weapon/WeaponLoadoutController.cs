using Godot;
using System;
using System.Collections.Generic;

public partial class WeaponLoadoutController : Node
{
    [Export] public Weapon weapon;
    [Export] public WeaponData baseWeaponData;

    private CoreModResource coreMod;
    private BarrelModResource barrelMod;
    private MagazineModResource magazineMod;

    public void SetCoreMod(CoreModResource mod)
    {
        coreMod = mod;
        Apply();
    }

    public void SetBarrelMod(BarrelModResource mod)
    {
        barrelMod = mod;
        Apply();
    }

    public void SetMagazineMod(MagazineModResource mod)
    {
        magazineMod = mod;
        Apply();
    }

    private void Apply()
    {
        baseWeaponData.CoreMod = coreMod;
        baseWeaponData.BarrelMod = barrelMod;
        baseWeaponData.MagazineMod = magazineMod;

        weapon.RebuildWeaponData();
    }
}
