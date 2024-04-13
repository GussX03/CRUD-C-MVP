using System;
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
    }
}
