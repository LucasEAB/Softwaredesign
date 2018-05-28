using System;
using System.Collections.Generic;

namespace uml
{
    class Program
    {
        static void Main(string[] args)
        {
        }
        public List<Participants<P>> ParticipantsList = new List<ParticipantsList<P>>();

        public List<Course<C>> CourseList = new List<CourseList<C>>();

        public class Person
        {
            public string LastName;
            public string FirstName;
            public int age;
        }
        public class Participants : Person
        {
            public int MatriculationNumber;
            public CourseList<C> Course; 
        }
        public class Lecturer : Person
        {
            public string Room;
            public DateTime Hours;
            public CourseList<C> Course; 

            public void AddCourse(CourseList<C> course)
        {
            CourseList.Add(course);
        }
            public void AddParticipants(ParticipantsList<P> participants)
        {
            ParticipantsList.Add(participants);
        } 
        }
        public class Course
        {
            public string Title;
            public DateTime Date;
            public DateTime Time;
            public string Room;

            public string outputInformationText()
            {
                return ;
            }
        }
    }
}