using Godot;
using System;

public partial class DebugUi : Control
{
    [Export] public Label DamageLabel;
    [Export] public Label TargetDummyLabel;
    [Export] public Label WeaponStatsLabel;

    public void UpdateLastShotDamage(float damage)
    {
        DamageLabel.Text = $"Last Shot Damage: {damage}";
    }

    public void UpdateWeaponStatsLabel(WeaponData data)
    {
        WeaponStatsLabel.Text =
            $"Damage: {data.Damage}\n" +
            $"Fire Rate: {data.FireRate}\n" +
            $"Projectiles per shot: {data.ProjectilesPerShot}\n" +
            $"Pierce: {data.Pierce}\n" +
            $"Spread: {data.Spread}\n" +
            $"Projectile speed: {data.ProjectileSpeed}\n" +
            $"Clip Size: {data.ClipSize}\n" +
            $"Reload time: {data.ReloadTime}\n";
    }

    public void UpdateTargetDummyLabel(float currentHealth, float maxHealth)
    {
        TargetDummyLabel.Text = $"Target Dummy\nHP: {currentHealth:0}/{maxHealth}";
    }
}
