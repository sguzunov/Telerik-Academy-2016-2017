﻿using System.Collections.Generic;
using Cosmetics.Contracts;
using Cosmetics.Engine;

namespace Cosmetics.Test.Mocks
{
    internal class EngineFake : CosmeticsEngine
    {
        public EngineFake(ICosmeticsFactory factory, IShoppingCart shoppingCart, ICommandProvider commandProvider)
            : base(factory, shoppingCart, commandProvider)
        {
        }

        public IDictionary<string, ICategory> Categories
        {
            get
            {
                return base.categories;
            }
        }

        public IDictionary<string, IProduct> Products
        {
            get
            {
                return base.products;
            }
        }
    }
}
