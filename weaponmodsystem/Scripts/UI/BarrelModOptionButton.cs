using Godot;
using System;

public partial class BarrelModOptionButton : OptionButton
{
    [Export] public WeaponLoadoutController loadout;
    [Export] public BarrelModResource[] availableMods;
    [Export] public NodePath weaponPath;
    private Weapon _weapon;

    public override void _Ready()
    {
        ItemSelected += OnItemSelected;
        _weapon = GetNodeOrNull<Weapon>(weaponPath);
    }

    private void OnItemSelected(long index)
    {
        loadout.SetBarrelMod(availableMods[index]);
    }
}
