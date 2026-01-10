# Modular Weapon & Modification System (Godot)

## Overview

This repository contains a **modular, data-driven weapon system** developed in **Godot (C#)**.  
The system was originally created as part of a larger **top-down zombie shooter project** and has been extracted to demonstrate its **architecture, extensibility, and separation of concerns**.

The focus of this project lies on **weapon customization**, **stat-driven behavior**, and **clean integration between gameplay logic and UI**.

---

## Core Concepts

### Modular Weapon Architecture

Weapons are composed of:
- a **base weapon definition** (`WeaponData`)
- a set of **optional modifiers** (mods) applied at runtime

Each weapon instance:
- duplicates its base data on initialization
- applies stat changes through modifiers
- remains independent from UI logic

This allows weapons to be:
- reused across multiple characters
- modified without changing core code
- extended with new modifiers without refactoring existing systems

---

## Weapon Modification System

### Weapon Mods

Weapon mods are defined as **data resources** and can modify:

- Damage
- Fire rate
- Reload speed
- Magazine size
- Projectile count
- Spread
- Projectile speed
- Pierce count

Mods are **stackable** and applied through a centralized system.

---

### Loadout-Based Application

Mods are **not applied directly by the UI**.

Instead, the system introduces a **Weapon Loadout Controller**, which:
- manages equipped mods per slot (e.g. Core, Barrel, Magazine)
- collects active modifiers
- applies them to the weapon in a single, controlled step

This mirrors real-world game architecture and keeps:
- UI logic decoupled from gameplay systems
- weapon logic independent of presentation

---

## Demo vs. Production Usage

### Demo Scene

For demonstration purposes, this repository includes a **minimal interactive demo** that allows:

- selecting weapon mods via UI buttons
- instantly applying modifications
- firing the weapon to observe stat changes

This setup exists **solely to visualize the system behavior**.

---

### Intended Usage in the Full Game

In the original project, weapon modifications are:

- applied **only in a dedicated hub / loadout area**
- persisted through a save system
- locked during active gameplay runs

Live modification during gameplay is **not intended for production use** and is intentionally exposed in the demo to make the system easier to inspect and understand.

---

## Technical Highlights

- Data-driven weapon definitions
- Resource-based modifiers
- Clean separation between:
  - UI
  - loadout management
  - weapon logic
- Extendable modifier system
- No hard dependency on specific visuals or assets

---

## Scope & Limitations

This repository focuses on **weapon and modification logic only**.

The following systems are **intentionally omitted or simplified**:
- complex visual effects (muzzle flashes, VFX pipelines)
- audio setup
- save system integration
- animation controllers
- player movement and camera logic

These systems exist in the full project but are outside the scope of this standalone demonstration.

---

## Technologies

- **Engine:** Godot
- **Language:** C#
- **Architecture Focus:** Modular gameplay systems, data-driven design

---

## Motivation

This repository exists to showcase:
- gameplay system architecture
- modular design principles
- production-oriented coding practices

It is intended for **technical review**, **portfolio presentation**, and **code discussion**, not as a complete game.