using System;
using System.Collections.Generic;
using System.Collections;

namespace PetStore
{
    public static class ListExtensions
    {
        public static List<string> InStock<T>(this List<T> list) where T : Product => list.Where(x => x.Quantity > 0).Select(x => x.Name).ToList();
    }
}
