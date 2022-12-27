using Godot;
using System;

public enum HitType
{
    Bullet,
    Fire,
}


public struct HitInfo
{
    public Vector2 direction;
    public HitType hitType;
}
public abstract class Hittable : Node2D
{

    public abstract void OnHit(HitInfo hitInfo);
}
