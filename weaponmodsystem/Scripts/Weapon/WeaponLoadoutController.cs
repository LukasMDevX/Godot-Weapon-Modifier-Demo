using Godot;
using System;
using System.Collections.Generic;

public partial class WeaponLoadoutController : Node
{
    [Export] public Weapon weapon;

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
        var mods = new List<WeaponModResource>();

        if (coreMod != null) mods.Add(coreMod);
        if (barrelMod != null) mods.Add(barrelMod);
        if (magazineMod != null) mods.Add(magazineMod);

        weapon.ApplyMods(mods);
    }
}
