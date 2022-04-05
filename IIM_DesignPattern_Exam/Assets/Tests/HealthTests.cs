using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class HealthTests
{
    Health CreateHealth(int maxHealth, int startHealth) 
        => new GameObject("Health GameObject")
            .AddComponent<Health>()
            .SetField("_maxHealth", maxHealth)
            .SetField("_startHealth", startHealth)
            .CallAwake();

    // A Test behaves as an ordinary method
    [Test]
    public void HealthStartsWith10AndDamage9Obtain1()
    {
        // Arrange
        var h = CreateHealth(10, 10);

        // Act
        h.TakeDamage(9);

        // Assert
        Assert.AreEqual(1, h.CurrentHealth);
    }

    [Test]
    public void HealthStartsWith10AndDamage100Obtain1()
    {
        // Arrange
        var h = CreateHealth(10, 10);

        // Act
        h.TakeDamage(100);

        // Assert
        Assert.AreEqual(0, h.CurrentHealth);
    }

    [Test]
    public void HealthStartsWith10AndDamageMinus100Obtain1()
    {
        // Arrange
        var h = CreateHealth(10, 10);

        // Act

        // Assert
        Assert.Throws<ArgumentException>(() => h.TakeDamage(-100));
    }




    #region osef
    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator NewTestScriptWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }
    #endregion
}
