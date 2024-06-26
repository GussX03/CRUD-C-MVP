﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CRUD_C__MCP.Models;
using CRUD_C__MCP.Views;


namespace CRUD_C__MCP.Presenters
{
    public class PetPresenter
    {
        //Fields
        private IPetView view;
        private IPetRepository repository;
        private BindingSource petsBindingSource;
        private IEnumerable<PetModel> petList;

        //Constructor
        public PetPresenter(IPetView view, IPetRepository repository)
        {
            this.petsBindingSource = new BindingSource();
            this.view = view;
            this.repository = repository;
            //Subscribe event handler methods to view events
            this.view.SearchEvent += SearchPet;
            this.view.AddNewEvent += AddNewPet;
            this.view.EditEvent += LoadSelectedPetToEdit;
            this.view.DeleteEvent += DeleteSelectedPet;
            this.view.SaveEvent += SavePet;
            this.view.CancelEvent += CancelAction;
            //Set pets bindind source
            this.view.SetPetListBindingSource(petsBindingSource);
            //Load pet list view
            LoadAllPetList();
            //Show view
            this.view.Show();
            //Methods
             void LoadAllPetList()
            {
                petList = repository.GetAll();
                petsBindingSource.DataSource = petList;//Set data source.
            }
             void SearchPet(object sender, EventArgs e)
            {
                bool emptyValue = string.IsNullOrWhiteSpace(this.view.SearchValue);
                if (emptyValue == false)
                    petList = repository.GetByValue(this.view.SearchValue);
                else petList = repository.GetAll();
                petsBindingSource.DataSource = petList;
            }
            
        }
        private void LoadAllPetList()
        {
            petList = repository.GetAll();
            petsBindingSource.DataSource = petList;//Set data source.
        }

        private void CancelAction(object sender, EventArgs e)
        {
            CleanviewFields();
        }

        private void SavePet(object sender, EventArgs e)
        {
            var model = new PetModel
            {
                Id = int.Parse(view.PetId),
                Name = view.PetName,
                Type = view.PetType,
                Colour = view.PetColour
            };
            try
            {
                new Common.ModelDataValidation().ValidateModel(model);
                if (view.IsEdit)
                {
                    repository.Edit(model);
                    view.Message = "Pet updated successfully";
                }
                else
                {
                    repository.Add(model);
                    view.Message = "Pet added successfully";
                }   
                view.IsSuccessfull = true;
                LoadAllPetList();
                CleanviewFields();
            } catch (Exception ex)
            {
                view.IsSuccessfull = false;
                view.Message = ex.Message;
            }
        }

        private void CleanviewFields()
        {
            view.PetId = "0";
            view.PetName = "";
            view.PetType = "";
            view.PetColour = "";
        }

        private void DeleteSelectedPet(object sender, EventArgs e)
        {
            try {
                var pet = (PetModel)petsBindingSource.Current;
                repository.Delete(pet.Id);
                view.IsSuccessfull = true;
                view.Message = "Pet deleted successfully";
                LoadAllPetList();
            }
            catch(Exception ex) {
                view.IsSuccessfull = false;
                view.Message = "An error ocurred, could not delete pet";
            }
        }

        private void LoadSelectedPetToEdit(object sender, EventArgs e)
        {
            var pet = (PetModel)petsBindingSource.Current; // se obtiene el valor de la tabla seleccionado
            view.PetId = pet.Id.ToString();
            view.PetName = pet.Name;
            view.PetType = pet.Type;
            view.PetColour = pet.Colour;
            view.IsEdit = true;
        }

        private void AddNewPet(object sender, EventArgs e)
        {
            view.IsEdit = false;
        }
    }
}
