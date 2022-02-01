using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class ClickTest
{
    // A Test behaves as an ordinary method
    [Test]
    public void Click_Without_Upgrades_Equals_One()
    {
        // assign
        var gameObject = new GameObject();
        Player player = gameObject.AddComponent<Player>();
        player.utencils = new System.Collections.Generic.List<BoughtUtencil>();
        // act

        // assert
        Assert.AreEqual(1, player.ClickAmount);
    }
}