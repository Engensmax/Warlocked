using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Warlocked
{
    class RandomManager
    {
        private static RandomManager instance;
        private Random random;

        public static RandomManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new RandomManager();

                return instance;
            }
        }

        public RandomManager()
        {
            random = new Random();
        }

        public int Next(int min, int max)
        {
            return random.Next(min, max);
        }

    }
}
