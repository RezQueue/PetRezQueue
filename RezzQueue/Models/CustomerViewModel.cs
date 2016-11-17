using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RezzQueue.Models
{
    public class CustomerViewModel
    {
        public Customer Customer { get; set; }
        public IEnumerable<Animal> AllAnimals { get; set; }
        public IEnumerable<PetStatus> AllPetstatus { get; set; }

        private List<int> _selectedAnimals;
        public List<int> SelectedAnimals {
            get
            {
                if (_selectedAnimals == null)
                {
                   
                    _selectedAnimals = (from a in Customer.Animals
                                        select a.AnimalId).ToList();
                }
                return _selectedAnimals;
            }
            set { _selectedAnimals = value; }
        }
    

        private List<int> _selectedPetStatus;
        public List<int> SelectedPetStatus
{
    get
    {
        if (_selectedPetStatus == null)
        {
          
            _selectedPetStatus = (from a in Customer.PetStatuses
                                   select a.PetStatusId).ToList();
        }
        return _selectedPetStatus;
    }
    set { _selectedPetStatus = value; }
}

    }
}