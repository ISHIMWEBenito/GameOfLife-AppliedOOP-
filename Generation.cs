using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Conway
{
    /*****************************
            INHERITANCE
            BELOW Generation 
            inherited
            class
            Cell
    ******************************/
    internal class Generation:Cell 
    {
        private int width;
        /*****************************
            ENCAPSULATION 
            BELOW AND ABOVE
    ******************************/

        private int height;
        public int[,] board;
        public double density;
        public string s;
       
       public int Width
        {
            get { return width; }
                set {
                if (value != 20 && value != 25)
                {
                    width = 20;
                }
                else
                {
                    width = value;
                }
            }
        }
        public int Height
        {
            get { return height; }
            set
            {
                if (value != 20 && value != 25)
                {
                    height = 20;
                }
                else
                {
                    height = value;
                }
            }
        }
        public Generation(double density,int width,int height)//Pupulation
        {
             board = new int[width, height];

            Width= width;
            Height= height;
            
            this.density = density;
        }
    
        public Generation(Generation obj,string s)//string constructor
        {
            this.s = s;
            Height = obj.Height;
            this.board = obj.board;
            Width = obj.Width;
       
            Console.Clear();
            Console.WriteLine("---");
            int aliveCells = 0;
            for (int y = 0; y < Height; y++)
            {
                String line = "|";
                for (int x = 0; x < Width; x++)
                {
                    if (board[x, y] == 0)
                    {
                        line += ".";
                    }
                    else
                    {
                        aliveCells++;
                        line += s;
                    }
                }
                line += "|";
                Console.WriteLine(line);
            }
            Console.WriteLine("---\n");
            Console.WriteLine($"Alive cells: {aliveCells}");

           
        }
        public Generation(int width, int height, double density) : this(density, width, height)//initial Alive cells
        {
            int initialAlive = (int)Math.Round((density * width * height) / 100);
            Console.WriteLine(initialAlive);
            Random gen = new Random();
            int a = -1;
            int b = -2;

            // Console.WriteLine(a);
            for (int i = 0; i < initialAlive; i++)
            {
                int x = gen.Next(width); //1 1
                int y = gen.Next(height); //2 2
                if (i == 0)
                {
                    /*************************************
                            POLYMORPHISM
                            BELOW BECAUSE WE USED
                            A METHOD OF BASE CLASS "Cell'
                    **************************************/

                    SetAlive(x, y);
                }
                else
                {
                    for (int j = i; j < i + 1; j++)
                    {
                        if (x == a || y == b)
                        {


                            i--;

                            break;

                        }
                        else
                        {
                    /*************************************
                            POLYMORPHISM
                            BELOW BECAUSE WE USED
                            A METHOD OF BASE CLASS "Cell'
                    **************************************/
                            SetAlive(x, y);

                        }

                    }

                }
                a = x;
                b = y;

            }
        }
     
        /*************************************
            POLYMORPHISM
            BELOW BECAUSE WE USED
            A METHOD OF BASE CLASS "Cell'
        **************************************/
        public override void SetAlive(int x, int y)//set Alive
        {
            this.board[x,y] = 1;
           
        }
        public void step()//Simulation step
        {
            int[,] newBoard = new int[Width, Height];

            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    int aliveNeighbours = countAliveNeighbours(x, y);

                    if (getState(x, y) == 1)
                    {
                        if (aliveNeighbours < 2)
                        {
                            newBoard[x, y] = 0;
                        }
                        else if (aliveNeighbours == 2 || aliveNeighbours == 3)
                        {
                            newBoard[x, y] = 1;
                        }
                        else if (aliveNeighbours > 3)
                        {
                            newBoard[x, y] = 0;
                        }
                    }
                    else
                    {
                        if (aliveNeighbours == 3)
                        {
                            newBoard[x, y] = 1;
                        }
                    }

                }
            }

            this.board = newBoard;
        }
        private int getState(int x, int y)//Boundaries
        {
            if (x < 0 || x >= Width)
            {
                return 0;
            }

            if (y < 0 || y >= Height)
            {
                return 0;
            }

            return this.board[x, y];
        }
        private int countAliveNeighbours(int x, int y)
        {
            int count = 0;

            count += getState(x - 1, y - 1);
            count += getState(x, y - 1);
            count += getState(x + 1, y - 1);

            count += getState(x - 1, y);
            count += getState(x + 1, y);

            count += getState(x - 1, y + 1);
            count += getState(x, y + 1);
            count += getState(x + 1, y + 1);

            return count;
        }
        public int AliveCellsinBoard()
        {
            int aliveCells = 0;
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    if (this.board[x, y]==1)
                        aliveCells++;
                }
            }
            return aliveCells;
        }


        public override string ToString()//Tstring method
        {
            string result = "";
       //     Console.WriteLine("---");
            for (int y=0;y< this.Height; y++)
            {
                for(int x=0;x< this.Width;x++)
                {
                    if (this.board[x, y] == 0)
                    {
                        result += ".";
                    }
                    else
                    {
                        
                      result += s;
                    }
                }
                result += "\n";
            }
      //    Console.WriteLine("Allive Cells:"+AliveCellsinBoard());
            return result;
           

        }
        public int check(int j)
        {
            string [] check = new string[j];
            int count = 0;

            for (int i = j-1; i <=j; i++)
            {
                if (j == 0)
                {
                    break;
                }
                else
                {
                    check[i] = ToString();
                }
            }
            for (int i = j-1; i <= j; i++)
            {
                if (j == 0)
                {
                    break;
                }
                else
                {
                    if (check[i] == check[i + 1])
                    {
                     
                        count++;
                        break;

                    }
                }
                
            }
           return count;
        }


    }
}
