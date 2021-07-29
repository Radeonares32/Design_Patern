using System;
using System.Collections.Generic;

namespace Mediator
{
    class Program
    {
        static void Main()
        {
            Console.ReadLine();
        }
    }

    abstract class CourseMember
    {
        
    }

    class Teacher : CourseMember
    {
        private Mediator _mediator;

        public Teacher(Mediator mediator)
        {
            _mediator = mediator;
        }

        public void ReciveQuestion(string question, Student student)
        {
            Console.WriteLine("Teacher recieved a question from {0},{1}",student.Name,question);
        }
    }

    class Student : CourseMember
    {
        public void ReciveImage(string url)
        {
            throw new NotImplementedException();
        }

        public void ReciveAnswer(string answer)
        {
            throw new NotImplementedException();
        }

        public string Name { get; set; }
    }

    class Mediator
    {
        public Teacher Teacher { get; set; }
        public List<Student> Students { get; set; }

        public void UpdateImage(string url)
        {
            foreach (var student in Students)
            {
                student.ReciveImage(url);
            }
        }

        public void SendQuestion(string question,Student student)
        {
            Teacher.ReciveQuestion(question,student);
        }

        public void SendAnswer(string answer, Student student)
        {
            student.ReciveAnswer(answer);
        } 
    }
}