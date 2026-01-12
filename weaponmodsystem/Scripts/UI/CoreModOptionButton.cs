using Godot;
using System;

public partial class CoreModOptionButton : OptionButton
{
    [Export] public WeaponLoadoutController loadout;
    [Export] public CoreModResource[] availableMods;
    [Export] public NodePath weaponPath;
    private Weapon _weapon;

    public override void _Ready()
    {
        ItemSelected += OnItemSelected;
        _weapon = GetNodeOrNull<Weapon>(weaponPath);
    }

    private void OnItemSelected(long index)
    {
        loadout.SetCoreMod(availableMods[index]);
    }
}
