using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Move_Multiple_Objects_using_Paint_MOO_ICT
{
    internal class Card
    {
        public Image cardPic;
        public int width;
        public int height;
        public Point position = new Point();
        public bool active = false;
        public Rectangle rect;

        public Card(string imageLocation)
        {
            cardPic = Image.FromFile(imageLocation);
            width = 65;
            height = 105;
            rect = new Rectangle(position.X, position.Y, width, height);
        }


    }
}
