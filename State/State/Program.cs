using System;

namespace State
{
    class Program
    {
        static void Main()
        {
            Context context = new Context();
            Added added = new Added();
            added.DoAction(context);
            Console.WriteLine(context.GetState().ToString());
            Console.ReadLine();
        }
    }

    interface IState
    {
        public void DoAction(Context context);
    }

    class Context
    {
        private IState _state;

        public void SetState(IState state)
        {
            _state = state;
        }

        public IState GetState()
        {
            return _state;
        } 
    }

    class Added : IState
    {
        public void DoAction(Context context)
        {
            Console.WriteLine("Added State");
            context.SetState(this);
        }

        public override string ToString()
        {
            return "Added";
        }
    }
    class Deleted : IState
    {
        public void DoAction(Context context)
        {
            Console.WriteLine("Deleted State");
            context.SetState(this);
        }
        public override string ToString()
        {
            return "Deleted";
        }
    }
}