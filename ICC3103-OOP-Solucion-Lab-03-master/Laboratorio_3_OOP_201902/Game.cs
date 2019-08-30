using Laboratorio_3_OOP_201902.Cards;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;


namespace Laboratorio_3_OOP_201902
{
    public class Game     
    {
        //Atributos
        private Player[] players;
        private Player activePlayer;
        private List<Deck> decks;
        private Board boardGame;
        private bool endGame;

        //Constructor
        public Game()
        {
            List<Deck> decks= new List<Deck>();
            List<Card> Captains = new List<Card>();
            player1_cards = new List<Card>();
            player2_cards = new List<Card>();
            capitan = new List<Card>();
        }

        //Propiedades
        public Player[] Players
        {
            get
            {
                return this.players;
            }
        }
        public Player ActivePlayer
        {
            get
            {
                return this.activePlayer;
            }
            set
            {
                activePlayer = value;
            }
        }
        public List<Deck> Decks
        {
            get
            {
                return this.decks;
            }
        }
        public Board BoardGame
        {
            get
            {
                return this.boardGame;
            }
        }
        public bool EndGame
        {
            get
            {
                return this.endGame;
            }
            set
            {
                endGame = value;
            }
        }

        //Metodos
        List<Card> player1_cards;
        List<Card> player2_cards;
        List<Card> capitan;
        public void Leer_archivo()
        {
            StreamReader reader = new StreamReader("Decks.txt");
            int i=0;
            while (!reader.EndOfStream)
            {
                
                string line = reader.ReadLine();
                if (line == "START" || line == "END")
                {
                    i++;
                }
                else
                {
                    if (line.Contains("Combat"))
                    {
                        var c = line.Split(",");
                        CombatCard carta_de_combate = new CombatCard(c[1], c[2], c[3], int.Parse(c[4]), bool.Parse(c[5]));
                        if (i == 1)
                            {
                               player1_cards.Add(carta_de_combate);
                            }
                        else
                        {
                            player2_cards.Add(carta_de_combate);
                        }

                    if (line.Contains("Special"))
                    {
                        var x = line.Split(",");
                        SpecialCard carta_especial = new SpecialCard(x[1], x[2], x[3]);
                        if (i == 2)
                            {
                                player2_cards.Add(carta_especial);
                            }
                        else
                        {
                                player2_cards.Add(carta_especial);

                        }

                    }
                    

                    }

                    /*
                    decks.Add(player1_cards);
                    decks.Add(player2_cards);
                    */
                }
                //Agrego el mazo a la lista decks
                
                Console.WriteLine(line);

            }

            reader.Close();

        }

        public void Read_file_captain()
        {
            StreamReader reader = new StreamReader("Captains.txt");
            
            

            string linea = reader.ReadLine();
            
            if (linea.Contains("captain"))
            {
                var z = linea.Split(",");
                SpecialCard capitan = new SpecialCard(z[1], z[2],z[3]);
                
            }
            Console.WriteLine(linea);
            reader.Close();
        }
        public bool CheckIfEndGame()
        {
            if (players[0].LifePoints == 0 || players[1].LifePoints == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public int GetWinner()
        {
            if (players[0].LifePoints == 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        public void Play()
        {
            throw new NotImplementedException();
        }
    }
}
