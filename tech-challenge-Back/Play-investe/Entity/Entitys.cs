﻿namespace Play_investe.Entity
{
    public class Entitys
    {

        public int Id { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? DesactivedDate { get; set; } = DateTime.Now;
        public DateTime? UpdatedDate { get; set; } = DateTime.Now;

        public Entitys() { }
    }
}
