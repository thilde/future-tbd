﻿using FutureTbd.Models;

namespace FutureTbd.Controllers
{
    public interface IDataEndpoint
    {
        SearchResult Search(string searchText);
        SearchResult SearchByState(string state);
    }
}