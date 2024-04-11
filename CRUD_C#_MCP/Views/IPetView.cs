using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD_C__MCP.Views
{
    public interface IPetView
    {
        //Properties - Fields
        String PetId { get; set; }
        String PetName { get; set; }
        String PetType { get; set; }
        String PetColour { get; set; }
        String SearchValue { get; set; }
        String IsEdit { get; set; }
        String IsSuccessfull { get; set; }
        String Message { get; set; }
        // Events
        event EventHandler SearchEvent;
        event EventHandler AddNewEvent;
        event EventHandler EditEvent;
        event EventHandler DeleteEvent;
        event EventHandler SaveEvent;
        event EventHandler CancelEvent;
        // Methods
        void SetPetListBindingSource(BindingSource petList);
        void Show(); // Optional
    }
}
