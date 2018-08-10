using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elevator
{

    internal enum Status
    {
        GoingUp,
        GoingDown,
        Stopped
    }

    internal class Elevator
    {
        
        public readonly int TopFloor;

        public Elevator(int topFloor)
        {
            TopFloor = topFloor;
        }

        public int CurrentFloor { get; set; } = 0;
        public Status Status { get; set; } = Status.Stopped;

        public void AddRequest(int floor)
        {
            

            switch (Status)
            {
                case Status.GoingDown:
                    MoveDown(floor);
                    break;

                case Status.Stopped:
                    if (CurrentFloor < floor)
                        MoveUp(floor);
                    else
                        MoveDown(floor);
                    break;

                case Status.GoingUp:
                    MoveUp(floor);
                    break;

                default:
                    break;
            }
        }

        public void MoveUp( int floor)
        {
          
            for (var i = CurrentFloor; i <= floor; i++) // Go to top most requested floor
                if (floor== CurrentFloor)
                    Stop(i);
                else
                    continue;

            Status = Status.Stopped;
        }

        public void MoveDown(int floor)
        {
            var min = floor;
            for (var i = CurrentFloor; i >= floor; i--)
                if (floor == CurrentFloor)
                    Stop(i);
                else
                    continue;

            Status = Status.Stopped;
        }

        public void Stop(int floor)
        {
           
            CurrentFloor = floor;
          
        }
       

    }

    internal class Manager
    {
        private readonly Elevator _elevator = new Elevator(10);

        public void ButtonPressed(int floor)
        {

            _elevator.AddRequest(floor);

        }

        static void Main(string[] args)
        {
            Manager m = new Manager();
            Console.WriteLine("Press the floors you want to go in 10 floors");
            int[] floorsToGo = Array.ConvertAll(Console.ReadLine().Split(' '), Int32.Parse);
            Array.Sort(floorsToGo);
            foreach(var floor in floorsToGo)
            {
                m.ButtonPressed(floor);
                Console.WriteLine(String.Format("U have reached {0}",floor) );
            }


           
        }
    }
}
