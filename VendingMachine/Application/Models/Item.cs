﻿namespace VendingMachine.Application.Models;

public abstract class Item
{
    public int Id { get; set; }
    public double Price { get; }
}