using Godot;
using System;
using System.Collections.Generic;

public partial class Weapon : Node3D
{
    [Export]
    public WeaponData baseWeaponData;
    private WeaponData _activeWeaponData;
   
    private float fireRateTimer = 0.0f;
    public int bulletsInClip;
    public bool isEnabled = true;

    [Export] public NodePath TargetPath;
    private IDamageable _target;

    [Export] public NodePath DebugUIPath;
    private DebugUi _debugUI;

    private static Random _random = new Random();

    public override void _Ready()
    {
        _target = GetNode<Node>(TargetPath) as IDamageable;
        _debugUI = GetNodeOrNull<DebugUi>(DebugUIPath);
        RebuildWeaponData();
    }
    public void RebuildWeaponData()
    {
        _activeWeaponData = baseWeaponData.GetModifiedVersion();
        _debugUI?.UpdateWeaponStatsLabel(_activeWeaponData);
    }

    public void _on_shoot_button_pressed()
    {
        ShootDemo();
    }

    public void ShootDemo()
    {
        if (!isEnabled) return;

        float damage = CalculateShotDamage();

        _target?.ApplyDamage(damage);

        _debugUI?.UpdateLastShotDamage(damage);
    }

    private float CalculateShotDamage()
    {
        return _activeWeaponData.Damage * _activeWeaponData.ProjectilesPerShot;
    }
}
