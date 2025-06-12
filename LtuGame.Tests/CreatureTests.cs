using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LtuGame.Tests;

using LtuGame.ConsoleGame.GameWorld;
using System;
using System.Collections.Generic;
using Xunit;


public class CreatureTests
{
    private const string ValidSymbol = "T";
    private const string InvalidSymbol = "";
    private const int MaxHealth = 100;
    private const int DefaultDamage = 50;

    private Cell _cell;
    private Creature _creature;

    public CreatureTests()
    {
        _cell = new Cell(new Position(0, 0));
        _creature = CreateCreature(_cell, ValidSymbol, MaxHealth);
    }

    private static Creature CreateCreature(Cell cell, string symbol, int health, int damage = DefaultDamage)
    {
        return new TestCreature(cell, symbol, health, damage);
    }

    private static (Creature attacker, Creature target) SetupCombat(int attackerHealth, int targetHealth, int attackerDamage = DefaultDamage)
    {
        var cell1 = new Cell(new Position(0, 0));
        var cell2 = new Cell(new Position(0, 0));
        var attacker = CreateCreature(cell1, "A", attackerHealth, attackerDamage);
        var target = CreateCreature(cell2, "T", targetHealth);
        return (attacker, target);
    }

    [Fact]
    public void Constructor_ShouldInitializeProperties()
    {
        Assert.Equal(_cell, _creature.Cell);
        Assert.Equal(ValidSymbol, _creature.Symbol);
        Assert.Equal(MaxHealth, _creature.MaxHealth);
        Assert.Equal(MaxHealth, _creature.Health);
    }

    [Theory]
    [InlineData(InvalidSymbol)]
    [InlineData(null)]
    public void Constructor_ShouldThrowException_OnInvalidSymbol(string? symbol)
    {
        Assert.Throws<ArgumentException>(() => CreateCreature(_cell, symbol!, MaxHealth));
    }

    [Fact]
    public void CellProperty_ShouldThrowException_OnNullValue()
    {
        Assert.Throws<ArgumentNullException>(() => _creature.Cell = null!);
    }

    [Fact]
    public void HealthProperty_ShouldNotExceedMaxHealth()
    {
        _creature.Health = 150;
        Assert.Equal(MaxHealth, _creature.Health);
    }

    [Fact]
    public void IsDead_ShouldReturnTrue_WhenHealthIsZeroOrLess()
    {
        _creature.Health = 0;
        Assert.True(_creature.IsDead);
    }

    [Fact]
    public void Color_ShouldReturnGray_WhenCreatureIsDead()
    {
        _creature.Health = 0;
        Assert.Equal(ConsoleColor.Gray, _creature.Color);
    }

    [Fact]
    public void Attack_ShouldReduceTargetHealth_WithDefaultDamage()
    {
        var (attacker, target) = SetupCombat(100, 100);
        attacker.Attack(target);
        Assert.Equal(MaxHealth - DefaultDamage, target.Health);
    }

    [Fact]
    public void Attack_ShouldReduceTargetHealth_WithCustomDamage()
    {
        const int customDamage = 25;
        var (attacker, target) = SetupCombat(100, 100, customDamage);
        attacker.Attack(target);
        Assert.Equal(MaxHealth - customDamage, target.Health);
    }

    [Fact]
    public void Attack_ShouldNotAffectTarget_WhenAttackerIsDead()
    {
        var (attacker, target) = SetupCombat(0, 100);
        attacker.Attack(target);
        Assert.Equal(100, target.Health);
    }

    [Fact]
    public void Attack_ShouldNotAffectTarget_WhenTargetIsDead()
    {
        var (attacker, target) = SetupCombat(100, 0);
        attacker.Attack(target);
        Assert.Equal(0, target.Health);
    }

    [Fact]
    public void Attack_ShouldLogAttackMessage()
    {
        var logMessages = new List<string>();
        Creature.AddToLog = logMessages.Add;

        var (attacker, target) = SetupCombat(100, 100);
        attacker.Attack(target);

        var expected = string.Format(LogMessages.AttackMessage, attacker.Name, target.Name, attacker.Damage);
        Assert.Contains(expected, logMessages);
    }

    [Fact]
    public void Attack_ShouldLogDeathMessage()
    {
        var logMessages = new List<string>();
        Creature.AddToLog = logMessages.Add;

        var (attacker, target) = SetupCombat(100, 50);
        attacker.Attack(target);

        var expected = string.Format(LogMessages.DeathMessage, target.Name);
        Assert.Contains(expected, logMessages);
    }

    private static class LogMessages
    {
        public const string AttackMessage = "The {0} attacks the {1} for {2}";
        public const string DeathMessage = "The {0} is dead";
    }

    
    private class TestCreature : Creature
    {
        public TestCreature(Cell cell, string symbol, int health, int damage = DefaultDamage)
            : base(cell, symbol, health)
        {
            Damage = damage;
        }

    }
}

