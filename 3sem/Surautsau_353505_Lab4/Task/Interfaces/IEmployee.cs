﻿namespace Task.Interfaces
{
    public interface IEmployee
    {
        int Id { get; set; }   
        string Name { get; set; }  
        string Position { get; set; }

        void Work();
    }
}
