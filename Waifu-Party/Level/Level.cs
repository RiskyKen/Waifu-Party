using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waifu_Party.Level
{
    public class Level : IDisposable
    {
        private String _name;


        public Level(String name)
        {
            this._name = name;
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }

        public void Update()
        {
            //throw new NotImplementedException();
        }

        public void Draw()
        {
            //throw new NotImplementedException();
        }
    }

    public class LevelTile
    {

    }
}
