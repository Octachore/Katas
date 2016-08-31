﻿using Core.Katas.PaintFiller;
using NUnit.Framework;

namespace Tests.Katas
{
    public class PaintFillerTests
    {
        [Test]
        public void PaintFillerTest()
        {
            var grid = new[,]
                       {
                           {3, 0, 0, 0, 0, 0, 0, 0, 0},
                           {0, 0, 0, 1, 1, 1, 1, 0, 0},
                           {0, 1, 1, 1, 0, 0, 1, 0, 0},
                           {0, 1, 0, 0, 0, 0, 1, 1, 0},
                           {0, 1, 0, 0, 0, 0, 0, 1, 0},
                           {0, 1, 0, 1, 1, 1, 1, 1, 0},
                           {0, 1, 1, 1, 0, 0, 0, 0, 0},
                           {0, 0, 0, 0, 0, 0, 0, 0, 0},
                           {0, 0, 0, 0, 0, 0, 0, 0, 0}
                       };

            var expectedGrid = new[,]
                       {
                           {3, 0, 0, 0, 0, 0, 0, 0, 0},
                           {0, 0, 0, 1, 1, 1, 1, 0, 0},
                           {0, 1, 1, 1, 2, 2, 1, 0, 0},
                           {0, 1, 2, 2, 2, 2, 1, 1, 0},
                           {0, 1, 2, 2, 2, 2, 2, 1, 0},
                           {0, 1, 2, 1, 1, 1, 1, 1, 0},
                           {0, 1, 1, 1, 0, 0, 0, 0, 0},
                           {0, 0, 0, 0, 0, 0, 0, 0, 0},
                           {0, 0, 0, 0, 0, 0, 0, 0, 0}
                       };

            Filler.FillArea(grid, 4, 4, 2);

            Assert.That(grid, Is.EquivalentTo(expectedGrid));
        }

        [Test]
        public void PaintFillerTest2()
        {
            var grid = new[,]
                       {
                           {3, 0, 0, 0, 0, 0, 0, 0, 0},
                           {0, 0, 0, 1, 1, 1, 1, 0, 0},
                           {0, 1, 1, 1, 0, 0, 1, 0, 0},
                           {0, 1, 0, 0, 0, 0, 1, 1, 0},
                           {0, 1, 0, 0, 0, 0, 0, 1, 0},
                           {0, 1, 0, 1, 1, 1, 1, 1, 0},
                           {0, 1, 1, 1, 0, 0, 0, 0, 0},
                           {0, 0, 0, 0, 0, 0, 0, 0, 0},
                           {0, 0, 0, 0, 0, 0, 0, 0, 0}
                       };

            var expectedGrid = new[,]
                       {
                           {3, 2, 2, 2, 2, 2, 2, 2, 2},
                           {2, 2, 2, 1, 1, 1, 1, 2, 2},
                           {2, 1, 1, 1, 0, 0, 1, 2, 2},
                           {2, 1, 0, 0, 0, 0, 1, 1, 2},
                           {2, 1, 0, 0, 0, 0, 0, 1, 2},
                           {2, 1, 0, 1, 1, 1, 1, 1, 2},
                           {2, 1, 1, 1, 2, 2, 2, 2, 2},
                           {2, 2, 2, 2, 2, 2, 2, 2, 2},
                           {2, 2, 2, 2, 2, 2, 2, 2, 2}
                       };

            Filler.FillArea(grid, 1, 1, 2);

            Assert.That(grid, Is.EquivalentTo(expectedGrid));
        }
    }
}