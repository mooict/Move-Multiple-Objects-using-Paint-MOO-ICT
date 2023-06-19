namespace Move_Multiple_Objects_using_Paint_MOO_ICT
{

    // Made by MOO ICT
    // For Educational Purpose Only
    public partial class Form1 : Form
    {

        List<Card> cards = new List<Card>();
        Card SelectedCard;
        int indexValue;
        int xPos = 0;
        List<string> imageLocation = new List<string>();
        int cardNumber = -1;
        int totalCards = 0;
        int lineAnimation = 0;


        public Form1()
        {
            InitializeComponent();
            SetUpApp();
        }

        private void SetUpApp()
        {
            imageLocation = Directory.GetFiles("cards", "*.png").ToList();
            totalCards = imageLocation.Count;

            for (int i = 0; i < totalCards; i++)
            {
                MakeCards();
            }

            label1.Text = "Card " + (cardNumber + 1) + " of " + totalCards;
        }

        private void MakeCards()
        {
            cardNumber++;
            xPos += 50;
            Card newCard = new Card(imageLocation[cardNumber]);
            newCard.position.X = xPos;
            newCard.position.Y = 300;
            newCard.rect.X = newCard.position.X;
            newCard.rect.Y = newCard.position.Y;
            cards.Add(newCard);
        }

        private void FormMouseDown(object sender, MouseEventArgs e)
        {

            Point mousePosition = new Point(e.X, e.Y);

            foreach (Card newCard  in cards)
            {
                if (SelectedCard == null)
                {
                    if (newCard.rect.Contains(mousePosition))
                    {
                        SelectedCard = newCard;
                        newCard.active = true;
                        indexValue = cards.IndexOf(newCard);
                        label1.Text = "Card " + (indexValue + 1) + " of " + totalCards;
                    }
                }
            }
        }

        private void FormMouseMove(object sender, MouseEventArgs e)
        {
            if (SelectedCard != null)
            {
                SelectedCard.position.X = e.X - (SelectedCard.width / 2);
                SelectedCard.position.Y = e.Y - (SelectedCard.height / 2);
            }
        }

        private void FormMouseUp(object sender, MouseEventArgs e)
        {
            foreach (Card tempCard in cards)
            {
                tempCard.active = false;
            }
            SelectedCard = null;
            lineAnimation = 0;
        }

        private void FormPaintEvent(object sender, PaintEventArgs e)
        {
            foreach (Card card in cards)
            {
                e.Graphics.DrawImage(card.cardPic, card.position.X, card.position.Y, card.width, card.height);

                Pen outline;

                if (card.active)
                {
                    outline = new Pen(Color.Maroon, lineAnimation);
                }
                else
                {
                    outline = new Pen(Color.Transparent, 1);
                }

                e.Graphics.DrawRectangle(outline, card.rect);
            }

            if (SelectedCard != null)
            {
                e.Graphics.DrawImage(SelectedCard.cardPic, SelectedCard.position.X, SelectedCard.position.Y, SelectedCard.width, SelectedCard.height);
            }

        }

        private void FormTimerEvent(object sender, EventArgs e)
        {

            foreach (Card card in cards)
            {
                card.rect.X = card.position.X;
                card.rect.Y = card.position.Y;
            }

            if (SelectedCard != null)
            {
                if (lineAnimation < 5)
                {
                    lineAnimation++;
                }
            }

            this.Invalidate();


        }
    }
}